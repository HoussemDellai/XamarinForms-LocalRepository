using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Xamarin.Forms;
using XamarinForms.LocalRepository.WinPhone;

[assembly: Dependency(typeof(SaveAndLoadTextWinPhone))]

namespace XamarinForms.LocalRepository.WinPhone
{
    public class SaveAndLoadTextWinPhone : ISaveAndLoadText
    {

        private const string EmployeeFileName = "employee.txt";

        public async Task<bool> SaveTextAsync(string text)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            try
            {
                IStorageFile file =
                    await localFolder.CreateFileAsync(EmployeeFileName, CreationCollisionOption.ReplaceExisting);

                using (StreamWriter streamWriter = new StreamWriter(file.Path))
                {
                    await streamWriter.WriteAsync(text);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<string> GetTextAsync()
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;

            try
            {
                IStorageFile file = await localFolder.GetFileAsync(EmployeeFileName);

                using (StreamReader streamReader = new StreamReader(file.Path))
                {
                    return await streamReader.ReadToEndAsync();
                }
            }
            catch (FileNotFoundException exc)
            {
                return String.Empty;
            }
            catch (Exception)
            {
                return String.Empty;
            }
        }
    }
}