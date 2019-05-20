using System;
using XCountryTimer.Services;
using Autofac;
using System.Collections.Generic;
using XCountryTimer.Models;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace XCountryTimer.ViewModels
{
    public class RaceViewModel : BaseViewModel  //Using the crap ass Xamarin ViewModels instead of MvvMCross just to save time.
    {
        public ObservableCollection<Runner> Runners;
        IRunnerService _runnerService;

        public Command LoadItemsCommand { get; set; }

        public RaceViewModel(IRunnerService runnerService)
        {
            _runnerService = runnerService;
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            Runners = new ObservableCollection<Runner>();
            Title = "Race";
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            try
            {
                Runners.Clear();
                var runners = await _runnerService.GetRunnerFauxData();
                foreach (var runner in runners)
                {
                    Runners.Add(runner);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }


        }

    }
}
