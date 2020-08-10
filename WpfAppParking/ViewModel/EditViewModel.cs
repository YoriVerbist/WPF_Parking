using System.Windows.Input;
using WpfAppParking.Extensions;
using WpfAppParking.Messages;
using WpfAppParking.Model;

namespace WpfAppParking.ViewModel
{
    class EditViewModel : BaseViewModel
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
        public EditViewModel()
        {
            Messenger.Default.Register<Rij>(this, OnRijRecieved);

            UpdateCommand = new BaseCommand(UpdateRij);
            DeleteCommand = new BaseCommand(DeleteRij);
        }

        private void DeleteRij()
        {
            RijDataService ds = new RijDataService();
            ds.DeleteRij(SelectedRij);

            Messenger.Default.Send<UpdateFinishedMessage>(new UpdateFinishedMessage(UpdateFinishedMessage.MessageType.Deleted));
        }

        private void UpdateRij()
        {

            RijDataService ds = new RijDataService();

            if (SelectedRij.ID != 0)
            {
                ds.UpdateRij(SelectedRij);

                Messenger.Default.Send<UpdateFinishedMessage>(new UpdateFinishedMessage(UpdateFinishedMessage.MessageType.Updated));
            }
            else
            {
                ds.InsertRij(SelectedRij);

                Messenger.Default.Send<UpdateFinishedMessage>(new UpdateFinishedMessage(UpdateFinishedMessage.MessageType.Inserted));
            }
        }

        private void OnRijRecieved(Rij rij)
        {
            SelectedRij = rij;
        }
    }
}
