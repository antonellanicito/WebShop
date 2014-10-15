using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Unity.Mvc3;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;
using Microsoft.Practices.ServiceLocation;

namespace WebShop.WebApi
{
    public class UnityResolver : IDependencyResolver
    {
        protected static IUnityContainer container;

        public UnityResolver()
        {
            if (container==null)
                container = getContainerByConfigFile();
        }
        private IUnityContainer getContainerByConfigFile()
        {
            var container = new UnityContainer();
            var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            section.Configure(container, "main");
            
            return container;
        }
        public object GetService(Type serviceType)
        {
            try
            {
                return container.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return new List<object>();
            }
        }

        public IDependencyScope BeginScope()
        {
            //var child = container.CreateChildContainer();
            return new UnityResolver();
        }

        public void Dispose()
        {
            container.Dispose();
        }
    }
}