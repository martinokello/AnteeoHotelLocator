using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Anteeo.Caching.Anteeo.Caching.Concretes;
using Anteeo.Caching.Anteeo.Caching.Interfaces;
using AnteeoAuthentication.AuthAbstracts;
using AnteeoAuthentication.AuthenticationConcretes;
using AnteeoAuthentication.IAuth;
using HotelLocatorServices.ConcreteServices;
using HotelLocatorServices.ServiceInterfaces;
using Microsoft.Practices.Unity;

namespace AnteeoHotelLocator.App_Start
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            InitializeUnityContainer(container);

            //var unityServiceLocator = new UnityServiceLocator(container);
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static void InitializeUnityContainer(IUnityContainer container)
        {
            container.RegisterType<IHotelAndLocation<dynamic>, HotelAndLocationService<dynamic>>();
            container.RegisterType<AnteeoHotelLocatorAuth>();
            container.RegisterType<IAnteeoCaching, AnteeoCaching>();

            IEnumerable<Type> controllerTypes = from t in Assembly.GetExecutingAssembly().GetTypes()
                                                where typeof(IController).IsAssignableFrom(t)
                                                select t;

            foreach (Type t in controllerTypes)
            {
                container.RegisterType(t);
            }
        }
    }
}