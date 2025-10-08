using eCommerce.Core.RepositoryContracts;
using eCommerce.InfraStructure.DbContext;
using eCommerce.InfraStructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.InfraStructure;

public static class DepedencyInjection
{
    /// <summary>
    /// Extension method to add Infrastructure services to depedency injection
    /// </summary>
    /// <param name="service"></param>
    /// <returns></returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection service)
    {
        service.AddTransient<IUsersRepository, UserRepository>();
        service.AddTransient<DapperDbContext>();
        return service;
    }
}

