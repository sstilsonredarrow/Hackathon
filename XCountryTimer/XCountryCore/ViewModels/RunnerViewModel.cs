﻿using System;
using MvvmCross.ViewModels;

namespace XCountryCore.ViewModels
{
    public class RunnerViewModel : MvxViewModel
    {
        public string Name { get; set; }
        private string _split1;
        private string _split2;
        private string _finish;
        private bool _enabled;

        public RunnerViewModel()
        {
            _enabled = false;
        }

        public bool Enabled { 
        get
            {
                return _enabled;
            } 
            set
            {
                _enabled = value;
                RaisePropertyChanged(nameof(Enabled));
            }

        }

        public string Split1
        {
            get { return _split1; }
            set { _split1 = value; RaisePropertyChanged(nameof(Split1)); }
        }
        public string Split2
        {
            get { return _split2; }
            set { _split2 = value;  RaisePropertyChanged(nameof(Split2)); }
        }
        public string Finish
        {
            get { return _finish; }
            set { _finish = value; RaisePropertyChanged(nameof(Finish)); }
        }
        public string Id { get; set; }

        public bool Split1Set { get; set; }
        public bool Split2Set { get; set; }
        public bool FinishSet { get; set; }

        public int UpdateTime(TimeSpan ts)
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
    }
}
