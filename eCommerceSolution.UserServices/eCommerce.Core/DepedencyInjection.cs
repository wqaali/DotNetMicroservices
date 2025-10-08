using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core;

public static class DepedencyInjection
{
    /// <summary>
    /// Extension method to add Core services to depedency injection
    /// </summary>
    /// <param name="service"></param>
    /// <returns></returns>
    public static IServiceCollection AddCore(this IServiceCollection service)
    {
        service.AddTransient<IUsersService, UsersService>();
        return service;
    }
}

