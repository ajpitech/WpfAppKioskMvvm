using ClassLibraryEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfAppKioskMvvm
{
    public class KioskCommandViewModel: BaseViewModel
    {
        public string Title { get; set; }
        //public ICommand MenuCommand { get; set; }
        private  MainWindowViewModel mwwm;
        public KioskCommandViewModel(MainWindowViewModel mainWindowViewModel)
        {
            mwwm= mainWindowViewModel;
            ServiceMenusDTO = ConvertToListDTO(BasicOperation.DisplayMenu());
            OnPropertyChanged(nameof(ServiceMenusDTO)); 
            if(mwwm != null)
            {
                ServiceMenusDTO = ConvertToListDTO(BasicOperation.DisplayMenu());
                OnPropertyChanged(nameof(ServiceMenusDTO));
            }

        }
        public KioskCommandViewModel() {
            Title = BasicOperation.Title();
           
           
        }
    
        private List<ServiceMenuDTO> ConvertToListDTO(List<ServiceMenu> sm)
        {
            List<ServiceMenuDTO> serviceMenuDTOs= new List<ServiceMenuDTO>();
            foreach (ServiceMenu serviceMenu in sm)
            {
                ServiceMenuDTO serviceMenuDTO=new ServiceMenuDTO();
                serviceMenuDTO.MenuId=serviceMenu.MenuId;
                serviceMenuDTO.MenuName=serviceMenu.MenuName;
                serviceMenuDTO.MenuCommand =  new RelayCommand(mwwm.MenuCommandClick);
                serviceMenuDTOs.Add(serviceMenuDTO);
            }
            return serviceMenuDTOs;
        }
        
    }
}
