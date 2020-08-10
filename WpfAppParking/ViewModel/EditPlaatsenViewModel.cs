using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using WpfAppParking.Messages;
using WpfAppParking.Model;

namespace WpfAppParking.ViewModel
{
    class EditPlaatsenViewModel : BaseViewModel
    {
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
        public EditPlaatsenViewModel()
        {
            Messenger.Default.Register<Plaats>(this, OnPlaatsRecieved);

            UpdateCommand = new BaseCommand(UpdatePlaats);
            DeleteCommand = new BaseCommand(DeletePlaats);
        }

        private void DeletePlaats()
        {
            PlaatsDataService ds = new PlaatsDataService();
            ds.DeletePlaats(SelectedPlaats);

            Messenger.Default.Send<UpdateFinishedMessage>(new UpdateFinishedMessage(UpdateFinishedMessage.MessageType.Deleted));
        }

        private void UpdatePlaats()
        {

            PlaatsDataService ds = new PlaatsDataService();
            Console.Write(SelectedPlaats);

            if (SelectedPlaats.ID != 0)
            {
                ds.UpdatePlaats(SelectedPlaats);

                Messenger.Default.Send<UpdateFinishedMessage>(new UpdateFinishedMessage(UpdateFinishedMessage.MessageType.Updated));
            }
            else
            {
                ds.InsertPlaats(SelectedPlaats);

                Messenger.Default.Send<UpdateFinishedMessage>(new UpdateFinishedMessage(UpdateFinishedMessage.MessageType.Inserted));
            }
        }

        private void OnPlaatsRecieved(Plaats plaats)
        {
            SelectedPlaats = plaats;
        }
    }
}