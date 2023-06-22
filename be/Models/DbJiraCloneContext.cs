using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace be.Models;

public partial class DbJiraCloneContext : DbContext
{
    public DbJiraCloneContext()
    {
    }

    public DbJiraCloneContext(DbContextOptions<DbJiraCloneContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CauseCategory> CauseCategories { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Component> Components { get; set; }

    public virtual DbSet<DefectOrigin> DefectOrigins { get; set; }

    public virtual DbSet<DefectType> DefectTypes { get; set; }

    public virtual DbSet<FileAttachment> FileAttachments { get; set; }

    public virtual DbSet<History> Histories { get; set; }

    public virtual DbSet<Issue> Issues { get; set; }

    public virtual DbSet<IssueType> IssueTypes { get; set; }

    public virtual DbSet<LeakCause> LeakCauses { get; set; }

    public virtual DbSet<Priority> Priorities { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Qcactivity> Qcactivities { get; set; }

    public virtual DbSet<Resolution> Resolutions { get; set; }

    public virtual DbSet<RoleIssue> RoleIssues { get; set; }

    public virtual DbSet<RoleUser> RoleUsers { get; set; }

    public virtual DbSet<StatusIssue> StatusIssues { get; set; }

    public virtual DbSet<TechnicalCause> TechnicalCauses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=Admin;Initial Catalog=dbJiraClone;Integrated Security=True;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CauseCategory>(entity =>
        {
            entity.ToTable("CauseCategory");

            entity.Property(e => e.CauseCategoryName)
                .HasMaxLength(55)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.ToTable("Comment");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Issue).WithMany(p => p.Comments)
                .HasForeignKey(d => d.IssueId)
                .HasConstraintName("FK_Comment_Issue");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Comment_User");
        });

        modelBuilder.Entity<Component>(entity =>
        {
            entity.ToTable("Component");

            entity.Property(e => e.ComponentName).HasMaxLength(255);
        });

        modelBuilder.Entity<DefectOrigin>(entity =>
        {
            entity.ToTable("DefectOrigin");

            entity.Property(e => e.DefectOriginName)
                .HasMaxLength(55)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DefectType>(entity =>
        {
            entity.ToTable("DefectType");

            entity.Property(e => e.DefectTypeName)
                .HasMaxLength(55)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FileAttachment>(entity =>
        {
            entity.ToTable("FileAttachment");

            entity.Property(e => e.Created).HasColumnType("date");
            entity.Property(e => e.FileName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FilePath).IsUnicode(false);

            entity.HasOne(d => d.Issue).WithMany(p => p.FileAttachments)
                .HasForeignKey(d => d.IssueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FileAttachment_Issue");
        });

        modelBuilder.Entity<History>(entity =>
        {
            entity.ToTable("History");

            entity.Property(e => e.AdjustVp)
                .HasMaxLength(55)
                .IsUnicode(false)
                .HasColumnName("AdjustVP");
            entity.Property(e => e.AffectsVersion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ClosedDate).HasColumnType("date");
            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DueDate).HasColumnType("date");
            entity.Property(e => e.DueTime)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.EpicLink)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.EstimateEffort)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.FixVersion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FunctionCategory)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.FunctionId)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.Issue)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.Labels)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.OriginalEstimate)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.PercentDone)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.PlannedStart).HasColumnType("datetime");
            entity.Property(e => e.QcactivityId).HasColumnName("QCActivityId");
            entity.Property(e => e.RemainingEstimate)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.Resolution)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SecurityLevel)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.Severity)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.Sprint)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.Summary).HasMaxLength(255);
            entity.Property(e => e.TestcaseId)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.Units)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ValuePoint)
                .HasMaxLength(55)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Issue>(entity =>
        {
            entity.ToTable("Issue");

            entity.Property(e => e.AdjustedVp)
                .HasMaxLength(55)
                .IsUnicode(false)
                .HasColumnName("AdjustedVP");
            entity.Property(e => e.AffectsVersion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ClosedDate).HasColumnType("date");
            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DueDate).HasColumnType("date");
            entity.Property(e => e.DueTime)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.EpicLink)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.EstimateEffort)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.FixVersion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FunctionCategory)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.FunctionId)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.Issue1)
                .HasMaxLength(55)
                .IsUnicode(false)
                .HasColumnName("Issue");
            entity.Property(e => e.Labels)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.OriginalEstimate)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.PercentDone)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.PlannedStart).HasColumnType("datetime");
            entity.Property(e => e.QcactivityId).HasColumnName("QCActivityId");
            entity.Property(e => e.RemaningEstimate)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.Resolution)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SecurityLevel)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.Severity)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.Sprint)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.Summary).HasMaxLength(255);
            entity.Property(e => e.TestcaseId)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.Units)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ValuePoint)
                .HasMaxLength(55)
                .IsUnicode(false);

            entity.HasOne(d => d.Assignee).WithMany(p => p.IssueAssignees)
                .HasForeignKey(d => d.AssigneeId)
                .HasConstraintName("FK_Issue_User1");

            entity.HasOne(d => d.CauseCategory).WithMany(p => p.Issues)
                .HasForeignKey(d => d.CauseCategoryId)
                .HasConstraintName("FK_Issue_CauseCategory");

            entity.HasOne(d => d.Component).WithMany(p => p.Issues)
                .HasForeignKey(d => d.ComponentId)
                .HasConstraintName("FK_Issue_Component");

            entity.HasOne(d => d.DefectOrigin).WithMany(p => p.Issues)
                .HasForeignKey(d => d.DefectOriginId)
                .HasConstraintName("FK_Issue_DefectOrigin");

            entity.HasOne(d => d.DefectType).WithMany(p => p.Issues)
                .HasForeignKey(d => d.DefectTypeId)
                .HasConstraintName("FK_Issue_DefectType");

            entity.HasOne(d => d.IssueType).WithMany(p => p.Issues)
                .HasForeignKey(d => d.IssueTypeId)
                .HasConstraintName("FK_Issue_IssueType");

            entity.HasOne(d => d.LeakCause).WithMany(p => p.Issues)
                .HasForeignKey(d => d.LeakCauseId)
                .HasConstraintName("FK_Issue_LeakCause");

            entity.HasOne(d => d.Priority).WithMany(p => p.Issues)
                .HasForeignKey(d => d.PriorityId)
                .HasConstraintName("FK_Issue_Priority");

            entity.HasOne(d => d.Project).WithMany(p => p.Issues)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK_Issue_Project");

            entity.HasOne(d => d.Qcactivity).WithMany(p => p.Issues)
                .HasForeignKey(d => d.QcactivityId)
                .HasConstraintName("FK_Issue_QCActivity");

            entity.HasOne(d => d.Reporter).WithMany(p => p.IssueReporters)
                .HasForeignKey(d => d.ReporterId)
                .HasConstraintName("FK_Issue_User");

            entity.HasOne(d => d.RoleIssue).WithMany(p => p.Issues)
                .HasForeignKey(d => d.RoleIssueId)
                .HasConstraintName("FK_Issue_RoleIssue");

            entity.HasOne(d => d.StatusIssue).WithMany(p => p.Issues)
                .HasForeignKey(d => d.StatusIssueId)
                .HasConstraintName("FK_Issue_StatusIssue");

            entity.HasOne(d => d.TechnicalCause).WithMany(p => p.Issues)
                .HasForeignKey(d => d.TechnicalCauseId)
                .HasConstraintName("FK_Issue_TechnicalCause");
        });

        modelBuilder.Entity<IssueType>(entity =>
        {
            entity.ToTable("IssueType");

            entity.Property(e => e.IssueTypeImage).IsUnicode(false);
            entity.Property(e => e.IssueTypeName).HasMaxLength(255);
        });

        modelBuilder.Entity<LeakCause>(entity =>
        {
            entity.ToTable("LeakCause");

            entity.Property(e => e.LeakCauseName)
                .HasMaxLength(55)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Priority>(entity =>
        {
            entity.ToTable("Priority");

            entity.Property(e => e.PriorityImage).IsUnicode(false);
            entity.Property(e => e.PriorityName)
                .HasMaxLength(55)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.ProductName).HasMaxLength(255);
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.ToTable("Project");

            entity.Property(e => e.ProjectName).HasMaxLength(255);
            entity.Property(e => e.ShortName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Qcactivity>(entity =>
        {
            entity.ToTable("QCActivity");

            entity.Property(e => e.QcactivityId).HasColumnName("QCActivityId");
            entity.Property(e => e.QcactivityName)
                .HasMaxLength(55)
                .IsUnicode(false)
                .HasColumnName("QCActivityName");
        });

        modelBuilder.Entity<Resolution>(entity =>
        {
            entity.ToTable("Resolution");

            entity.Property(e => e.ResolutionContent)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.StatusIssue).WithMany(p => p.Resolutions)
                .HasForeignKey(d => d.StatusIssueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Resolution_StatusIssue");
        });

        modelBuilder.Entity<RoleIssue>(entity =>
        {
            entity.ToTable("RoleIssue");

            entity.Property(e => e.RoleIssueName)
                .HasMaxLength(55)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RoleUser>(entity =>
        {
            entity.HasKey(e => e.RoleId);

            entity.ToTable("RoleUser");

            entity.Property(e => e.RoleName)
                .HasMaxLength(55)
                .IsUnicode(false);
        });

        modelBuilder.Entity<StatusIssue>(entity =>
        {
            entity.ToTable("StatusIssue");

            entity.Property(e => e.StatusIssueName)
                .HasMaxLength(55)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TechnicalCause>(entity =>
        {
            entity.ToTable("TechnicalCause");

            entity.Property(e => e.TechnicalCauseName)
                .HasMaxLength(55)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.AccountName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Birthday).HasColumnType("date");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FullName).HasMaxLength(255);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_User_RoleUser");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
