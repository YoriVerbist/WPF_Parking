using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppParking.ViewModel;

namespace WpfAppParking
{
    class ViewModelLocator
    {
        private static OverzichtViewModel overzichtViewModel = new OverzichtViewModel();
        private static DetailViewModel detailViewModel = new DetailViewModel();
        private static EditViewModel editViewModel = new EditViewModel();


        public static OverzichtViewModel OverzichtViewModel
        {
            get
            {
                return overzichtViewModel;
            }
        }
        public static DetailViewModel DetailViewModel
        {
            get
            {
                return detailViewModel;
            }
        }

        public static EditViewModel EditViewModel
        {
            get
            {
                return editViewModel;
            }
        }


    }


}