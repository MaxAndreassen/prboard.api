// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using prboard.api.data;

namespace prboard.api.data.Migrations
{
    [DbContext(typeof(PrBoardDbContext))]
    [Migration("20210423122154_GitAccountUsername")]
    partial class GitAccountUsername
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("prboard.api.data.Countries.Entities.CountryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Alpha2")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Alpha3")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("prboard.api.data.Files.Entities.FileEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Extension")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("FileContents")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("FileName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<long>("FileSize")
                        .HasColumnType("bigint");

                    b.Property<int?>("FileTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("FileTypeId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("prboard.api.data.Files.Entities.FileTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("SystemName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("FileTypes");
                });

            modelBuilder.Entity("prboard.api.data.Transactions.Entities.TransactionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("AmountInPence")
                        .HasColumnType("double");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Identifier")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("PurchasingUserId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("StripeId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("PurchasingUserId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("prboard.api.data.Users.Entities.GitAccountSourceEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("GitAccountSources");
                });

            modelBuilder.Entity("prboard.api.data.Users.Entities.UserCreditEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CreditChangeInPence")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserCredits");
                });

            modelBuilder.Entity("prboard.api.data.Users.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("IsEmailVerified")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastActive")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("OptedIntoMarketingEmails")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("ProfileImageId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("UserTypeId")
                        .HasColumnType("int");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("ProfileImageId");

                    b.HasIndex("UserTypeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("prboard.api.data.Users.Entities.UserGitAccountEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("GitAccountSourceId")
                        .HasColumnType("int");

                    b.Property<string>("SourceUserIdentifier")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Token")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("GitAccountSourceId");

                    b.HasIndex("UserId");

                    b.ToTable("UserGitAccounts");
                });

            modelBuilder.Entity("prboard.api.data.Users.Entities.UserPasswordResetRequestEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserPasswordResetRequests");
                });

            modelBuilder.Entity("prboard.api.data.Users.Entities.UserTokenEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("ExpiresAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Token")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("prboard.api.data.Users.Entities.UserTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("UserTypes");
                });

            modelBuilder.Entity("prboard.api.data.Users.Entities.UserVerificationRequestEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserVerificationRequests");
                });

            modelBuilder.Entity("prboard.api.data.Files.Entities.FileEntity", b =>
                {
                    b.HasOne("prboard.api.data.Files.Entities.FileTypeEntity", "FileType")
                        .WithMany()
                        .HasForeignKey("FileTypeId");
                });

            modelBuilder.Entity("prboard.api.data.Transactions.Entities.TransactionEntity", b =>
                {
                    b.HasOne("prboard.api.data.Users.Entities.UserEntity", "PurchasingUser")
                        .WithMany()
                        .HasForeignKey("PurchasingUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("prboard.api.data.Users.Entities.UserCreditEntity", b =>
                {
                    b.HasOne("prboard.api.data.Users.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("prboard.api.data.Users.Entities.UserEntity", b =>
                {
                    b.HasOne("prboard.api.data.Countries.Entities.CountryEntity", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.HasOne("prboard.api.data.Files.Entities.FileEntity", "ProfileImage")
                        .WithMany()
                        .HasForeignKey("ProfileImageId");

                    b.HasOne("prboard.api.data.Users.Entities.UserTypeEntity", "UserType")
                        .WithMany()
                        .HasForeignKey("UserTypeId");
                });

            modelBuilder.Entity("prboard.api.data.Users.Entities.UserGitAccountEntity", b =>
                {
                    b.HasOne("prboard.api.data.Users.Entities.GitAccountSourceEntity", "GitAccountSource")
                        .WithMany()
                        .HasForeignKey("GitAccountSourceId");

                    b.HasOne("prboard.api.data.Users.Entities.UserEntity", "User")
                        .WithMany("GitAccounts")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("prboard.api.data.Users.Entities.UserPasswordResetRequestEntity", b =>
                {
                    b.HasOne("prboard.api.data.Users.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("prboard.api.data.Users.Entities.UserTokenEntity", b =>
                {
                    b.HasOne("prboard.api.data.Users.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("prboard.api.data.Users.Entities.UserVerificationRequestEntity", b =>
                {
                    b.HasOne("prboard.api.data.Users.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
