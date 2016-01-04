using Microsoft.VisualStudio.TestTools.UnitTesting;
using IocClass.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegisterClass;

namespace IocClass.Dependency.Tests
{
    [TestClass()]
    public class IocManagerTests
    {
        public IIocManager IocManager=new IocManager();


        public void TestFor()
        {
            IocManager.Register<IComTest,ComTest>();
        }

        [TestMethod()]
        public void AddConventionalRegistrarTest()
        {
            TestFor();
            var comTest = IocManager.Resolve<IComTest>();
            var now = DateTime.Now;
            var str= comTest.ConsoleWrite(now);
            
            Console.WriteLine(str);
            Assert.AreEqual(str,now.ToString("yyyy-MM-dd hh:mm:ss"));
        }
    }
}