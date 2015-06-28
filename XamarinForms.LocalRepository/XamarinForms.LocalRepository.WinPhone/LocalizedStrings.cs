using XamarinForms.LocalRepository.WinPhone.Resources;

namespace XamarinForms.LocalRepository.WinPhone
{
    /// <summary>
    /// Provides access to string resources.
    /// </summary>
    public class LocalizedStrings
    {
        private static AppResources _localizedResources = new AppResources();

        public AppResources LocalizedResources
        { get { return _localizedResources; } }
    }
}
