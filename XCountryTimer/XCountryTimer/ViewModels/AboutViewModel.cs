using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace XCountryTimer.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About Renaissance (The source of this app)";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://www.renaissance.com/?utm_source=google&utm_medium=cpc&utm_campaign=general&gclid=EAIaIQobChMIxsa5lOOi4gIV0YZbCh22vAiiEAAYASAAEgLC_PD_BwE")));
        }

        public ICommand OpenWebCommand { get; }
    }
}