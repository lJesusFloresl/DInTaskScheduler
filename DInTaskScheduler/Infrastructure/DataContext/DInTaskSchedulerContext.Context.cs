﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DInTaskScheduler.Infrastructure.DataContext
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DInTaskSchedulerEntities : DbContext
    {
        public DInTaskSchedulerEntities()
            : base("name=DInTaskSchedulerEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Application> Application { get; set; }
        public virtual DbSet<ApplicationEnvironment> ApplicationEnvironment { get; set; }
        public virtual DbSet<Environment> Environment { get; set; }
        public virtual DbSet<Frequency> Frequency { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<JobNotification> JobNotification { get; set; }
        public virtual DbSet<JobParameter> JobParameter { get; set; }
        public virtual DbSet<ParameterType> ParameterType { get; set; }
        public virtual DbSet<PropertyType> PropertyType { get; set; }
        public virtual DbSet<RequestType> RequestType { get; set; }
        public virtual DbSet<Settings> Settings { get; set; }
        public virtual DbSet<SpecialFunction> SpecialFunction { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<JobExecution> JobExecution { get; set; }
    }
}
