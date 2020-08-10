using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfAppParking.Extensions;
using WpfAppParking.Helpers;
using WpfAppParking.Messages;
using WpfAppParking.Model;

namespace WpfAppParking.ViewModel
{
    class OverzichtViewModel : BaseViewModel
    {
        private DialogService dialogService;

        private ObservableCollection<Rij> rijs;

        public ObservableCollection<Rij> Rijs
        {
            get
            {
                return rijs;
            }
            set
            {
                rijs = value;
                NotifyPropertyChanged();
            }
        }

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
        private ICommand toevoegenCommand;
        public ICommand ToevoegenCommand
        {
            get
            {
                return toevoegenCommand;
            }

            set
            {
                toevoegenCommand = value;
            }
        }

        private ICommand wijzigenCommand;
        public ICommand WijzigenCommand
        {
            get
            {
                return wijzigenCommand;
            }

            set
            {
                wijzigenCommand = value;
            }
        }
        private ICommand detailCommand;
        public ICommand DetailCommand
        {
            get
            {
                return detailCommand;
            }

            set
            {
                detailCommand = value;
            }
        }

        public OverzichtViewModel()
        {
            // laden data
            RijDataService ds = new RijDataService();
            Rijs = ds.GetRijs();

            //instantiëren DialogService als singleton
            dialogService = new DialogService();

            //koppelen commands
            WijzigenCommand = new BaseCommand(WijzigenRijs);
            ToevoegenCommand = new BaseCommand(ToevoegenRijs);
            DetailCommand = new BaseCommand(DetailRij);

            //luisteren naar messages vanuit detailvenster
            Messenger.Default.Register<UpdateFinishedMessage>(this, OnMessageReceived);
            
            BindCommands();
        }

        private void ToevoegenRijs()
        {
            SelectedRij = new Rij();

            Messenger.Default.Send<Rij>(SelectedRij);

            dialogService.ShowEditDialog();

        }
        private void DetailRij()
        {
            if (SelectedRij != null)
            {
                Messenger.Default.Send<Rij>(SelectedRij);

                dialogService.ShowOverzichtDialog();
            }

        }

        private void OnMessageReceived(UpdateFinishedMessage message)
        {
            //na update of delete mag detailvenster sluiten
            dialogService.CloseDetailDialog();

            //na Delete/Insert moet collectie Koffies terug ingeladen worden
            if (message.Type != UpdateFinishedMessage.MessageType.Updated)
            {
                RijDataService ds = new RijDataService();
                Rijs = ds.GetRijs();
            }

        }

        private void WijzigenRijs()
        {
            if (SelectedRij != null)
            {
                Messenger.Default.Send<Rij>(SelectedRij);

                dialogService.ShowDetailDialog();
            }
        }
        
        public ICommand GoBackCommand { get; set; }
        private void BindCommands()
        {
            GoBackCommand = new BaseCommand(GoBack);
        }
        private void GoBack()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("/place-parking-details");
        }
    }
}
