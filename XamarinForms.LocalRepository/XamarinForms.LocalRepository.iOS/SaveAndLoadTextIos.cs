using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinForms.LocalRepository.iOS;

[assembly: Dependency(typeof(SaveAndLoadiOS))]

namespace XamarinForms.LocalRepository.iOS
{
    public class SaveAndLoadiOS : ISaveAndLoadText
    {

        private const string EmployeeFileName = "employee.txt";

        public async Task<bool> SaveTextAsync(string text)
        {
            try
            {
                using (StreamWriter sw = File.CreateText(EmployeeFileName))
                {
                    await sw.WriteAsync(text);
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
            try
            {
                using (StreamReader sr = File.OpenText(EmployeeFileName))
                {
                    return await sr.ReadToEndAsync();
                }
            }
            catch (FileNotFoundException)
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

