using App.Domain.DBGeneratedModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Domain
{
    public static class DomainServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {


            services.AddDbContext<IntranetContext>(x => x.UseOracle(configuration.GetConnectionString("Db_Intranet"), options => options.UseOracleSQLCompatibility(OracleSQLCompatibility.DatabaseVersion19)));
            return services;
        }
    }
}
