using System;
using Xamarin.Forms;
using System.IO;
using System.Threading.Tasks;
using XamarinForms.LocalRepository.Droid;

[assembly: Dependency(typeof(SaveAndLoadTextAndroid))]

namespace XamarinForms.LocalRepository.Droid
{
    public class SaveAndLoadTextAndroid : ISaveAndLoadText
    {

        private const string EmployeeFileName = "employee.txt";

        public async Task<bool> SaveTextAsync(string text)
        {
            var docsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            try
            {
                var path = Path.Combine(docsPath, EmployeeFileName);

                using (StreamWriter sw = File.CreateText(path))
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

            var docsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            try
            {
                var path = Path.Combine(docsPath, EmployeeFileName);

                using (StreamReader sr = File.OpenText(path))
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