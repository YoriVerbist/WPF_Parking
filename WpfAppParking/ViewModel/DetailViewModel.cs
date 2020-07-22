using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfAppParking.Model;

namespace WpfAppParking.ViewModel
{
    class DetailViewModel : BaseViewModel
    {
        private Rij selectedRij;

        public Rij SelectedRij
        {
            get
            {
                return selectedRij;
            }
            set
            {
                selectedRij = value;
                NotifyPropertyChanged();
            }
        }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public DetailViewModel()
        {
            Messenger.Default.Register<Rij>(this, OnRijReceived);
        }
        private void OnRijReceived(Rij rij)

        {
            SelectedRij = rij;
        }

    }
}
