using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinForms.LocalRepository
{
    public class HomeViewModel : INotifyPropertyChanged
    {

        private readonly LocalRepository _localRepository;
        private Employee _employee;

        public Employee Employee
        {
            get { return _employee; }
            set
            {
                _employee = value; 
                OnPropertyChanged();
            }
        }

        public ICommand SaveEmployeeCommand { get; set; }

        public ICommand GetEmployeeCommand { get; set; }

        public HomeViewModel()
        {
            _localRepository = new LocalRepository();

            Employee = new Employee();

            SaveEmployeeCommand = new Command(async () =>
            {
                var isSaved = await _localRepository.SaveEmployeeAsync(_employee);

                if (isSaved)
                {
                    MessagingCenter.Send(this, "Message", "The employee was saved successfully!");
                }
                else
                {
                    MessagingCenter.Send(this, "Message", "The employee was not saved!");
                }
            });

            GetEmployeeCommand = new Command(async () =>
            {
                Employee = await _localRepository.GetEmployeeAsync();

                if (_employee == null)
                {
                    MessagingCenter.Send(this, "Message", "The employee was not retrieved!");
                }
                else
                {
                    MessagingCenter.Send(this, "Message", "The employee was retrieved successfully!");
                }
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
