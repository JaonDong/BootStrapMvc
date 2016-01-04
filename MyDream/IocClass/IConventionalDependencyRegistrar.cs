namespace IocClass
{
    /// <summary>
    /// 可被注入的接口协议
    /// </summary>
    public interface IConventionalDependencyRegistrar
    {
        void RegisterAssembly(IConventionalRegistrationContext context);
    }
}