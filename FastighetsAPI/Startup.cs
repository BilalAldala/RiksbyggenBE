using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using FastighetsAPI.Data;

[assembly: FunctionsStartup(typeof(FastighetsAPI.Startup))]

namespace FastighetsAPI
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var config = builder.GetContext().Configuration;
            var connectionString = config["DatabaseConnection"];

            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddTransient<ICompanyService, CompanyService>();
            builder.Services.AddTransient<IApartmentService, ApartmentService>();
        }
    }
}
