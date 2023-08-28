using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PUNX.DataAccess.Context;
using PUNX.DataAccess.Implementation;
using PUNX.DataAccess.Implementation.Authentication;
using PUNX.Domain.Repository;
using PUNX.Domain.Repository.Authentication;
using Serilog;
using System;
using System.Text;

namespace PUNX.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Connexion With MySql
            services.AddDbContextPool<PunxDbContext>(
                   options => options.UseMySql(
                       Configuration.GetConnectionString("PunxConnection")
                       //new MySqlServerVersion(new Version(10, 4, 28))
                   ));

            services.AddControllers();

            // Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PUNX.API", Version = "v1" });
            });

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            // Mapper Conf
            services.AddAutoMapper(typeof(Startup).Assembly);
            // Jwt
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            // Token configuration
           .AddJwtBearer(options => {
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = false,
                   ValidateAudience = false,
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
               };
           });
            services.AddTransient<IJwtAuthenticationService, JwtAuthenticationService>();

            // Authorize React app
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("http://localhost:3000")
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            // Log file path
            Log.Logger = new LoggerConfiguration()
            .WriteTo.File("C:\\logs\\log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

            // Log Conf
            services.AddLogging(builder =>
            {
                builder.AddConsole(); // Adds logging to the console
                builder.AddDebug();   // Adds debugging output
                builder.AddSerilog(); // Add Serilog to the logging pipeline
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PUNX.API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
