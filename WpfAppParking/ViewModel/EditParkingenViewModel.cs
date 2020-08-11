using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using WpfAppParking.Messages;
using WpfAppParking.Model;
using Messenger = WpfAppParking.Extensions.Messenger;


namespace WpfAppParking.ViewModel
{
    class EditParkingenViewModel : BaseViewModel
    {
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
        
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public EditParkingenViewModel()
        {
            Messenger.Default.Register<Parking>(this, OnParkingRecieved);
            Messenger.Default.Register<Plaats>(this, OnPlaatsRecieved);
            
            UpdateCommand = new BaseCommand(UpdateParking);
            DeleteCommand = new BaseCommand(DeleteParking);
        }

        private void DeleteParking()
        {
            ParkingDataService ds = new ParkingDataService();
            ds.DeleteParking(SelectedParking);
            
            Messenger.Default.Send<UpdateFinishedMessage>(new UpdateFinishedMessage(UpdateFinishedMessage.MessageType.Deleted));
        }

        private void UpdateParking()
        {
            ParkingDataService ds = new ParkingDataService();

            if (SelectedParking.ID != 0)
            {
                ds.UpdateParking(SelectedParking);
                
                Messenger.Default.Send<UpdateFinishedMessage>(new UpdateFinishedMessage(UpdateFinishedMessage.MessageType.Updated));
            }
            else
            {
                ds.InsertParking(SelectedParking);
                Messenger.Default.Send<UpdateFinishedMessage>(new UpdateFinishedMessage(UpdateFinishedMessage.MessageType.Inserted));
            }
        }

        private void OnParkingRecieved(Parking parking)
        {
            SelectedParking = parking;
        }

        private void OnPlaatsRecieved(Plaats plaats)
        {
            SelectedPlaats = plaats;
        }
    }
}