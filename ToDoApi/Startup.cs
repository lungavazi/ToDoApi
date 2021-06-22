using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ToDoApi.Context;
using ToDoApi.Controllers;
using ToDoApi.Services;

namespace ToDoApi
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new Exception(nameof(configuration));
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddMvcOptions(o =>//Add XML out-put format
            {
                o.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
            });

            var connectionString = _configuration["ConnectionStrings:TodoDatabse"];
            services.AddDbContext<ToDoContext>(o =>
            {
                o.UseSqlServer(connectionString);
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = "{https://localhost:44337}";
                //options.Audience = "{}";
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "jwtBearer";
                options.DefaultChallengeScheme = "jwtBearer";
            }).AddJwtBearer("jwtBearer", jwtOptions =>
            {
                jwtOptions.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = TokenController.SIGNING_KEY,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(5)
                };
            });

            services.AddScoped<ITodoRepository, TodoRepository>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseAuthentication();
            app.UseStatusCodePages();
            app.UseMvc();
            app.UseHttpsRedirection();
        }
    }
}
