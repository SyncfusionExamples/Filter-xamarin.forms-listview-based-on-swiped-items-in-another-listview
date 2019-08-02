using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.ListView.XForms;
using Syncfusion.ListView.XForms.Control.Helpers;
using Xamarin.Forms;

namespace Swiping
{
    public class ListViewSwipingViewModel
    {
        #region Fields
        private PinnedInfo tappedPinedInfo;
        private ObservableCollection<DepartureInfo> secondLVCollection;
        private ObservableCollection<PinnedInfo> firstLVCollection;
        private Command<Syncfusion.ListView.XForms.ItemTappedEventArgs> itemtapCommand;
        private Command<object> favoriteTapCommand;
        private Command<object> resetTapCommand;
        
        #endregion

        #region Constructor

        public ListViewSwipingViewModel()
        {
            SecondLVCollection = new ObservableCollection<DepartureInfo>();
            FirstLVCollection = new ObservableCollection<PinnedInfo>();
            GenerateSource();
        }

        #endregion

        #region Properties
        internal SfListView secondLV
        {
            get;
            set;
        }
        internal SfListView firstLV
        {
            get;
            set;
        }
        public Command<Syncfusion.ListView.XForms.ItemTappedEventArgs> ItemTapCommand
        {
            get { return itemtapCommand; }
            set { itemtapCommand = value; }
        }
        public Command<object> FavoriteTapCommand
        {
            get { return favoriteTapCommand; }
            set { favoriteTapCommand = value; }
        }
        public Command<object> ResetTapCommand
        {
            get { return resetTapCommand; }
            set { resetTapCommand = value; }
        }
        public ObservableCollection<DepartureInfo> SecondLVCollection
        {
            get { return secondLVCollection; }
            set { this.secondLVCollection = value; }
        }
        public ObservableCollection<PinnedInfo> FirstLVCollection
        {
            get { return firstLVCollection; }
            set { this.firstLVCollection = value; }
        }

        #endregion

        #region Generate Source

        internal void GenerateSource()
        {
            int busCount = 0;
            for (int i = 0; i < Gates.Count(); i++)
            {
                var record = new DepartureInfo();
                record.Name = Buses[busCount];
                record.RouteName = Routes[i];
                record.Gate = Gates[i];                          
                record.DepartureTime = DateTime.Now.AddHours( i % 2 == 0 ? 1.5:2);
                record.Icon = ImageSource.FromResource("FilterListView.Images." + "Bus"+busCount+".png");
                SecondLVCollection.Add(record);
                if (busCount == 4)
                    busCount = 0;
                else
                    busCount++;          
            }
            ItemTapCommand = new Command<Syncfusion.ListView.XForms.ItemTappedEventArgs>(ItemTapped);
            FavoriteTapCommand = new Command<object>(FavoriteTapped);
            ResetTapCommand = new Command<object>(ResetTapped);
        }

        private void ResetTapped(object obj)
        {
            secondLV.DataSource.Filter = null;
            secondLV.DataSource.RefreshFilter();
            firstLV.AllowSwiping = true;
        }

        private void FavoriteTapped(object obj)
        {
            var departureInfo = obj as DepartureInfo;
            var pinnedInfo = FirstLVCollection.Any(o => o.Name == departureInfo.Name) ? FirstLVCollection.First(o => o.Name == departureInfo.Name) : null;
            if (pinnedInfo == null)
            {
                FirstLVCollection.Add(new PinnedInfo() { Name = departureInfo.Name, RouteName = departureInfo.Name, Icon = departureInfo.Icon, IsFavorite = true });
            }
        }

        #endregion

        private void ItemTapped(Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            tappedPinedInfo = e.ItemData as PinnedInfo;
            if (tappedPinedInfo.IsFavorite)
            {
                secondLV.DataSource.Filter = FilterDepartures;
                tappedPinedInfo.IsFavorite = false;
            }
            else
            {
                secondLV.DataSource.Filter = null;
                tappedPinedInfo.IsFavorite = true;
            }
            secondLV.DataSource.RefreshFilter();
        }
        private bool FilterDepartures(object obj)
        {
            var departureInfo = obj as DepartureInfo;
            if (tappedPinedInfo == null)
                return true;

            if (departureInfo.Name.ToLower().Contains(tappedPinedInfo.Name.ToLower())
                 || departureInfo.RouteName.ToLower().Contains(tappedPinedInfo.RouteName.ToLower()))
                return true;
            else
                return false;
        }


        #region Employee Info

        string[] Buses = new string[]
         {
            "NJ Transit",
            "Express/Spanish Transportation",
            "Greyhound",
            "Ameribus/Saddle River",
            "Rockland Coach/Red & Tan"                                    
         };
        string[] Routes = new string[]
        {
            "Route 171",
            "Route 175",
            "Route 178",
            "Route 181",
            "Route 182",
            "Route 186",
            "Route 188" ,
            "Bergenline",
            "Paterson",
            "Boston",
            "Philadelphia/Washington DC",
            "Routes 11C and 20/84",
            "Route 9A/AT",
        };

        string[] Gates = new string[]
        {
            "Gate 12",
            "Gate 13",
            "Gate 17",
            "Gate 14",
            "Gate 18",
            "Gate 15",
            "Gate 11",
            "Gate 9 & 10",
            "Gate 20 & 21",
            "Gate 7",
            "Gate 8",
            "Gate 2",
            "Gate 1"                       
        };

        #endregion


    }
}
