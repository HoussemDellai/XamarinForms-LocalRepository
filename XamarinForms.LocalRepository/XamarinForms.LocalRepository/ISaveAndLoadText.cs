using System.Threading.Tasks;

namespace XamarinForms.LocalRepository
{
    /// <summary>
    /// Define an API for loading and saving a text file. Reference this interface
    /// in the common code, and implement this interface in the app projects for
    /// iOS, Android and WinPhone. Remember to use the 
    ///     [assembly: Dependency (typeof (SaveAndLoad_IMPLEMENTATION_CLASSNAME))]
    /// attribute on each of the implementations.
    /// </summary>
    public interface ISaveAndLoadText
    {
        /// <summary>
        /// Save the string in parameter.
        /// Will return true if the value was saved successfully.
        /// Will return false if the value was not saved successfully.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        Task<bool> SaveTextAsync(string text);

        /// <summary>
        /// Return the saved text if it exists.
        /// Will return "0" if the value was not found.
        /// </summary>
        /// <returns></returns>
        Task<string> GetTextAsync();
    }
}
