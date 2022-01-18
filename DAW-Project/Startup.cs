using DAW_Project.Data;
using DAW_Project.Repositories.BugRepository;
using DAW_Project.Repositories.ProjectRepository;
using DAW_Project.Repositories.UserRepository;
using DAW_Project.Repositories.VersionRepository;
using DAW_Project.Services;
using DAW_Project.Services.BugService;
using DAW_Project.Services.ProjectService;
using DAW_Project.Services.VersionService;
using DAW_Project.Utilities;
using DAW_Project.Utilities.JWTUtils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Project
{
    public class Startup
    {
        private readonly string CorsAllowSpecificOrigin = "frontendAllowOrigin";
     
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DAW_Project", Version = "v1" });
            });

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddScoped<IJWTUtils, JWTUtils>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IVersionService, VersionService>();
            services.AddScoped<IBugService, BugService>();

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<DawProjectContext>(options =>
                options.UseSqlServer(connectionString));

            // var builder = new DawProjectContext()
            // Created each time they are requested
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IProjectRepository, ProjectRepository>();
            services.AddTransient<IVersionRepository, VersionRepository>();
            services.AddTransient<IBugRepository, BugRepository>();

            services.AddCors(option =>
            {
                option.AddPolicy(name: CorsAllowSpecificOrigin,
                                builder =>
                                {
                                    builder.WithOrigins("https://localhost:4200", "https://localhost:4201")
                                    .AllowAnyHeader()
                                    .AllowAnyMethod()
                                    .AllowCredentials();
                                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DAW_Project v1"));
            }

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseMiddleware<JWTMiddleWare>();

            // setting for allowing another origin to make request  to our server
            app.UseCors(CorsAllowSpecificOrigin);
        }
    }
}
