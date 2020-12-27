using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebApiWithAspnetCore31.Data;
using WebApiWithAspnetCore31.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebApiWithAspnetCore31
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
            // Add CORS policy
            services.AddCors(options =>
            {
                options.AddPolicy("someName",
                builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });

            services.AddControllers();

            // built-in dependency injection
            // services.AddScoped<IProduct, ProductRepository>(); // net core 2.0

            // net core 3.1           
            services.Add(new ServiceDescriptor(typeof(IProduct), typeof(ProductRepository), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IProductService), typeof(ProductService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IAuthRepository), typeof(AuthRepository), ServiceLifetime.Scoped));
            services.AddAutoMapper(typeof(AuthRepository).Assembly);

            // entiry framework connection string            
            var connString = Configuration.GetConnectionString("ProductDbContext");
            services.AddDbContext<ProductDbContext>(option => option.UseSqlServer(connString));

            // it interacts with [Authorize] or [AllowAnonymous]...
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    //options.Audience = "8d708afe-2966-40b7-918c-a39551625958";
                    //options.Authority = "https://login.microsoftonline.com/a1d50521-9687-4e4d-a76d-ddd53ab0c668/";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                            .GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                       
                    };
                });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) // development
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            app.UseCors("someName");

            app.UseAuthentication();

            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
