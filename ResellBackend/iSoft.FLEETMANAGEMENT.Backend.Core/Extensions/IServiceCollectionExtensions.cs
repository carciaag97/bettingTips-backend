using Autofac.Core;
using iSoft.FLEETMANAGEMENT.Backend.Core.Database.Context;
using iSoft.FLEETMANAGEMENT.Backend.Core.Handlers;
using iSoft.FLEETMANAGEMENT.Backend.Core.UnitOfWork;
using iSoft.FLEETMANAGEMENT.Backend.Infrastructure.Config;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ResellBackendCore.Repositories;
using ResellBackendCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.FLEETMANAGEMENT.Backend.Core.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddDbContext(this IServiceCollection services)
        {
            services.AddDbContext<ResellDbContext>();
            services.AddDbContext<DbContext>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<CategoryRepository>();
            services.AddScoped<MatchRepository>();
            services.AddScoped<NewsRepository>();
            services.AddScoped<StatisticsRepository>();
            services.AddScoped<TeamRepository>();
            services.AddScoped<TicketRepository>();
            services.AddScoped<UserRepository>();
            services.AddScoped<TicketMatchRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<EfUnitOfWork>();
            services.AddScoped<AuthTokenHandler>();
            services.AddScoped<CategoryService>();
            services.AddScoped<MatchService>();
            services.AddScoped<NewsService>();
            services.AddScoped<StatisticsService>();
            services.AddScoped<TeamService>();
            services.AddScoped<TicketService>();
            services.AddScoped<UserService>();
            services.AddScoped<TicketMatchService>();

        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme (bearer {token})",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            In = ParameterLocation.Header,
                        }, new List<string>()
                    }
                });


            });
        }

        public static void ConfigureAuthorization(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(
                           Encoding.UTF8.GetBytes(AppConfig.JwtConfiguration.SecretKey)),
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ValidAudience = AppConfig.JwtConfiguration.Audience,
                       ValidIssuer = AppConfig.JwtConfiguration.Issuer,
                       ClockSkew = TimeSpan.Zero
                   };
               });
        }

    

    }
}
