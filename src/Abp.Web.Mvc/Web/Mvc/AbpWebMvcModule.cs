using System;
using System.Reflection;
using System.Web.Hosting;
using System.Web.Mvc;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.Web.Mvc.Auditing;
using Abp.Web.Mvc.Authorization;
using Abp.Web.Mvc.Configuration;
using Abp.Web.Mvc.Controllers;
using Abp.Web.Mvc.ModelBinding.Binders;
using Abp.Web.Mvc.Resources.Embedded;
using Abp.Web.Mvc.Security.AntiForgery;
using Abp.Web.Mvc.Uow;
using Abp.Web.Mvc.Validation;
using Abp.Web.Security.AntiForgery;

namespace Abp.Web.Mvc
{
    /// <summary>
    /// This module is used to build ASP.NET MVC web sites using Abp.
    /// </summary>
    [DependsOn(typeof(AbpWebModule))]
    public class AbpWebMvcModule : AbpModule
    {
        /// <inheritdoc/>
        public override void PreInitialize()
        {
            IocManager.AddConventionalRegistrar(new ControllerConventionalRegistrar());

            IocManager.Register<IAbpMvcConfiguration, AbpMvcConfiguration>();

            Configuration.ReplaceService<IAbpAntiForgeryManager, AbpMvcAntiForgeryManager>();
        }

        /// <inheritdoc/>
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(IocManager));
            HostingEnvironment.RegisterVirtualPathProvider(IocManager.Resolve<EmbeddedResourceVirtualPathProvider>());
        }

        /// <inheritdoc/>
        public override void PostInitialize()
        {
            // 设置用于验证权限的全局过滤器
            GlobalFilters.Filters.Add(IocManager.Resolve<AbpMvcAuthorizeFilter>());

            // 设置AntiForgery的全局过滤器
            GlobalFilters.Filters.Add(IocManager.Resolve<AbpAntiForgeryMvcFilter>());

            // 设置用于添加审查日志的全局过滤器
            GlobalFilters.Filters.Add(IocManager.Resolve<AbpMvcAuditFilter>());
            
            // 设置用于验证的全局过滤器
            GlobalFilters.Filters.Add(IocManager.Resolve<AbpMvcValidationFilter>());

            // 设置用于设置每一个action一个工作单元的过滤器
            GlobalFilters.Filters.Add(IocManager.Resolve<AbpMvcUowFilter>());

            // 设置用于日期的模型绑定
            var abpMvcDateTimeBinder = new AbpMvcDateTimeBinder();
            ModelBinders.Binders.Add(typeof(DateTime), abpMvcDateTimeBinder);
            ModelBinders.Binders.Add(typeof(DateTime?), abpMvcDateTimeBinder);
        }
    }
}
