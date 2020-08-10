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
        private static OverzichtPlaatsenViewModel overzichtPlaatsenViewModel = new OverzichtPlaatsenViewModel();
        private static DetailPlaatsenViewModel detailPlaatsenViewModel = new DetailPlaatsenViewModel();
        private static EditPlaatsenViewModel editPlaatsenViewModel = new EditPlaatsenViewModel();
        private static OverzichtParkingenViewModel overzichtParkingenViewModel = new OverzichtParkingenViewModel();
        private static DetailParkingenViewModel detailParkingenViewModel = new DetailParkingenViewModel();
        private static EditParkingenViewModel editParkingenViewModel = new EditParkingenViewModel();

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

        public static OverzichtPlaatsenViewModel OverzichtPlaatsenViewModel
        {
            get
            {
                return overzichtPlaatsenViewModel;
            }
        }

        public static DetailPlaatsenViewModel DetailPlaatsenViewModel
        {
            get
            {
                return detailPlaatsenViewModel;
            }
        }

        public static EditPlaatsenViewModel EditPlaatsenViewModel
        {
            get
            {
                return editPlaatsenViewModel;
            }
        }

        public static OverzichtParkingenViewModel OverzichtParkingenViewModel
        {
            get
            {
                return overzichtParkingenViewModel;
            }
        }

        public static DetailParkingenViewModel DetailParkingenViewModel
        {
            get
            {
                return detailParkingenViewModel;
            }
        }

        public static EditParkingenViewModel EditParkingenViewModel
        {
            get
            {
                return editParkingenViewModel;
            }
        }
    }
}