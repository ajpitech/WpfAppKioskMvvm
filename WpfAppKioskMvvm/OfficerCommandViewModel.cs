using ClassLibraryEntity;

namespace WpfAppKioskMvvm
{
    public class OfficerCommandViewModel : BaseViewModel
    {
        public string Title { get; set; }
        public OfficerCommandViewModel()
        {
            Title = BasicOperation.Title();
        }
    }
}