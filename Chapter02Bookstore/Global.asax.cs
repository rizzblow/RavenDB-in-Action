﻿using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Raven.Client;
using Raven.Client.Document;

namespace Chapter02Bookstore
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        private static IDocumentStore documentStore;
        public static IDocumentStore TheDocumentStore { get { return documentStore; } }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            documentStore = new DocumentStore
                                {
                                    ConnectionStringName = "RavenDB"
                                };
            documentStore.Initialize();
        }
    }
}