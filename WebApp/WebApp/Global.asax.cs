using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using AutoMapper;
using WebApp.Model.Model;
using WebApp.Models; 

namespace WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //Initialize
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<StudentViewModel, Student >();
                cfg.CreateMap< Student, StudentViewModel>();

            });
        }
    }
}
