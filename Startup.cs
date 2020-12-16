using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormCalc.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

namespace FormCalc
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //string con = @"Server=.\MSSQLSERVER;Database=FormCalcDb;Trusted_Connection=True;";
            string con = "Data Source =.; Initial Catalog = Northwind; Integrated Security = True;";

            services.AddDbContext<OrderContext>(options => options.UseSqlServer(con));

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
