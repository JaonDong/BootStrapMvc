using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using BeginZore.IocMvc;
using Castle.Windsor;
using Castle.Windsor.Installer;
using IocClass;
using IocClass.Dependency;
using RegisterClass;

namespace BeginZore
{
    public class Global : HttpApplication
    {
        private IWindsorContainer _container;

        void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //初始化一个IOC容器

            _container = new WindsorContainer().Install(FromAssembly.This());
            var iocManager = new IocManager(_container);

            //完成IWindsorInstaller接口中的注册
            
            ControllerBuilder.Current.SetControllerFactory(new MyDefaultControllerFactory(iocManager));
            RegisterModel(iocManager);
        }

        private void RegisterModel(IIocManager iocManager)
        {
            iocManager.Register<IComTest,ComTest>();
        }
    }
}