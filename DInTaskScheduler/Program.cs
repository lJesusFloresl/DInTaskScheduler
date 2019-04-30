using Autofac;
using Autofac.Extras.Quartz;
using DInTaskScheduler.Application.Jobs;
using DInTaskScheduler.Application.Services;
using DInTaskScheduler.Domain.Contracts;
using DInTaskScheduler.Domain.Contracts.Services;
using DInTaskScheduler.Infrastructure.AmbientContext;
using DInTaskScheduler.Infrastructure.DataContext;
using System;
using System.Collections.Specialized;

namespace DInTaskScheduler
{
    public class Program
    {
        private static IContainer Container { get; set; }

        public static void Main(string[] args)
        {
            RegisterDependencies(new ContainerBuilder());
            StartJobScheduler();
            StandByState();
        }

        #region Private methods

        /// <summary>
        /// Performs all registry for dependencies in application
        /// </summary>
        /// <param name="builder">Builder</param>
        /// <returns>IoC Container</returns>
        private static IContainer RegisterDependencies(ContainerBuilder builder)
        {
            AddContext(builder);
            AddRepositories(builder);
            AddServices(builder);
            AddAmbientContext(builder);
            AddScheduler(builder);
            Container = builder.Build();
            return Container;
        }

        /// <summary>
        /// Configure databases
        /// </summary>
        /// <param name="builder">Builder</param>
        private static void AddContext(ContainerBuilder builder)
        {
            builder.RegisterType<DInTaskSchedulerEntities>().AsSelf();
        }

        /// <summary>
        /// Configure repositories
        /// </summary>
        /// <param name="builder">Builder</param>
        private static void AddRepositories(ContainerBuilder builder)
        {
            //builder.RegisterType<JobExecutionService>().As<IJobExecutionService>();
        }

        /// <summary>
        /// Configure services
        /// </summary>
        /// <param name="builder">Builder</param>
        private static void AddServices(ContainerBuilder builder)
        {
            builder.RegisterType<JobExecutionService>().As<IJobExecutionService>();
        }

        /// <summary>
        /// Configure ambient context
        /// </summary>
        /// <param name="builder">Builder</param>
        private static void AddAmbientContext(ContainerBuilder builder)
        {
            builder.RegisterType<RepositoryAmbientContext>().AsSelf();
        }

        /// <summary>
        /// Configure scheduler
        /// </summary>
        /// <param name="builder">Builder</param>
        private static void AddScheduler(ContainerBuilder builder)
        {
            var schedulerConfig = new NameValueCollection {
                { "quartz.threadPool.threadCount", "3"},
                { "quartz.scheduler.threadName", "MyScheduler"}
            };

            builder.RegisterModule(new QuartzAutofacFactoryModule
            {
                ConfigurationProvider = c => schedulerConfig
            });

            AddJobs(builder);
            builder.RegisterType<JobScheduler>().AsSelf();
        }

        /// <summary>
        /// Configure jobs
        /// </summary>
        /// <param name="builder">Builder</param>
        private static void AddJobs(ContainerBuilder builder)
        {
            builder.RegisterModule(new QuartzAutofacJobsModule(typeof(JobAsyncExecutor).Assembly));
        } 

        /// <summary>
        /// Start job scheduler
        /// </summary>
        private static void StartJobScheduler()
        {
            var scheduler = Container.Resolve<JobScheduler>();
            scheduler.Start();
        }

        /// <summary>
        /// The program is on wait to esc key to exit
        /// </summary>
        private static void StandByState()
        {
            ConsoleKeyInfo keyConsole;
            Console.WriteLine("Service Status Active, press (Esc) key to quit...");
            do
            {
                keyConsole = Console.ReadKey();
            } while (keyConsole.Key != ConsoleKey.Escape);
        }

        #endregion
    }
}
