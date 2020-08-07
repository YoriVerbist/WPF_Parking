using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppParking.Model
{
    class Rij : INotifyPropertyChanged, IDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int id;
        private int parking_ID;
        private int totale_plaatsen;
        private int bezette_plaatsen;
        private bool volzet;

        public int ID
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
                NotifyPropertyChanged();
            }
        }

        public int Parking_ID
        {
            get
            {
                return parking_ID;
            }

            set
            {
                parking_ID = value;
                NotifyPropertyChanged();
            }
        }

        public int Totale_plaatsen
        {
            get
            {
                return totale_plaatsen;
            }

            set
            {
                totale_plaatsen = value;
                NotifyPropertyChanged();
            }
        }

        public int Bezette_plaatsen
        {
            get
            {
                return bezette_plaatsen;
            }

            set
            {
                bezette_plaatsen = value;
                NotifyPropertyChanged();
            }
        }

        public bool Volzet
        {
            get
            {
                return volzet;
            }

            set
            {
                if (bezette_plaatsen == totale_plaatsen)
                {
                    volzet = true;
                }
                else
                {
                    volzet = false;
                }
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

        //public Rij(int ID, int parkingID, int plaatsen, int bezette_plaatsen, bool bezet)
        //{
        //    ParkingID = parkingID;
        //    Totale_plaatsen = plaatsen;
        //    Bezette_plaatsen = bezette_plaatsen;
        //    Volzet = bezet;
        //}

        public Rij()
        { }

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
