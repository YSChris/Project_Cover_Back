using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Cover_WebApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Cover_WebApi.Models;

namespace Cover_WebApi
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
            services.AddCors(options =>
            {
                options.AddPolicy("admin",
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowCredentials()
                           .WithExposedHeaders("Access-Control-Allow-Origin: http://localhost:8080");
                });
            });
            services.AddMvc();
            var connection = @"Server=120.196.136.235;database=mclCoverSystem_Web_BAGX;User Id=sa;Password=maxt8899MAXT;";
            services.AddDbContext<Cover_Dbcontext>(options => options.UseSqlServer(connection));
            services.AddDbContext<WarningBill_Dbcontext>(options => options.UseSqlServer(connection));
            services.AddDbContext<BrokenBill_Dbcontext>(options => options.UseSqlServer(connection));
            services.AddDbContext<NormalBill_Dbcontext>(options => options.UseSqlServer(connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseStaticFiles();
                app.UseCors("admin");
            }

            app.UseMvc();
        }
    }
}
