using System.Web.Mvc;
using BeginZore.Controllers;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using RegisterClass;

namespace BeginZore.IocMvc
{
    public class ControllerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly() //在哪里找寻接口或类

             .BasedOn<IController>() //实现IController接口

             .If(Component.IsInSameNamespaceAs<HomeController>()) //与HomeController在同一个命名空间

             .If(t => t.Name.EndsWith("Controller")) //以"Controller"结尾

             .Configure(c => c.LifestylePerWebRequest()));//每次请求创建一个Controller实例
        }
    }
}