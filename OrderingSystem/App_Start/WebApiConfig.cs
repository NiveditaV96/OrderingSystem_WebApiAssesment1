using Autofac;
using Autofac.Integration.WebApi;
using OrderingSystem.Models;
using OrderingSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;

namespace OrderingSystem
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        public static void SetUpForAutofac(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            // Register your Web API controllers.
            //uses reflection
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<OrderRepository>().As<IRepository<Order>>().SingleInstance();
            builder.RegisterType<OrderRepository>().As<IGetOrderRepository>().SingleInstance();
            builder.RegisterType<OrderRepository>().As<ICancelOrderRepository>().SingleInstance();
            builder.RegisterType<OrderRepository>().As<IUpdateOrderRepository<OrderPatchRequest>>().SingleInstance();

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
