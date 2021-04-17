using System.Linq;
using System.Reflection;
using Amazon.S3;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using foundation.Entities;
using foundation.Extensions;
using Hangfire;
using Hangfire.MySql.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using prboard.api.data;
using prboard.api.domain;
using prboard.api.domain.Countries.Mapping;
using prboard.api.domain.Email.Configuration;
using prboard.api.domain.Files.Configuration;
using prboard.api.domain.Files.Mappings;
using prboard.api.domain.PaymentProviders.Configuration;
using prboard.api.domain.Users.Mappings;
using prboard.api.Extensions;
using prboard.api.infrastructure.s3.Mappings;
using prboard.api.infrastructure.s3.Services;
using prboard.api.infrastructure.sendgrid.Mappings;
using prboard.api.infrastructure.stripe.Mappings;
using prboard.api.Security;
using prboard.api.Security.Handlers;

namespace prboard.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public static IContainer Container { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en-GB");
            });
            
            services
                .AddDbContextConfiguration(Configuration)
                .AddCorsConfiguration()
                .AddControllers(options =>
                    options.Filters.Add(new HttpResponseExceptionFilter()));

            services.AddDefaultAWSOptions(Configuration.GetAWSOptions());
            services.AddAWSService<IAmazonS3>();

            services.AddHttpContextAccessor();

            services.Configure<StripeConfig>(Configuration.GetSection("Stripe"));
            services.Configure<AwsConfig>(Configuration.GetSection("AWS_Creds"));
            services.Configure<SendGridConfig>(Configuration.GetSection("SendGrid"));
            services.Configure<LinkConfig>(Configuration.GetSection("Link"));

            services.AddHangfire(configuration =>
            {
                configuration.UseStorage(
                    new MySqlStorage(
                        Configuration.GetConnectionString("DefaultConnection"),
                        new MySqlStorageOptions
                        {
                            TablePrefix = "Hangfire"
                        }
                    )
                );
            });

            services.AddHangfireServer();

            services.AddSingleton(provider => new MapperConfiguration(cfg =>
            {
                cfg.AddProfiles(GetMappingProfileAssemblies());

                cfg.AddProfile(new UserMappingProfile(new PreSignedUrlGenerator(
                    provider.GetService<IOptions<AwsConfig>>(),
                    provider.GetService<IOptions<AwsConfig>>().Value.BucketName))
                );
                
                cfg.AddProfile(new FileMappingProfile());
                cfg.AddProfile(new CountryMappingProfile());
            }).CreateMapper());

            services.AddAuthentication(o => { o.DefaultScheme = Schemes.TokenAuthenticationDefaultScheme; })
                .AddScheme<TokenOptions, TokenHandler>(Schemes.TokenAuthenticationDefaultScheme, o => { });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder
                .AddAutofacWithFoundation()
                .ConfigureDependencies();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/error-local-development");
            }
            else
            {
                app.UseExceptionHandler("/error");
            }
            
            //app.UseMiddleware<ErrorHandlerMiddleware>();
            
            //app.UseHttpsRedirection();

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseHangfireDashboard("/hangfire");

            app.UseRouting();
            
            app.UseAuthorization();

            app.UseCors("All");

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            var container = app.ApplicationServices.GetAutofacRoot();

            container.Resolve<PrBoardDbContext>()
                .Database
                .Migrate();

            // RecurringJob.AddOrUpdate<IMatchResultSubmissionFinaliser>("match_result_submission_finaliser", w => w.SweepAsync(), "*/5 * * * *");
        }

        private Assembly[] GetMappingProfileAssemblies()
        {
            var assemblies = new[]
            {
                typeof(S3MappingProfile).Assembly,
                typeof(StripeMappingProfile).Assembly,
                typeof(SendGridMappingProfile).Assembly
            };

            var entityAssembly = typeof(BaseEntity).Assembly;

            if (!assemblies.Contains(entityAssembly))
                assemblies = assemblies.Concat(new[] {entityAssembly}).ToArray();

            return assemblies;
        }
    }
}