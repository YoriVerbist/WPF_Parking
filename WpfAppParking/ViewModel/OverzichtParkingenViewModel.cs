using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfAppParking.Extensions;
using WpfAppParking.Helpers;
using WpfAppParking.Messages;
using WpfAppParking.Model;
using Messenger = WpfAppParking.Extensions.Messenger;

namespace WpfAppParking.ViewModel
{
    class OverzichtParkingenViewModel : BaseViewModel
    {
        private DialogService dialogService;

        private ObservableCollection<Parking> parkingen;

        public ObservableCollection<Parking> Parkingen
        {
            get => parkingen;
            set 
            {
            parkingen = value;
            NotifyPropertyChanged();
            }
        }

        private Parking selectedParking;

        public Parking SelectedParking
        {
            get => selectedParking;
            set
            {
                selectedParking = value;
                NotifyPropertyChanged();
            }
        }
        private Plaats selectedPlaats;

        public Plaats SelectedPlaats
        {
            get
            {
                return selectedPlaats;
            }
            set
            {
                selectedPlaats = value;
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

        public OverzichtParkingenViewModel()
        {
            Messenger.Default.Register<Plaats>(this, OnPlaatsRecieved);
            
            ParkingDataService ds = new ParkingDataService();
            Parkingen = ds.GetParkingen(SelectedPlaats);

            //instantiëren DialogService als singleton
            dialogService = new DialogService();
            
            //koppelen commands
            WijzigenCommand = new BaseCommand(WijzigenParkingen);
            ToevoegenCommand = new BaseCommand(ToevoegenParkingen);
            DetailCommand = new BaseCommand(DetailParking);

            //luisteren naar messages vanuit detailvenster
            Messenger.Default.Register<UpdateFinishedMessage>(this, OnMessageReceived);
            
            BindCommands();
        }

        private void ToevoegenParkingen()
        {
            Messenger.Default.Register<Plaats>(this, OnPlaatsRecieved);

            SelectedParking = new Parking();
            SelectedParking.Plaats_ID = SelectedPlaats.ID;
            
            Messenger.Default.Send<Parking>(SelectedParking);

            dialogService.ShowEditParkingDialog();
        }

        private void DetailParking()
        {
            if (SelectedParking != null)
            {
                Messenger.Default.Send<Parking>(SelectedParking);

                dialogService.ShowDetailParkingenDialog();
            }
        }

        private void OnMessageReceived(UpdateFinishedMessage message)
        {
            //na update of delete mag detailvenster sluiten
            dialogService.CloseEditParkingDialog();

            //na Delete/Insert moet collectie Koffies terug ingeladen worden
            if (message.Type != UpdateFinishedMessage.MessageType.Updated)
            {
                ParkingDataService ds = new ParkingDataService();
                Parkingen = ds.GetParkingen(SelectedPlaats);
            }
        }

        private void WijzigenParkingen()
        {
            if (selectedParking != null)
            {
                Messenger.Default.Send<Parking>(SelectedParking);

                dialogService.ShowEditParkingDialog();
            }
        }
        
        public ICommand GoToHomeCommand { get; set; }
        public ICommand GoBackCommand { get; set; }
        private void BindCommands()
        {
            GoToHomeCommand = new BaseCommand(GoToHome);
            GoBackCommand = new BaseCommand(GoBack);
        }
        private void GoToHome()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("/place-details");
        }
        
        private void GoBack()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("/place-plaats-details");
        }
        
        private void OnPlaatsRecieved(Plaats plaats)
        {
            SelectedPlaats = plaats;
        }
    }
}