using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfAppParking.Extensions;
using WpfAppParking.Helpers;
using WpfAppParking.Messages;
using WpfAppParking.Model;

namespace WpfAppParking.ViewModel
{
    class OverzichtPlaatsenViewModel : BaseViewModel
    {
        private DialogService dialogService;

        private ObservableCollection<Plaats> plaatsen;
        public ObservableCollection<Plaats> Plaatsen
        {
            get
            {
                return plaatsen;
            }
            set
            {
                plaatsen = value;
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

        public OverzichtPlaatsenViewModel()
        {
            PlaatsDataService ds = new PlaatsDataService();
            Plaatsen = ds.getPlaatsen();
            
            //instantiëren DialogService als singleton
            dialogService = new DialogService();

            //koppelen commands
            WijzigenCommand = new BaseCommand(WijzigenPlaatsen);
            ToevoegenCommand = new BaseCommand(ToevoegenPlaatsen);
            DetailCommand = new BaseCommand(DetailPlaats);

            //luisteren naar messages vanuit detailvenster
            Messenger.Default.Register<UpdateFinishedMessage>(this, OnMessageReceived);
            
            BindCommands();
        }

        public void ToevoegenPlaatsen()
        {
            SelectedPlaats = new Plaats();
            
            Messenger.Default.Send<Plaats>(SelectedPlaats);

            dialogService.ShowEditPlaatsenDialog();
        }

        public void DetailPlaats()
        {
            if (SelectedPlaats != null)
            {
                Messenger.Default.Send<Plaats>(SelectedPlaats);

                dialogService.ShowDetailPlaatsenDialog();
            }
        }

        private void OnMessageReceived(UpdateFinishedMessage message)
        {
            //na update of delete mag detailvenster sluiten
            dialogService.CloseDetailPlaatsenDialog();

            //na Delete/Insert moet collectie Koffies terug ingeladen worden
            if (message.Type != UpdateFinishedMessage.MessageType.Updated)
            {
                PlaatsDataService ds = new PlaatsDataService();
                Plaatsen = ds.getPlaatsen();
            }
        }

        public void WijzigenPlaatsen()
        {
            if (SelectedPlaats != null)
            {
                Messenger.Default.Send<Plaats>(SelectedPlaats);

                dialogService.ShowEditPlaatsenDialog();
            }
        }
        
        public ICommand GoToHomeCommand { get; set; }
        private void BindCommands()
        {
            GoToHomeCommand = new BaseCommand(GoToHome);
        }
        private void GoToHome()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("/place-parking-details");
        }
    }
}