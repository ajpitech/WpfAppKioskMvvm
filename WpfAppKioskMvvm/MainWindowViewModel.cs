using ClassLibraryEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfAppKioskMvvm
{
    public class MainWindowViewModel:BaseViewModel
    {
        public ICommand KioskCommand { get; set; }
        public ICommand OfficerCommand { get; set; }
       

      // public KioskCommandViewModel KioskCommandViewModel { get; set; } 
        public BaseViewModel ActiveView { get; set; }

     
        public MainWindowViewModel()
        {
            ViewTitle = BasicOperation.Title();
            //KioskCommandViewModel=new KioskCommandViewModel(this);
            KioskCommand = new RelayCommand(KioskCommandClick);
            OfficerCommand = new RelayCommand(OfficerCommandClick); 
            KioskCommandClick();
        }

        private void OfficerCommandClick()
        {
            ActiveView = new OfficerCommandViewModel();
            OnPropertyChanged(nameof(ActiveView));
        }

        private void KioskCommandClick()
        {
            ActiveView = new KioskCommandViewModel(this);
            OnPropertyChanged(nameof(ActiveView));
        }
        public void MenuCommandClick(object parameter)
        {
            MenuSelectedItem =(int)parameter;
            ActiveView = new ServiceViewModel(this);
            OnPropertyChanged(nameof(ActiveView));

            
        }


        //public void QuestionWindow(int result)
        //{
        //    var sm = BasicOperation.resServiceMenu.ResData.Where(x => x.MenuId == result).ToList().SingleOrDefault();
        //    MenuLbl = "Your Choice is " + sm.MenuName + " Menu";
        //    QuestionList = BasicOperation.View_Question(sm.MenuId);
        //    OnPropertyChanged(nameof(QuestionList));
        //}
  
    }
}
