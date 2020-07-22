using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppParking.Model
{
    class Plaats : INotifyPropertyChanged, IDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int id;
        private int rij_id;
        private bool bezet;

        public int ID
        {
            get
            {
                return ID;
            }
            set
            {
                id = value;
                NotifyPropertyChanged();
            }
        }

        public int Rij_Id
        {
            get
            {
                return rij_id;
            }
            set
            {
                rij_id = value;
                NotifyPropertyChanged();
            }
        }

        public bool Bezet
        {
            get
            {
                return bezet;
            }
            set
            {
                bezet = value;
                NotifyPropertyChanged();
            }
        }

        public string Error
        {
            get
            {
                return string.Empty;
            }
        }

        public string this[string columnName]
        {
            get
            {
                string result = string.Empty;

                return result;

            }
        }

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

