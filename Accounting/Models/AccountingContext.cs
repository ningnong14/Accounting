using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Accounting.Models;

public partial class AccountingContext : DbContext
{
    public AccountingContext()
    {
    }

    public AccountingContext(DbContextOptions<AccountingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BillRecord> BillRecords { get; set; }

    public virtual DbSet<CodeDebit> CodeDebits { get; set; }

    public virtual DbSet<RecordAccounting> RecordAccountings { get; set; }

    public virtual DbSet<TagVoucher> TagVouchers { get; set; }

    public virtual DbSet<UserLogin> UserLogins { get; set; }

    public virtual DbSet<ViewTest> ViewTests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-PEG8U1S;Database=Accounting;Trusted_Connection=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BillRecord>(entity =>
        {
            entity.HasKey(e => e.BillId).HasName("PK_ACCOUNT_RECORD");

            entity.ToTable("BILL_RECORD");

            entity.Property(e => e.BillId).HasColumnName("BILL_ID");
            entity.Property(e => e.Credit).HasColumnName("CREDIT");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("DATE");
            entity.Property(e => e.Debit).HasColumnName("DEBIT");
            entity.Property(e => e.Description).HasColumnName("DESCRIPTION");
            entity.Property(e => e.MainAccount)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("MAIN_ACCOUNT");
            entity.Property(e => e.Voucher)
                .HasMaxLength(50)
                .HasColumnName("VOUCHER");
        });

        modelBuilder.Entity<CodeDebit>(entity =>
        {
            entity.ToTable("CODE_DEBIT");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("CODE");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("DATE");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("DESCRIPTION");
        });

        modelBuilder.Entity<RecordAccounting>(entity =>
        {
            entity.ToTable("RECORD_ACCOUNTING");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CodeVoucher)
                .HasMaxLength(50)
                .HasColumnName("CODE_VOUCHER");
            entity.Property(e => e.Credit).HasColumnName("CREDIT");
            entity.Property(e => e.DateTimeTo)
                .HasColumnType("date")
                .HasColumnName("DATE_TIME_TO");
            entity.Property(e => e.Debit).HasColumnName("DEBIT");
            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.MainAccount)
                .HasMaxLength(50)
                .HasColumnName("MAIN_ACCOUNT");
            entity.Property(e => e.TagVoucher).HasColumnName("TAG_VOUCHER");
        });

        modelBuilder.Entity<TagVoucher>(entity =>
        {
            entity.HasKey(e => e.TagVoucher1);

            entity.ToTable("TAG_VOUCHER");

            entity.Property(e => e.TagVoucher1).HasColumnName("TagVoucher");
            entity.Property(e => e.DateTime)
                .HasColumnType("date")
                .HasColumnName("dateTime");
        });

        modelBuilder.Entity<UserLogin>(entity =>
        {
            entity.HasKey(e => e.Username);

            entity.ToTable("USER_LOGIN");

            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("USERNAME");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.FirstLogin)
                .HasColumnType("datetime")
                .HasColumnName("FIRST_LOGIN");
            entity.Property(e => e.LastLogin)
                .HasColumnType("datetime")
                .HasColumnName("LAST_LOGIN");
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("UPDATE_DATE");
        });

        modelBuilder.Entity<ViewTest>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_test");

            entity.Property(e => e.BillId)
                .ValueGeneratedOnAdd()
                .HasColumnName("BILL_ID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
