using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppParking.View;

namespace WpfAppParking.Helpers
{
    class PageNavigationService
    {
        OverzichtPage overzichtPage = null;
        StartPage startPage = null;
        OverzichtPlaatsenPage overzichtPlaatsenPage = null;
        OverzichtParkingenPage overzichtParkingenPage = null;
        public PageNavigationService()
        {

        }

        public void Navigate(string route)
        {
            switch (route)
            {
                case "/":
                    startPage = new StartPage();
                    ApplicationHelper.NavigationService.Navigate(startPage);
                    break;
                case "/place-details":
                    overzichtPage = new OverzichtPage();
                    ApplicationHelper.NavigationService.Navigate(overzichtPage);
                    break;
                case "/place-parking-details":
                    overzichtParkingenPage = new OverzichtParkingenPage();
                    ApplicationHelper.NavigationService.Navigate(overzichtParkingenPage);
                    break;
                case "/place-plaats-details":
                    overzichtPlaatsenPage = new OverzichtPlaatsenPage();
                    ApplicationHelper.NavigationService.Navigate(overzichtPlaatsenPage);
                    break;
                default:
                    break;


            }

        }
    }
}
