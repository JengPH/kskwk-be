﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace olappApi.Entities;

public partial class OlappContext : DbContext
{
    public OlappContext()
    {
    }

    public OlappContext(DbContextOptions<OlappContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AppUser> AppUsers { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<DeductionCbu> DeductionCbus { get; set; }

    public virtual DbSet<DeductionInsurance> DeductionInsurances { get; set; }

    public virtual DbSet<Loan> Loans { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<Usertype> Usertypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=olapp;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.27-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<AppUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.ClientId)
                .HasColumnType("bigint(20)")
                .HasColumnName("clientId");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
            entity.Property(e => e.Usertype)
                .HasColumnType("int(11)")
                .HasColumnName("usertype");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Client");

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20)")
                .HasColumnName("id");
            entity.Property(e => e.AdditionalAddressInfo)
                .HasMaxLength(500)
                .HasColumnName("additionalAddressInfo");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .HasColumnName("address");
            entity.Property(e => e.Barangay)
                .HasMaxLength(20)
                .HasColumnName("barangay");
            entity.Property(e => e.Birthdate)
                .HasMaxLength(70)
                .HasColumnName("birthdate");
            entity.Property(e => e.City)
                .HasMaxLength(11)
                .HasColumnName("city");
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(20)
                .HasColumnName("contactNumber");
            entity.Property(e => e.Email)
                .HasMaxLength(70)
                .HasColumnName("email");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(100)
                .HasColumnName("emailAddress");
            entity.Property(e => e.Gender)
                .HasMaxLength(11)
                .HasColumnName("gender");
            entity.Property(e => e.Municipal)
                .HasMaxLength(20)
                .HasColumnName("municipal");
            entity.Property(e => e.Name)
                .HasMaxLength(70)
                .HasColumnName("name");
            entity.Property(e => e.Province)
                .HasMaxLength(20)
                .HasColumnName("province");
            entity.Property(e => e.Purok)
                .HasColumnType("int(11)")
                .HasColumnName("purok");
        });

        modelBuilder.Entity<DeductionCbu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("DeductionCBU");

            entity.Property(e => e.Id).HasColumnType("bigint(20)");
            entity.Property(e => e.DateAdded)
                .HasColumnType("datetime")
                .HasColumnName("dateAdded");
            entity.Property(e => e.DateSadded)
                .HasMaxLength(255)
                .HasColumnName("dateSAdded");
            entity.Property(e => e.LoanId)
                .HasColumnType("bigint(20)")
                .HasColumnName("loanId");
            entity.Property(e => e.TotalCbu)
                .HasPrecision(18, 2)
                .HasColumnName("totalCBU");
        });

        modelBuilder.Entity<DeductionInsurance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("DeductionInsurance");

            entity.Property(e => e.Id).HasColumnType("bigint(20)");
            entity.Property(e => e.DateAdded)
                .HasColumnType("datetime")
                .HasColumnName("dateAdded");
            entity.Property(e => e.DateSadded)
                .HasMaxLength(255)
                .HasColumnName("dateSAdded");
            entity.Property(e => e.LoanId)
                .HasColumnType("bigint(20)")
                .HasColumnName("loanId");
            entity.Property(e => e.TotalInsurance)
                .HasPrecision(18, 2)
                .HasColumnName("totalInsurance");
        });

        modelBuilder.Entity<Loan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Loan");

            entity.Property(e => e.Id).HasColumnType("bigint(20)");
            entity.Property(e => e.AddedInterest)
                .HasPrecision(18, 2)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("added_interest");
            entity.Property(e => e.Capital)
                .HasPrecision(18, 2)
                .HasColumnName("capital");
            entity.Property(e => e.ClientId)
                .HasColumnType("bigint(20)")
                .HasColumnName("client_id");
            entity.Property(e => e.DateTime)
                .HasColumnType("datetime")
                .HasColumnName("date_time");
            entity.Property(e => e.DeductCbu)
                .HasPrecision(18, 2)
                .HasColumnName("deductCBU");
            entity.Property(e => e.DeductInsurance)
                .HasPrecision(18, 2)
                .HasColumnName("deductInsurance");
            entity.Property(e => e.DueDate)
                .HasColumnType("datetime")
                .HasColumnName("due_Date");
            entity.Property(e => e.Interest)
                .HasPrecision(18, 2)
                .HasColumnName("interest");
            entity.Property(e => e.InterestedAmount)
                .HasPrecision(18, 2)
                .HasColumnName("interested_amount");
            entity.Property(e => e.LoanAmount)
                .HasPrecision(18, 2)
                .HasColumnName("loan_amount");
            entity.Property(e => e.LoanReceivable)
                .HasPrecision(18, 2)
                .HasColumnName("loan_receivable");
            entity.Property(e => e.NoPayment)
                .HasColumnType("int(11)")
                .HasColumnName("no_payment");
            entity.Property(e => e.OtherFee)
                .HasPrecision(18, 2)
                .HasColumnName("other_fee");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("status");
            entity.Property(e => e.TotalPenalty)
                .HasPrecision(18, 2)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("total_penalty");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Schedule");

            entity.Property(e => e.Id).HasColumnType("bigint(20)");
            entity.Property(e => e.Collectables)
                .HasPrecision(18, 2)
                .HasColumnName("collectables");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.LoanId)
                .HasColumnType("bigint(20)")
                .HasColumnName("loan_id");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("status");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransId).HasName("PRIMARY");

            entity.ToTable("Transaction");

            entity.Property(e => e.TransId)
                .HasColumnType("bigint(20)")
                .HasColumnName("trans_id");
            entity.Property(e => e.AddedBy)
                .HasMaxLength(255)
                .HasColumnName("added_by");
            entity.Property(e => e.Amount)
                .HasPrecision(18, 2)
                .HasColumnName("amount");
            entity.Property(e => e.ClientId)
                .HasColumnType("bigint(20)")
                .HasColumnName("client_id");
            entity.Property(e => e.LoanId)
                .HasColumnType("bigint(20)")
                .HasColumnName("loan_id");
            entity.Property(e => e.PaymentDate)
                .HasMaxLength(255)
                .HasColumnName("payment_date");
            entity.Property(e => e.ScheduleId)
                .HasColumnType("bigint(20)")
                .HasColumnName("schedule_id");
        });

        modelBuilder.Entity<Usertype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Usertype");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Type).HasMaxLength(10);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
