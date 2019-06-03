using System;
using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCross.ViewModels;

namespace XCountryCore.ViewModels
{
    public class AboutViewModel : MvxViewModel
    {
        public AboutViewModel()
        {
            //Title = "About Renaissance (The source of this app)";

            //OpenWebCommand = new MvxCommand(() => Device.OpenUri(new Uri("https://www.renaissance.com/?utm_source=google&utm_medium=cpc&utm_campaign=general&gclid=EAIaIQobChMIxsa5lOOi4gIV0YZbCh22vAiiEAAYASAAEgLC_PD_BwE")));
        }

        public IMvxCommand OpenWebCommand { get; }
    }
}