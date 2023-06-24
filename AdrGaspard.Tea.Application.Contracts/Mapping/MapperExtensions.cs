using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AdrGaspard.Tea.Application.Contracts.Mapping
{
    public static class MapperExtensions
    {
        private static readonly Type _genericMapperInterface = typeof(IMapper<,>);

        public static IServiceCollection AddMapper<TMapper>(this IServiceCollection serviceCollection) where TMapper : class
        {
            return ProcessMapper<TMapper>(serviceCollection, serviceCollection.Add);
        }

        public static IServiceCollection TryAddMapper<TMapper>(this IServiceCollection serviceCollection) where TMapper : class
        {
            return ProcessMapper<TMapper>(serviceCollection, serviceCollection.TryAdd);
        }

        public static IServiceCollection ReplaceMapper<TMapper>(this IServiceCollection serviceCollection) where TMapper : class
        {
            return ProcessMapper<TMapper>(serviceCollection, serviceCollection.Replace);
        }

        private static IServiceCollection ProcessMapper<TMapper>(IServiceCollection serviceCollection, Func<ServiceDescriptor, IServiceCollection> serviceDeclarationMethod) where TMapper : class
        {
            return ProcessMapper<TMapper>(serviceCollection, serviceDescriptor => serviceDeclarationMethod(serviceDescriptor));
        }

        private static IServiceCollection ProcessMapper<TMapper>(IServiceCollection serviceCollection, Action<ServiceDescriptor> serviceDeclarationMethod) where TMapper : class
        {
            Type mapperType = typeof(TMapper);
            IEnumerable<Type> mapperInterfacetypes = mapperType.GetInterfaces().Where(type => type.IsGenericType && type.GetGenericTypeDefinition() == _genericMapperInterface);
            serviceDeclarationMethod(new(mapperType, mapperType, ServiceLifetime.Singleton));
            foreach (Type? type in mapperInterfacetypes)
            {
                serviceDeclarationMethod(new(type, mapperType, ServiceLifetime.Singleton));
            }
            return serviceCollection;
        }
    }
}
