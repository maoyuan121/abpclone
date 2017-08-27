using System.Collections.Generic;
using System.Collections.Immutable;
using Abp.Configuration.Startup;
using Abp.Dependency;

namespace Abp.Localization
{
    /// <summary>
    /// �����ṩ��
    /// </summary>
    public class DefaultLanguageProvider : ILanguageProvider, ITransientDependency
    {
        private readonly ILocalizationConfiguration _configuration;

        public DefaultLanguageProvider(ILocalizationConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<LanguageInfo> GetLanguages()
        {
            return _configuration.Languages.ToImmutableList();
        }
    }
}