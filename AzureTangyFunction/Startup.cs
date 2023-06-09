using AzureTangyFunction;
using AzureTangyFunction.Data;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Configuring startup file, so that we can access the deep context using DI inside Azure Function
[assembly : WebJobsStartup(typeof(Startup))]
namespace AzureTangyFunction
{
    public class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {   

            // Get connection string of database
            string connectionString = Environment.GetEnvironmentVariable("AzureSqlDatabase");

            // Add DB context using Dependency Injection by accessing services of builder
            builder.Services.AddDbContext<AzureTangyDbContext>(options =>  options.UseSqlServer(connectionString));

            // Build service provider
            builder.Services.BuildServiceProvider();
        }
    }
}
