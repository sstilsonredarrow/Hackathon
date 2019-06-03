using System;
using MvvmCross.ViewModels;
using XCountryCore.ViewModels;
using Autofac;
using XCountryCore.Services;
using XCountryCore.Models;
using MvvmCross;

namespace XCountryCore
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();
            var builder = new ContainerBuilder();
            Mvx.IoCProvider.RegisterType<IRunnerService, RunnerService>();
            Mvx.IoCProvider.RegisterType<IDataStore<RunnerViewModel>, MockDataStore> ();
            RegisterAppStart<MainViewModel>();
        }
    }
}
