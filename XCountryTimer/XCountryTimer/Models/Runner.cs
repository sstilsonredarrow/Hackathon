using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace XCountryTimer.Models
{
    public class Runner : INotifyPropertyChanged
    {
        public Runner()
        {
        }

        public string Name { get; set; }
        public string Split1 { get; set; }
        public string Split2 { get; set; }
        public string Finish { get; set; }
        public string Id { get; set; }

        public bool Split1Set { get; set; }
        public bool Split2Set { get; set; }
        public bool FinishSet { get; set; }

        public int UpdateTime (TimeSpan ts)
        {
            if (!Split1Set)
            {
                Split1 = ts.ToString(@"hh\:mm\:ss");
                Split1Set = true;
                return 0;
            }

            if (!Split2Set)
            {
                Split2 = ts.ToString(@"hh\:mm\:ss");
                Split2Set = true;
                return 1;
            }
            else
            {
                Finish = ts.ToString(@"hh\:mm\:ss");
                FinishSet = true;
                return 2;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
