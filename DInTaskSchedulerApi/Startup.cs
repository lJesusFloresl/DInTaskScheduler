using System.Collections.Generic;
using System.Reflection;
using System.Text;
using DInTaskSchedulerApi.Application.Configurations;
using DInTaskSchedulerApi.Application.Services;
using DInTaskSchedulerApi.Domain.Contracts.Repositories;
using DInTaskSchedulerApi.Domain.Contracts.Services;
using DInTaskSchedulerApi.Infrastructure.DataContext;
using DInTaskSchedulerApi.Infrastructure.Repositories;
using DInTaskSchedulerApi.Tools;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;

namespace DInTaskSchedulerApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container. 
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            #region Mvc Settings

            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            #endregion

            #region Swagger Settings

            services.AddSwaggerGen(swagger =>
            {
                var contact = new Contact() { Name = SwaggerConfig.ContactName };
                swagger.SwaggerDoc(SwaggerConfig.ApiVersion, new Info
                {
                    Title = SwaggerConfig.DocInfoTitle,
                    Version = SwaggerConfig.ApiVersion,
                    Description = SwaggerConfig.DocInfoDescription,
                    Contact = contact
                });

                var security = new Dictionary<string, IEnumerable<string>> { { SwaggerConfig.JwtAuthentication, new string[] { } } };
                swagger.AddSecurityDefinition(SwaggerConfig.JwtAuthentication, new ApiKeyScheme
                {
                    Description = SwaggerConfig.JwtDescrption,
                    Name = SwaggerConfig.JwtName,
                    In = SwaggerConfig.JwtIn,
                    Type = SwaggerConfig.JwtType
                });

                swagger.AddSecurityRequirement(security);
            });

            #endregion

            #region Authentication Settings

            var secret = Configuration["TokenSettings:Secret"];
            var key = Encoding.ASCII.GetBytes(secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            #endregion

            #region Dependency Injection

            AddContext(services);
            AddRepositories(services);
            AddServices(services);
            AddAmbientContext(services);

            #endregion
        }

        /// <summary>
        /// Add all databases to service collection
        /// </summary>
        private void AddContext(IServiceCollection services)
        {
            services.AddDbContext<DInTaskSchedulerContext>(options => options.UseSqlServer(Configuration.GetString("ConnectionStrings:DInTaskScheduler")));
        }

        /// <summary>
        /// Add all repository classes to service collection
        /// </summary>
        private void AddRepositories(IServiceCollection services)
        {
            services.AddTransient<IStatusRepository, StatusRepository>();
            services.AddTransient<IEnvironmentRepository, EnvironmentRepository>();
            services.AddTransient<IApplicationRepository, ApplicationRepository>();
            services.AddTransient<IFrequencyRepository, FrequencyRepository>();
        }

        /// <summary>
        /// Add all service classes to service collection
        /// </summary>
        private void AddServices(IServiceCollection services)
        {
            services.AddTransient<IStatusService, StatusService>();
            services.AddTransient<IEnvironmentService, EnvironmentService>();
            services.AddTransient<IApplicationService, ApplicationService>();
            services.AddTransient<IFrequencyService, FrequencyService>();
        }

        /// <summary>
        /// Add all ambient context classes to service collection
        /// </summary>
        private void AddAmbientContext(IServiceCollection services)
        {
            //services.AddTransient<AmbientContextRepository>();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Enable swagger.
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(SwaggerConfig.GetEndpointUrl(), SwaggerConfig.DocInfoTitle);
                c.IndexStream = () => GetType().GetTypeInfo().Assembly.GetManifestResourceStream("DInTaskSchedulerApi.Application.Configurations.swagger-ui-custom.html");
            });

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            // Enable CORS (Cross Origin Resource Sharing)
            app.UseCors(builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());

            // Enable JWT (Json Web Token) authentication
            app.UseAuthentication();

            // Enable Mvc
            app.UseMvc();
        }
    }
}
