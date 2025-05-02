using System;
using System.Collections.Generic;
using HRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HRM.Persistence.Contexts;

public partial class HRMDbContext : DbContext
{
    public HRMDbContext()
    {
    }

    public HRMDbContext(DbContextOptions<HRMDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<CalendarEvent> CalendarEvents { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeTransfer> EmployeeTransfers { get; set; }

    public virtual DbSet<LeaveRequest> LeaveRequests { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Salary> Salaries { get; set; }

    public virtual DbSet<SystemLog> SystemLogs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=HRMSystem;User Id=sa;Password=12345;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Attendan__3214EC075B2B075B");

            entity.HasOne(d => d.Employee).WithMany(p => p.Attendances)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Attendanc__Emplo__5FB337D6");
        });

        modelBuilder.Entity<CalendarEvent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Calendar__3214EC070955C2B5");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsAllDay).HasDefaultValue(false);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.CalendarEvents)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CalendarE__Creat__4CA06362");
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contract__3214EC077159A5B5");

            entity.HasOne(d => d.Employee).WithMany(p => p.Contracts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Contracts__Emplo__59FA5E80");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Departme__3214EC07B4337F78");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC074FA1379E");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees).HasConstraintName("FK__Employees__Depar__4F7CD00D");

            entity.HasOne(d => d.Position).WithMany(p => p.Employees).HasConstraintName("FK__Employees__Posit__5070F446");
        });

        modelBuilder.Entity<EmployeeTransfer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC0764A63D7E");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeTransfers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EmployeeT__Emplo__534D60F1");

            entity.HasOne(d => d.FromDepartment).WithMany(p => p.EmployeeTransferFromDepartments).HasConstraintName("FK__EmployeeT__FromD__5441852A");

            entity.HasOne(d => d.FromPosition).WithMany(p => p.EmployeeTransferFromPositions).HasConstraintName("FK__EmployeeT__FromP__5629CD9C");

            entity.HasOne(d => d.ToDepartment).WithMany(p => p.EmployeeTransferToDepartments).HasConstraintName("FK__EmployeeT__ToDep__5535A963");

            entity.HasOne(d => d.ToPosition).WithMany(p => p.EmployeeTransferToPositions).HasConstraintName("FK__EmployeeT__ToPos__571DF1D5");
        });

        modelBuilder.Entity<LeaveRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LeaveReq__3214EC07685517F8");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status).HasDefaultValue("Pending");

            entity.HasOne(d => d.Employee).WithMany(p => p.LeaveRequests)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LeaveRequ__Emplo__6477ECF3");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Notifica__3214EC071CED3E79");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Notifications).HasConstraintName("FK__Notificat__Creat__68487DD7");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Position__3214EC079A3EEBCF");
        });

        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RefreshT__3214EC07D75534BD");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasComputedColumnSql("(case when [RevokedAt] IS NULL AND [ExpiresAt]>getdate() then (1) else (0) end)", false);

            entity.HasOne(d => d.User).WithMany(p => p.RefreshTokens)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RefreshTo__UserI__3D5E1FD2");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC0760C4EEE2");
        });

        modelBuilder.Entity<Salary>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Salaries__3214EC079C95FCC6");

            entity.HasOne(d => d.Employee).WithMany(p => p.Salaries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Salaries__Employ__5CD6CB2B");
        });

        modelBuilder.Entity<SystemLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SystemLo__3214EC079DD6F55F");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.User).WithMany(p => p.SystemLogs).HasConstraintName("FK__SystemLog__UserI__6C190EBB");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC0718A96A0C");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRole",
                    r => r.HasOne<Role>().WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__UserRoles__RoleI__440B1D61"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__UserRoles__UserI__4316F928"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId").HasName("PK__UserRole__AF2760AD070568FD");
                        j.ToTable("UserRoles");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
