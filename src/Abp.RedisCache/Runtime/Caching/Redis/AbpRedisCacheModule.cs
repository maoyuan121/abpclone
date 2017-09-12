using System.Reflection;
using Abp.Modules;

namespace Abp.Runtime.Caching.Redis
{
    /// <summary>
    /// Redis缓存模块
    /// </summary>
    [DependsOn(typeof(AbpKernelModule))]
    public class AbpRedisCacheModule : AbpModule
    {
        public override void PreInitialize()
        {
            IocManager.Register<AbpRedisCacheOptions>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
