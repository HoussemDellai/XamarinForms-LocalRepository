using System;
using System.Threading.Tasks;
using Windows.Storage;
using Xamarin.Forms;
using XamarinForms.LocalRepository.Windows;

[assembly: Dependency(typeof(SaveAndLoadTextWindows))]

namespace XamarinForms.LocalRepository.Windows
{

    /// <summary>
    /// Read and save data to files.
    /// More documentation here:
    /// https://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh758325.aspx
    /// </summary>
    public class SaveAndLoadTextWindows : ISaveAndLoadText
    {

        private const string EmployeeFileName = "employee.txt";

        public async Task<bool> SaveTextAsync(string text)
        {
            // Create sample file; replace if exists.
            StorageFolder folder = ApplicationData.Current.LocalFolder;

            StorageFile sampleFile = await folder.CreateFileAsync(EmployeeFileName, CreationCollisionOption.ReplaceExisting);

            try
            {
                await FileIO.WriteTextAsync(sampleFile, text);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<string> GetTextAsync()
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile sampleFile =
                await storageFolder.GetFileAsync(EmployeeFileName);

            try
            {
                return await FileIO.ReadTextAsync(sampleFile);
            }
            catch (Exception)
            {
                return String.Empty;
            }
        }
    }
}
