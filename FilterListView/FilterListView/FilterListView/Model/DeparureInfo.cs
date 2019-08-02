using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Swiping
{
    public class DepartureInfo : INotifyPropertyChanged
    {
        #region Fields

        private string name;
        private string routeName;
        private string gate;       
        private DateTime departureTime;
        private ImageSource image;

        #endregion

        #region Constructor

        public DepartureInfo()
        {

        }

        #endregion

        #region Properties

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }


        public string RouteName
        {
            get { return routeName; }
            set
            {
                routeName = value;
                OnPropertyChanged("RouteName");
            }
        }


        public string Gate
        {
            get
            {
                return gate;
            }

            set
            {
                gate = value;
                OnPropertyChanged("Gate");
            }
        }     

        public DateTime DepartureTime
        {
            get
            {
                return departureTime;
            }

            set
            {
                departureTime = value;
                OnPropertyChanged("DepartureTime");
            }
        }

        public ImageSource Icon
        {
            get { return this.image; }
            set
            {
                this.image = value;
                OnPropertyChanged("InboxImage");
            }
        }   

        #endregion

        #region Interface Member

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
                                
    public class PinnedInfo     : INotifyPropertyChanged
    {
        private string name;
        private string routeName;
        private ImageSource image;
        private bool isFavorite;

        #region Properties

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public string RouteName
        {
            get { return routeName; }
            set
            {
                routeName = value;
                OnPropertyChanged("RouteName");
            }
        }        

        public ImageSource Icon
        {
            get { return this.image; }
            set
            {
                this.image = value;
                OnPropertyChanged("Icon");
            }
        }

        public bool IsFavorite
        {
            get { return this.isFavorite; }
            set
            {
                this.isFavorite = value;
                OnPropertyChanged("IsFavorite");
            }
        }

        #endregion
        
        #region Interface Member

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
