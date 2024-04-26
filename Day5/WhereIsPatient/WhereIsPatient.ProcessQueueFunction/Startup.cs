using System;
using System.Threading.Tasks;
using WhereIsPatient.DB;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

[assembly: FunctionsStartup(typeof(WhereIsPatient.ProcessQueueFunction.Startup))]

namespace WhereIsPatient.ProcessQueueFunction
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            string connectionString = Environment.GetEnvironmentVariable("SqlConnectionString");
            builder.Services.AddDbContext<WhereIsPatientContext>(
                options => SqlServerDbContextOptionsExtensions.UseSqlServer(options, connectionString));

            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
