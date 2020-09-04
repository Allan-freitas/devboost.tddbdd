﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace devboost.dronedelivery.Config
{
    public static class JwtConfig
    {
        public static void AddJwtconfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var _jwtKey = "#tUKIkgfFbk¨#(*¨&&*OIUOIljkkjghkTYUXP*&#WAPORTEVJHG@+$#^ÇKhkljhkljdcyjgh*(&nbkluhjvjv3Vcvdi";
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(_jwtKey)//configuration["jwt:key"])
                    ),
                    ClockSkew = TimeSpan.Zero
                };
            });
        }
    }
}
