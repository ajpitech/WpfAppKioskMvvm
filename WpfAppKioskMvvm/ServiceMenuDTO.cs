using System.Windows.Input;

namespace WpfAppKioskMvvm
{
    public class ServiceMenuDTO
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public ICommand MenuCommand { get; set; }

    }
}