using Kevin.API.Contract.Interfaces;
using Kevin.API.Models;
using Kevin.API.Services;
using Microsoft.EntityFrameworkCore;

namespace Kevin.API.DependencyResolution
{
    public static class DependencyInjectionRegistry
    {

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            //Register the services
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            return services;
        }

        public static void AddPersistence(this IServiceCollection services, WebApplicationBuilder builder)
        {
            //using connection string in Azure Key Vault
            //var AzureKeyVault = builder.Configuration["AzureKeyVault"];
            //var secretsClient = new SecretClient(new Uri(AzureKeyVault), new DefaultAzureCredential());
            //string connectionString = secretsClient.GetSecret("mentoring-keyvault-connectionstring").Value.Value.ToString();

            //Using connection string local
            string connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
            builder.Services.AddDbContext<DbemployeeContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }

    }
}
