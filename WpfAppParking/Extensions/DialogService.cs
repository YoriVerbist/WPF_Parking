using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfAppParking.View;

namespace WpfAppParking.Extensions
{
    public class DialogService
    {

        Window RijDetailView = null;
        Window RijOverzichtView = null;

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
    }
}
