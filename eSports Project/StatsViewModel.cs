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
        private string _vip;
        private string _reg;
        private string _vipLoot;
        private string _regLoot;
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

        public string Vip
        {
            get
            {
                return _vip;
            }

            set
            {
                if (_vip != value)
                {
                    _vip = value;
                    NotifyPropertyChanged("Vip");
                }
            }
        }

        public string Reg
        {
            get
            {
                return _reg;
            }

            set
            {
                if (_reg != value)
                {
                    _reg = value;
                    NotifyPropertyChanged("Reg");
                }
            }
        }

        public string VIPLoot
        {
            get
            {
                return _vipLoot;
            }

            set
            {
                if (_vipLoot != value)
                {
                    _vipLoot = value;
                    NotifyPropertyChanged("VIPLoot");
                }
            }
        }

        public string RegLoot
        {
            get
            {
                return _regLoot;
            }

            set
            {
                if (_regLoot != value)
                {
                    _regLoot = value;
                    NotifyPropertyChanged("RegLoot");
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
