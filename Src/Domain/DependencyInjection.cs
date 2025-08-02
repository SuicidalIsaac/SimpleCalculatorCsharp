using Microsoft.Extensions.DependencyInjection;

namespace SimpleCalculatorCsharp.Src.Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            // I know this is not used in any way, but it may be useful in the future when expanding the functionality
            return services;
        }
    }
}