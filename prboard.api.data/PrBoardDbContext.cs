using Microsoft.EntityFrameworkCore;
using prboard.api.data.Base;
using prboard.api.data.Countries.Entities;
using prboard.api.data.Countries.Mappings;
using prboard.api.data.Files.Entities;
using prboard.api.data.Files.Mappings;
using prboard.api.data.Transactions.Entities;
using prboard.api.data.Transactions.Mappings;
using prboard.api.data.Users.Entities;
using prboard.api.data.Users.Mappings;

namespace prboard.api.data
{
    public class PrBoardDbContext : BaseDataContext
    {
        public DbSet<UserEntity> Users { get; set; }
        
        public DbSet<UserTypeEntity> UserTypes { get; set; }

        public DbSet<UserTokenEntity> UserTokens { get; set; }

        public DbSet<UserVerificationRequestEntity> UserVerificationRequests { get; set; }

        public DbSet<UserPasswordResetRequestEntity> UserPasswordResetRequests { get; set; }

        public DbSet<CountryEntity> Countries { get; set; }

        public DbSet<TransactionEntity> Transactions { get; set; }

        public DbSet<FileEntity> Files { get; set; }

        public DbSet<FileTypeEntity> FileTypes { get; set; }

        public DbSet<UserCreditEntity> UserCredits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        public override void Seed()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new UserEntityMapping())
                .ApplyConfiguration(new UserTypeEntityMapping())
                .ApplyConfiguration(new UserTokenEntityMapping())
                .ApplyConfiguration(new UserVerificationRequestEntityMapping())
                .ApplyConfiguration(new UserPasswordResetRequestEntityMapping())
                .ApplyConfiguration(new TransactionEntityMapping())
                .ApplyConfiguration(new FileEntityMapping())
                .ApplyConfiguration(new FileTypeEntityMapping())
                .ApplyConfiguration(new CountryEntityMapping());
        }

        public PrBoardDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}