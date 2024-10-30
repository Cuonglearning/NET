using System;
using System.Collections.Generic;

namespace BankDB.Models;

public partial class BankDBContext : DbContext
{
    public BankDBContext()
    {
    }

    public BankDBContext(DbContextOptions<BankDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Branch> Branches { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-URLHVQT\\SQLEXPRESS;Database=BankDB;User Id=nhat;Password=Nhat123456789;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ACCOUNT__3213E83FBD59179E");

            entity.ToTable("ACCOUNT");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("id");
            entity.Property(e => e.Balance).HasColumnName("balance");
            entity.Property(e => e.Customerid)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("customerid");
            entity.Property(e => e.DateOpened).HasColumnName("date_opened");

            entity.HasOne(d => d.Customer).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.Customerid)
                .HasConstraintName("FK__ACCOUNT__custome__398D8EEE");
        });

        modelBuilder.Entity<Branch>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BRANCH__3213E83F192C3503");

            entity.ToTable("BRANCH");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.HouseNo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("house_no");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CUSTOMER__3213E83F280FFDFD");

            entity.ToTable("CUSTOMER", tb => tb.HasTrigger("tr_SetSmallestCustomerID"));

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.HouseNo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("house_no");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Pin)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("pin");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EMPLOYEE__3213E83FBBD91749");

            entity.ToTable("EMPLOYEE", tb => tb.HasTrigger("tr_SetSmallestEmployeeID"));

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Role)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("role");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TRANSACT__3213E83FFA54A450");

            entity.ToTable("TRANSACTIONS");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.BranchId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("branch_id");
            entity.Property(e => e.DateOfTrans).HasColumnName("date_of_trans");
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("employee_id");
            entity.Property(e => e.FromAccountId)
                .HasMaxLength(50)
                .HasColumnName("from_account_id");
            entity.Property(e => e.Pin)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("pin");
            entity.Property(e => e.ToAccountId)
                .HasMaxLength(50)
                .HasColumnName("to_account_id");

            entity.HasOne(d => d.Branch).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_branch");

            entity.HasOne(d => d.Employee).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_employee");

            entity.HasOne(d => d.FromAccount).WithMany(p => p.TransactionFromAccounts)
                .HasForeignKey(d => d.FromAccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_from_account");

            entity.HasOne(d => d.ToAccount).WithMany(p => p.TransactionToAccounts)
                .HasForeignKey(d => d.ToAccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_to_account");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
