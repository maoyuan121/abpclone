using Abp.Dependency;

namespace Abp.Localization
{
    /// <summary>
    /// ������������<see cref="ILocalizationContext"/>.
    /// </summary>
    public class LocalizationContext : ILocalizationContext, ISingletonDependency
    {
        public ILocalizationManager LocalizationManager { get; private set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="LocalizationContext"/> class.
        /// </summary>
        /// <param name="localizationManager">The localization manager.</param>
        public LocalizationContext(ILocalizationManager localizationManager)
        {
            LocalizationManager = localizationManager;
        }
    }
}