using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfAppParking.Model;
using WpfAppParking.View;

namespace WpfAppParking.Extensions
{
    public class DialogService
    {

        Window RijDetailView = null;
        Window RijOverzichtView = null;
        private Window ParkingEditView = null;
        private Window ParkingOverzichtView = null;
        private Window PlaatsEditView = null;
        private Window PlaatsOverzichtView = null;

        public DialogService() { }
        
        public void ShowDetailDialog()
        {
            RijDetailView = new EditWindow();
            RijDetailView.ShowDialog();
        }

        public void CloseDetailDialog()
        {
            if (RijDetailView != null)
                RijDetailView.Close();
        }
        public void ShowEditDialog()
        {
            RijDetailView = new EditWindow();
            RijDetailView.ShowDialog();
        }

        public void CloseEditDialog()
        {
            if (RijDetailView != null)
                RijDetailView.Close();
        }

        public void ShowOverzichtDialog()
        {
            RijOverzichtView = new DetailWindow();
            RijOverzichtView.ShowDialog();
        }

        public void CloseOverzichtDialog()
        {
            if (RijOverzichtView != null)
                RijOverzichtView.Close();
        }

        public void ShowEditParkingDialog()
        {
            ParkingEditView = new EditParkingenWindow();
            ParkingEditView.ShowDialog();
        }

        public void CloseEditParkingDialog()
        {
            if (ParkingEditView != null)
            {
                ParkingEditView.Close();
            }
        }

        public void ShowDetailParkingenDialog()
        {
            ParkingOverzichtView = new DetailParkingenWindow();
            ParkingOverzichtView.ShowDialog();
        }

        public void CloseDetailParkingenDialog()
        {
            if (ParkingOverzichtView != null)
            {
                ParkingOverzichtView.Close();
            }
        }

        public void ShowEditPlaatsenDialog()
        {
            PlaatsEditView = new EditPlaatsenWindow();
            PlaatsEditView.ShowDialog();
        }

        public void CloseEditPlaatsenDialog()
        {
            if (PlaatsEditView != null)
            {
                PlaatsEditView.Close();
            }
        }

        public void ShowDetailPlaatsenDialog()
        {
            PlaatsOverzichtView = new DetailPlaatsenWindow();
            PlaatsOverzichtView.ShowDialog();
        }

        public void CloseDetailPlaatsenDialog()
        {
            if (PlaatsOverzichtView != null)
            {
                PlaatsOverzichtView.Close();
            }
        }
    }
}
