using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfAppParking.Helpers;

namespace WpfAppParking.ViewModel
{
    public class SplashscreenViewModel : BaseViewModel
    {
        public SplashscreenViewModel()
        {
            BindCommands();
        }

        public ICommand GoToStartCommand { get; set; }
        private void BindCommands()
        {
            GoToStartCommand = new BaseCommand(GoToStart);
        }
        private void GoToStart()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("/");
        }
    }
}
