using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using OdeToFood.Data.Services;
using System.Web.Http;
using System.Web.Mvc;

namespace OdeToFood.Web
{
    public class ContainerConfig
    {
        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder();

            // scan through your project for the controller types you pass in
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<InMemoryRestaurantData>()
                .As<IRestaurantData>()
                .SingleInstance();

            var container = builder.Build();

            // telling the MVC 5 framework whenever you are resolving dependencies, use this containter
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}