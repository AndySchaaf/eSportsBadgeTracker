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
        private string _walkin;
        private string _vip;
        private string _regular;
        private string _regbags;
        private string _vipbags;
        private string _totbags;
        private string _male;
        private string _female;
        private string _other;
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
                changeCheck(ref _registered,ref value,"Registered");
            }
        }

        public string Checkedin
        {
            get
            {
                return _checkedin;
            }

            set
            {
                changeCheck(ref _checkedin, ref value, "Checkedin" );
            }
        }

        public string Walkin
        {
            get
            {
                return _walkin;
            }

            set
            {
                changeCheck(ref _walkin ,ref value , "Walkin");
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
                changeCheck(ref _vip ,ref value , "Vip");
            }
        }

        public string Regular
        {
            get
            {
                return _regular;
            }

            set
            {
                changeCheck(ref _regular,ref  value,"Regular");
            }
        }

        public string Regbags
        {
            get
            {
                return _regbags;
            }

            set
            {
                changeCheck(ref _regbags, ref value, "Regbags");
            }
        }

        public string Vipbags
        {
            get
            {
                return _vipbags;
            }

            set
            {
                changeCheck(ref _vipbags, ref value, "Vipbags");
            }
        }

        public string Totbags
        {
            get
            {
                return _totbags;
            }

            set
            {
                changeCheck(ref _totbags, ref value, "Totbags");
            }
        }

        public string Male
        {
            get
            {
                return _male;
            }

            set
            {
                changeCheck(ref _male, ref value, "Male");
            }
        }

        public string Female
        {
            get
            {
                return _female;
            }

            set
            {
                changeCheck(ref _female, ref value, "Female");
            }
        }

        public string Other
        {
            get
            {
                return _other;
            }

            set
            {
                changeCheck(ref _other, ref value, "Other");
            }
        }
        #endregion Properties

        public StatsViewModel() { }
        private void changeCheck(ref string orig , ref string val , string propertyName) {
            if(!EqualityComparer<string>.Default.Equals(orig, val))
            {
                orig = val;
                NotifyPropertyChanged(propertyName);
            }
        }

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
