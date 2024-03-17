using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Data;
using System.Reflection;

namespace PortfolioAPI
{
    public static class Extension
    {
        public static IServiceCollection AddDecorator(this IServiceCollection services, Type matchInterface, Type decorator, params Assembly[] assemblies)
        {
            if (!matchInterface.IsInterface)
            {
                throw new ArgumentNullException(nameof(matchInterface), "Must be an interface to match");
            }

            if (decorator.IsInterface)
            {
                throw new ArgumentException("Must be a concrete type", nameof(decorator));
            }

            if (assemblies.Length == 0)
            {
                throw new ArgumentException("Must provide at least one assembly for scanning for decorators", nameof(assemblies));
            }

            var decoratedType = assemblies.SelectMany(t => t.GetTypes())
              .Distinct()
              .SingleOrDefault(t => t == decorator.GetGenericTypeDefinition());

            if (decoratedType == null)
            {
                throw new InvalidOperationException($"Attempted to decorate services of type {matchInterface.Name} with decorator {decorator.Name} but no such decorator found in any scanned assemblies.");
            }

            foreach (var type in services
              .Where(sd =>
              {
                  try
                  {
                      return sd.ServiceType.GetGenericTypeDefinition() == matchInterface.GetGenericTypeDefinition();
                  }
                  catch (InvalidOperationException)
                  {
                      return false;
                  }
              }).ToList())
            {
                var decoratedInstanceType = decoratedType.MakeGenericType(type.ServiceType.UnderlyingSystemType.GenericTypeArguments);

                //Create the object factory for our decorator type, specifying that we will supply the interface injection explicitly
                var objectFactory = ActivatorUtilities.CreateFactory(decoratedInstanceType, new[] { type.ServiceType });

                //Replace the existing registration with one that passes an instance of the existing registration to the object factory for the decorator 
                services.Replace(ServiceDescriptor.Describe(
                   type.ServiceType,
                   s => objectFactory(s, new[] { s.GetRequiredService(type.ServiceType) }),
                   type.Lifetime));
            }
            return services;
        }
    }
}
