using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XCountryTimer.Models;
using XCountryTimer.Views;
using XCountryTimer.ViewModels;
using System.Windows.Input;
using XCountryTimer.Services;

namespace XCountryTimer.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;
        public DateTime StartTime { get; set; }


        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel(new RunnerService());
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        async void Handle_Time_Entered(object sender, System.EventArgs e)
        {
            Button b = sender as Button;

            var id = b.AutomationId;
            var runner = viewModel.Items.Where(r => r.Id == id).FirstOrDefault();
            int theOne = runner.UpdateTime(DateTime.Now.Subtract(StartTime));
            HandleButtonEnablement(b, theOne);
            await viewModel.UpdateTime(runner, 0);

        }

        private bool HandleButtonEnablement(Button button, int theOne)
        {
            var stacker = button.Parent as StackLayout;
            var children = stacker.Children;
            var siblings = children.Where(c => c.GetType() == typeof(Button)).ToList();
            bool isSet = true;
            switch (theOne)
            {
                case 0:
                    siblings.First().IsEnabled = false;
                    break;
                case 1:
                    siblings.ElementAt(1).IsEnabled = false;
                    break;
                case 2:
                    siblings.Last().IsEnabled = false;
                    break;
                default: 
                    isSet = false;
                    break;
            }

            return isSet;
        }


        void Handle_Clicked(object sender, System.EventArgs e)
        {
            StartTime = DateTime.Now;

            Device.StartTimer(TimeSpan.FromSeconds(5), () =>
            {
                viewModel.ElapsedTime = DateTime.Now.Subtract(StartTime);

                foreach (string s in viewModel.AutomationIds)
                {

                }

                Device.BeginInvokeOnMainThread(() => viewModel.UpdateTimes());

                //foreach(Runner r in viewModel.Items)
                //{
                //    var obj = this.ItemsListView.FindByName(r.Name) as Button;
                //    obj.Text = viewModel.ElapsedTime.ToString("c");
                //}
                return true; // True = Repeat again, False = Stop the timer
            });
        }
    }
}