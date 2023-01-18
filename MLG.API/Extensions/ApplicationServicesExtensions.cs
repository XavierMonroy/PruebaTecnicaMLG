﻿using MLG.DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MLG.API.Interfaces;
using MLG.API.Repositories;

namespace MLG.API.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer(config.GetConnectionString("DBConnection"))
            );

            services.AddDbContext<AppDbContextForSP>(options =>
               options.UseSqlServer(config.GetConnectionString("DBConnection"))
            );
            
            //services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IArticleRepository, ArticleRepository>();

            return services;
        }
    }
}
