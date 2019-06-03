using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XCountryCore.Services;
using XCountryTimer.Views;
using Autofac;

namespace XCountryTimer
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            //var builder = new ContainerBuilder();
            //builder.RegisterType<RunnerService>().As<IRunnerService>();
            //DependencyService.Register<MockDataStore>();
            //MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
