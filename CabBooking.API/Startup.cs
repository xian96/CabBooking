using CabBooking.Core.Entities;
using CabBooking.Core.RepositoryInterfaces;
using CabBooking.Core.ServiceInterfaces;
using CabBooking.Infrastructure.Repositories;
using CabBooking.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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

namespace CabBooking.API
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CabBooking.API", Version = "v1" });
            });

            //adding the database connection
            services.AddDbContext<Infrastructure.Data.CabBookingDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString(("CabBookingDbConnection"))));

            //denpendency injection specify at here
            services.AddScoped<ICabTypeService, CabTypeService>();
            services.AddScoped<ICabTypeRepository, CabTypeRepository>();
            services.AddScoped<IPlaceService, PlaceService>();
            services.AddScoped<IPlaceRepository, PlaceRepository>();
            services.AddScoped<IBookingService , BookingService>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IBookingHistoryService, BookingHistoryService>();
            services.AddScoped<IBookingHistoryRepository, BookingHistoryRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CabBooking.API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
