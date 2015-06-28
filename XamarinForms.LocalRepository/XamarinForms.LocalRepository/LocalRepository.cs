using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace XamarinForms.LocalRepository
{
    /// <summary>
    /// Stores and retrives information about the employee. 
    /// </summary>
    public class LocalRepository
    {

        /// <summary>
        /// Retrieve the saved employee from the local phone storage.
        /// </summary>
        /// <returns></returns>
        public async Task<Employee> GetEmployeeAsync()
        {
            var textJson = await DependencyService.Get<ISaveAndLoadText>().GetTextAsync();

            if (string.IsNullOrEmpty(textJson))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<Employee>(textJson);
        }

        /// <summary>
        /// Save the employee in parameter to local phone storage.
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public async Task<bool> SaveEmployeeAsync(Employee employee)
        {
            var textJson = JsonConvert.SerializeObject(employee);

            return await DependencyService.Get<ISaveAndLoadText>().SaveTextAsync(textJson);
        }
    }
}
