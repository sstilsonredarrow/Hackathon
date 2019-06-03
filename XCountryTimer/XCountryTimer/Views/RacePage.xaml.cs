using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XCountryCore.Models;
using XCountryTimer.Views;
using XCountryCore.ViewModels;
using XCountryCore.Services;

namespace XCountryTimer.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class RacePage : ContentPage
    {
    
       // RaceViewModel viewModel;

        public RacePage()
        {
            InitializeComponent();

           // BindingContext = viewModel = new RaceViewModel(new RunnerService());
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            //var item = args.SelectedItem as Item;
            //if (item == null)
            //    return;

            //await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            //// Manually deselect item.
            //RunnerListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

          //  if (viewModel.Runners == null || viewModel.Runners.Count == 0)
             //   viewModel.LoadItemsCommand.Execute(null);
        }
    }
}