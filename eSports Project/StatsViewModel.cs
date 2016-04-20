using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSportsBadgeTracker
    //@Registered int output,
    //@CheckedIn int output,
    //@UnRegistered int output,
    //@VIPBadges int output,
    //@RegBadges int output,
    //@LootBags int output,
    //@MealTickets int output,
    //@unTickets int output
{
    public class StatsViewModel : INotifyPropertyChanged
    {


        #region Members
        private string _registered;
        private string _checkedin;
        private string _unregistered;
        private string _vipGuest;
        private string _regGuest;
        private string _REGBags;
        private string _VIPBags;
        private string _untick;

        #endregion Members

        #region Properties
        public string Registered
        {
            get
            {
                return _registered;
            }
            set
            {
                if (_registered != value) { 
                    _registered = value;
                    NotifyPropertyChanged("Registered");
                }
            }
        }

        public string CheckedIn
        {
            get
            {
                return _checkedin;
            }
            set
            {
                if (_checkedin  != value)
                {
                    _checkedin = value;
                    NotifyPropertyChanged("CheckedIn");
                }
            }
        }

        public string Untick
        {
            get
            {
                return _untick;
            }

            set
            {
                if (_untick != value)
                {
                    _untick = value;
                    NotifyPropertyChanged("Untick");
                }
            }
        }

        public string Unregistered
        {
            get
            {
                return _unregistered;
            }

            set
            {
                if (_unregistered != value)
                {
                    _unregistered = value;
                    NotifyPropertyChanged("Unregistered");
                }
            }
        }

        public string VipGuest
        {
            get
            {
                return _vipGuest;
            }

            set
            {
                if (_vipGuest != value)
                {
                    _vipGuest = value;
                    NotifyPropertyChanged("VipGuest");
                }
            }
        }

        public string RegGuest
        {
            get
            {
                return _regGuest;
            }

            set
            {
                if (_regGuest != value)
                {
                    _regGuest = value;
                    NotifyPropertyChanged("RegGuest");
                }
            }
        }

        public string VIPBags
        {
            get
            {
                return _VIPBags;
            }

            set
            {
                if (_VIPBags != value)
                {
                    _VIPBags = value;
                    NotifyPropertyChanged("VIPBags");
                }
            }
        }

        public string REGBags
        {
            get
            {
                return _REGBags;
            }

            set
            {
                if (_REGBags != value)
                {
                    _REGBags = value;
                    NotifyPropertyChanged("REGBags");
                }
            }
        }

        #endregion Properties

        public StatsViewModel() { }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
