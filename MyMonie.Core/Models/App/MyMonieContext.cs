using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace MyMonie.Core.Models.App
{
    public partial class MyMonieContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public MyMonieContext()
        {
        }

        public MyMonieContext(DbContextOptions<MyMonieContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<AccountGroup> AccountGroups { get; set; } = null!;
        public virtual DbSet<Budget> Budgets { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Channel> Channels { get; set; } = null!;
        public virtual DbSet<Code> Codes { get; set; } = null!;
        public virtual DbSet<Currency> Currencies { get; set; } = null!;
        public virtual DbSet<DarkMode> DarkModes { get; set; } = null!;
        public virtual DbSet<Group> Groups { get; set; } = null!;
        public virtual DbSet<Loan> Loans { get; set; } = null!;
        public virtual DbSet<LoanInterest> LoanInterests { get; set; } = null!;
        public virtual DbSet<LoanRepayment> LoanRepayments { get; set; } = null!;
        public virtual DbSet<RepeatTransaction> RepeatTransactions { get; set; } = null!;
        public virtual DbSet<Transaction> Transactions { get; set; } = null!;
        public virtual DbSet<TransactionQueue> TransactionQueues { get; set; } = null!;
        public virtual DbSet<TransactionType> TransactionTypes { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserCategory> UserCategories { get; set; } = null!;
        public virtual DbSet<UserGroup> UserGroups { get; set; } = null!;
        public virtual DbSet<UserSetting> UserSettings { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("MyMonie"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("MyMonie");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasOne(d => d.AccountGroup)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.AccountGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Accounts__Accoun__162F4418");
            });

            modelBuilder.Entity<AccountGroup>(entity =>
            {
                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AccountGroups)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AccountGr__UserI__153B1FDF");
            });

            modelBuilder.Entity<Budget>(entity =>
            {
                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Period).IsFixedLength();

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Budgets)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Budgets__Categor__1446FBA6");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Budgets)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Budgets__UserId__1352D76D");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(d => d.CreatedById)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Categorie__Creat__0E8E2250");
            });

            modelBuilder.Entity<Channel>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Code>(entity =>
            {
                entity.Property(e => e.Code1).IsFixedLength();

                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Codes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Codes__UserId__2665ABE1");
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<DarkMode>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__DarkMode__1788CC4C1CDCC7B3");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.HasOne(d => d.Channel)
                    .WithMany(p => p.DarkModes)
                    .HasForeignKey(d => d.ChannelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DarkModes__Chann__0D99FE17");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.DarkMode)
                    .HasForeignKey<DarkMode>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DarkModes__UserI__0CA5D9DE");
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LoanType).IsFixedLength();

                entity.Property(e => e.RepaymentInterval).IsFixedLength();

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Loans__AccountId__20ACD28B");

                entity.HasOne(d => d.Channel)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.ChannelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Loans__ChannelId__22951AFD");

                entity.HasOne(d => d.Interest)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.InterestId)
                    .HasConstraintName("FK__Loans__InterestI__21A0F6C4");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Loans__UserId__1FB8AE52");
            });

            modelBuilder.Entity<LoanInterest>(entity =>
            {
                entity.Property(e => e.Interval).IsFixedLength();

                entity.Property(e => e.PaymentScheme).IsFixedLength();

                entity.HasOne(d => d.Loan)
                    .WithMany(p => p.LoanInterests)
                    .HasForeignKey(d => d.LoanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LoanInter__LoanI__23893F36");
            });

            modelBuilder.Entity<LoanRepayment>(entity =>
            {
                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.LoanRepayments)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LoanRepay__Accou__257187A8");

                entity.HasOne(d => d.Loan)
                    .WithMany(p => p.LoanRepayments)
                    .HasForeignKey(d => d.LoanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LoanRepay__LoanI__247D636F");
            });

            modelBuilder.Entity<RepeatTransaction>(entity =>
            {
                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IntervalDescription).IsFixedLength();

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.RepeatTransactions)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RepeatTra__Categ__1BE81D6E");

                entity.HasOne(d => d.Channel)
                    .WithMany(p => p.RepeatTransactions)
                    .HasForeignKey(d => d.ChannelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RepeatTra__Chann__1DD065E0");

                entity.HasOne(d => d.TransactionType)
                    .WithMany(p => p.RepeatTransactions)
                    .HasForeignKey(d => d.TransactionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RepeatTra__Trans__1CDC41A7");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RepeatTransactions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RepeatTra__UserI__1AF3F935");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transacti__Categ__18178C8A");

                entity.HasOne(d => d.Channel)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.ChannelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transacti__Chann__19FFD4FC");

                entity.HasOne(d => d.TransactionType)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.TransactionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transacti__Trans__190BB0C3");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transacti__UserI__17236851");
            });

            modelBuilder.Entity<TransactionQueue>(entity =>
            {
                entity.HasOne(d => d.RepeatTransaction)
                    .WithMany(p => p.TransactionQueues)
                    .HasForeignKey(d => d.RepeatTransactionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transacti__Repea__1EC48A19");
            });

            modelBuilder.Entity<TransactionType>(entity =>
            {
                entity.Property(e => e.Name).IsFixedLength();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Channel)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.ChannelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users__ChannelId__06ED0088");
            });

            modelBuilder.Entity<UserCategory>(entity =>
            {
                entity.HasKey(e => new { e.CategoryId, e.UserId })
                    .HasName("PK__UserCate__C871B6CF51B89677");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.UserCategoryCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserCateg__Categ__0F824689");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.UserCategoryParents)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK__UserCateg__Paren__125EB334");

                entity.HasOne(d => d.TransactionType)
                    .WithMany(p => p.UserCategories)
                    .HasForeignKey(d => d.TransactionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserCateg__Trans__116A8EFB");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserCategories)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserCateg__UserI__10766AC2");
            });

            modelBuilder.Entity<UserGroup>(entity =>
            {
                entity.HasOne(d => d.Group)
                    .WithMany()
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserGroup__Group__0BB1B5A5");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserGroup__UserI__0ABD916C");
            });

            modelBuilder.Entity<UserSetting>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserSett__1788CC4C4DE6BE6A");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.WeeklyStartDay).IsFixedLength();

                entity.HasOne(d => d.PrimaryCurrency)
                    .WithMany(p => p.UserSettingPrimaryCurrencies)
                    .HasForeignKey(d => d.PrimaryCurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserSetti__Prima__08D548FA");

                entity.HasOne(d => d.SecondaryCurrency)
                    .WithMany(p => p.UserSettingSecondaryCurrencies)
                    .HasForeignKey(d => d.SecondaryCurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserSetti__Secon__09C96D33");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.UserSetting)
                    .HasForeignKey<UserSetting>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserSetti__UserI__07E124C1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}