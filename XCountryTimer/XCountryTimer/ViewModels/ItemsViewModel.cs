using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using XCountryTimer.Models;
using XCountryTimer.Services;
using XCountryTimer.Views;

namespace XCountryTimer.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {

        private ObservableCollection<Runner> _items;
        public ObservableCollection<Runner> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        public Command LoadItemsCommand { get; set; }
        public Command HandleSplit1Command { get; set; }
        public ObservableCollection<Runner> Runners { get; set; }
        public TimeSpan ElapsedTime { get; set; }
        private IRunnerService _runnerService;

        public List<string> AutomationIds { get; set; }

        public ItemsViewModel(IRunnerService runnerService)
        {
            Title = "Varsity Race";
            Items = new ObservableCollection<Runner>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            HandleSplit1Command = new Command(async () => await UpdateTimeCommand());
            AutomationIds = new List<string>();
            _runnerService = runnerService;
            

            MessagingCenter.Subscribe<NewItemPage, Runner>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Runner;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });
        }

        async Task UpdateTimeCommand()
        {

            await Task.Delay(0);
        }

        public async Task UpdateTime(Runner runner, int whichTime)
        {
            await _runnerService.SaveTimeAsync(runner);
        }

        public void UpdateTimes()
        {

            ObservableCollection<Runner> runners = new ObservableCollection<Runner>();
            foreach(Runner runner in Items)
            {

                if ( !runner.Split1Set) runner.Split1 = ElapsedTime.ToString(@"hh\:mm\:ss");
                if (!runner.Split2Set) runner.Split2 = ElapsedTime.ToString(@"hh\:mm\:ss");
                if (!runner.FinishSet) runner.Finish = ElapsedTime.ToString(@"hh\:mm\:ss");
                runners.Add(runner);
            }

            Items.Clear();
            runners.ForEach(r =>
            {
                Items.Add(new Runner
                {
                    Name = r.Name,
                    Split1 = r.Split1,
                    Split2 = r.Split2,
                    Finish = r.Finish,
                    Id = r.Id,

                    Split1Set = r.Split1Set,
                    Split2Set = r.Split2Set,
                    FinishSet = r.FinishSet
                });
            });
           // Items = runners;
            //Items.ForEach((r) =>
            //{
            //    r.Split1 = ElapsedTime.ToString("mm:ss.fff");
            //});
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                    AutomationIds.Add(item.Id);
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