using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfAppParking.Helpers;

namespace WpfAppParking.ViewModel
{
    class StartPageViewModel : BaseViewModel
    {
        public StartPageViewModel()
        {
            BindCommands();
        }

        public ICommand GoToHomeCommand { get; set; }
        private void BindCommands()
        {
            GoToHomeCommand = new BaseCommand(GoToHome);
        }
        private void GoToHome()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("/place-plaats-details");
        }
    }
}
