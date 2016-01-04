using System;
using System.Diagnostics;
using System.Reflection;
using IocClass;

namespace RegisterClass
{
    public class ComTest:IComTest,IConventionalDependencyRegistrar
    {

        public string ConsoleWrite(DateTime time)
        {
            var str = time.ToString("yyyy-MM-dd hh:mm:ss");
            Debug.WriteLine(str);

            return str;
        }

        public void RegisterAssembly(IConventionalRegistrationContext context)
        {
            Debug.WriteLine("瓦胡同");
        }
    }
}