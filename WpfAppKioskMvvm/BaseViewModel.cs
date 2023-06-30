using ClassLibraryEntity;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace WpfAppKioskMvvm
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public string ViewTitle { get; set; }
        public List<ServiceMenuDTO> ServiceMenusDTO { get; set; }
        public List<ServiceMenu> ServiceMenus { get; set; }
        public List<Questions> QuestionList { get; set; }
        public int MenuSelectedItem { get; set; }

        public ICommand SaveMenuCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}