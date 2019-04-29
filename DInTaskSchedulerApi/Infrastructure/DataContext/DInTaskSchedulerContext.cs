using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DInTaskSchedulerApi.Infrastructure.DataContext
{
    public partial class DInTaskSchedulerContext : DbContext
    {
        public DInTaskSchedulerContext()
        {
        }

        public DInTaskSchedulerContext(DbContextOptions<DInTaskSchedulerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Application> Application { get; set; }
        public virtual DbSet<ApplicationEnvironment> ApplicationEnvironment { get; set; }
        public virtual DbSet<Environment> Environment { get; set; }
        public virtual DbSet<Frequency> Frequency { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<JobExecution> JobExecution { get; set; }
        public virtual DbSet<JobNotification> JobNotification { get; set; }
        public virtual DbSet<JobParameter> JobParameter { get; set; }
        public virtual DbSet<ParameterType> ParameterType { get; set; }
        public virtual DbSet<PropertyType> PropertyType { get; set; }
        public virtual DbSet<RequestType> RequestType { get; set; }
        public virtual DbSet<Settings> Settings { get; set; }
        public virtual DbSet<SpecialFunction> SpecialFunction { get; set; }
        public virtual DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.Application)
                    .HasForeignKey(d => d.IdStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Application_Status");
            });

            modelBuilder.Entity<ApplicationEnvironment>(entity =>
            {
                entity.Property(e => e.ApiKey)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EndpointUrlBase)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.EndpointUrlInfo).HasMaxLength(500);

                entity.Property(e => e.SecretKey)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdApplicationNavigation)
                    .WithMany(p => p.ApplicationEnvironment)
                    .HasForeignKey(d => d.IdApplication)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApplicationEnvironment_Application");

                entity.HasOne(d => d.IdEnvironmentNavigation)
                    .WithMany(p => p.ApplicationEnvironment)
                    .HasForeignKey(d => d.IdEnvironment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApplicationEnvironment_Environment");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.ApplicationEnvironment)
                    .HasForeignKey(d => d.IdStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApplicationEnvironment_Status");
            });

            modelBuilder.Entity<Environment>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Frequency>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(300);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Endpoint)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdApplicationEnvironmentNavigation)
                    .WithMany(p => p.Job)
                    .HasForeignKey(d => d.IdApplicationEnvironment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Job_ApplicationEnvironment");

                entity.HasOne(d => d.IdFrequencyNavigation)
                    .WithMany(p => p.Job)
                    .HasForeignKey(d => d.IdFrequency)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Job_Frequency");

                entity.HasOne(d => d.IdRequestTypeNavigation)
                    .WithMany(p => p.Job)
                    .HasForeignKey(d => d.IdRequestType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Job_RequestType");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.Job)
                    .HasForeignKey(d => d.IdStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Job_Status");
            });

            modelBuilder.Entity<JobExecution>(entity =>
            {
                entity.Property(e => e.EndDateTime).HasColumnType("datetime");

                entity.Property(e => e.ExecutionDateTime).HasColumnType("datetime");

                entity.Property(e => e.InitDateTime).HasColumnType("datetime");

                entity.Property(e => e.UrlEndpoint).HasMaxLength(300);

                entity.HasOne(d => d.IdJobNavigation)
                    .WithMany(p => p.JobExecution)
                    .HasForeignKey(d => d.IdJob)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JobExecution_Job");
            });

            modelBuilder.Entity<JobNotification>(entity =>
            {
                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.IdJobNavigation)
                    .WithMany(p => p.JobNotification)
                    .HasForeignKey(d => d.IdJob)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JobNotification_Job");
            });

            modelBuilder.Entity<JobParameter>(entity =>
            {
                entity.Property(e => e.PropertyName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Value).HasMaxLength(100);

                entity.HasOne(d => d.IdJobNavigation)
                    .WithMany(p => p.JobParameter)
                    .HasForeignKey(d => d.IdJob)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JobParameter_Job");

                entity.HasOne(d => d.IdParameterTypeNavigation)
                    .WithMany(p => p.JobParameter)
                    .HasForeignKey(d => d.IdParameterType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JobParameter_ParameterType");

                entity.HasOne(d => d.IdPropertyTypeNavigation)
                    .WithMany(p => p.JobParameter)
                    .HasForeignKey(d => d.IdPropertyType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JobParameter_PropertyType");

                entity.HasOne(d => d.IdSpecialFunctionNavigation)
                    .WithMany(p => p.JobParameter)
                    .HasForeignKey(d => d.IdSpecialFunction)
                    .HasConstraintName("FK_JobParameter_SpecialFunction");
            });

            modelBuilder.Entity<ParameterType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PropertyType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<RequestType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Settings>(entity =>
            {
                entity.Property(e => e.ApiKey)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ApplicationName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SecretKey)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Version).HasMaxLength(10);
            });

            modelBuilder.Entity<SpecialFunction>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
