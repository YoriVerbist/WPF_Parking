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
            get
            {
                return parkingen;
            }
            set
            {
                parkingen = value;
                NotifyPropertyChanged();
            }
        }

        private Parking selectedParking;

        public Parking SelectedParking
        {
            get
            {
                return selectedParking;
            }
            set
            {
                selectedParking = value;
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


        public OverzichtParkingenViewModel()
        {
            ParkingDataService ds = new ParkingDataService();
            Parkingen = ds.GetParkingen();
            
            dialogService = new DialogService();
            
            WijzigenCommand = new BaseCommand(WijzigenParkingen);
            ToevoegenCommand = new BaseCommand(ToevoegenParkingen);
            
            Messenger.Default.Register<UpdateFinishedMessage>(this, OnMessageRecieved);

            BindCommands();
        }

        public void ToevoegenParkingen()
        {
            SelectedParking = new Parking();
            
            Messenger.Default.Send<Parking>(SelectedParking);
            
            dialogService.ShowEditParkingDialog();
        }

        public void WijzigenParkingen()
        {
            if (SelectedParking != null)
            {
                Messenger.Default.Send<Parking>(SelectedParking);
                
                dialogService.ShowEditParkingDialog();
            }
        }

        private void OnMessageRecieved(UpdateFinishedMessage message)
        {
            dialogService.CloseEditParkingDialog();

            if (message.Type != UpdateFinishedMessage.MessageType.Updated)
            {
                ParkingDataService ds = new ParkingDataService();
                Parkingen = ds.GetParkingen();
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
            if (SelectedParking != null)
            {
                Messenger.Default.Send<Parking>(SelectedParking);
                PageNavigationService pageNavigationService = new PageNavigationService();
                pageNavigationService.Navigate("/place-details");
            }
        }
        
        private void GoBack()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("/place-plaats-details");
        }
    }
}