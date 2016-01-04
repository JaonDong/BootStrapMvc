using System.Reflection;

namespace IocClass
{
    public interface IConventionalRegistrationContext
    {
        /// <summary>
        /// Gets the registering Assembly.
        /// </summary>
        Assembly Assembly { get; }

        /// <summary>
        /// Reference to the IOC Container to register types.
        /// </summary>
        IIocManager IocManager { get; }

        
        //ConventionalRegistrationConfig Config { get; }
    }
}