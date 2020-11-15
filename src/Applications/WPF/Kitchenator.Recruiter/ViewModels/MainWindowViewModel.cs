using Dolittle.SDK;
using kitchenator.Domain;
using kitchenator.Domain.Concepts.Addresses;
using kitchenator.Domain.Concepts.Employees;
using kitchenator.Domain.Contracts;
using kitchenator.Domain.Contracts.Managers;
using kitchenator.Domain.Contracts.Readers;
using kitchenator.Domain.Events.Employment;
using Kitchenator.Wpf.Common;
using PubSub;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Kitchenator.Recruiter.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        readonly IEmployeeReader       _chefReader;
        readonly ICountriesLoader  _countriesLoader;
        private  List<Country>     _countries;
        ObservableCollection<Employee> _hiredChefs;
        Employee                       _selectedChef;
        RelayCommand               _hireCommand;
        Client                     _dolittleClient;

        public MainWindowViewModel(Window owningWindow, Hub hub)
            : base(owningWindow, hub)
        {
            _hiredChefs     = new ObservableCollection<Employee>();
            _chefReader     = App.DependencyResolver.GetInstance<IEmployeeReader>();
            _countriesLoader  = App.DependencyResolver.TryGetInstance<ICountriesLoader>();
            _dolittleClient = BuildDolittleClient();
            _selectedChef   = new Employee();
            
            owningWindow.Loaded += async(s, e) =>  await OwningWindow_Loaded(s, e);
        }

        public ObservableCollection<Employee> HiredChefs
        {
            get { return _hiredChefs; }
            set { Announce(() => _hiredChefs = value); }
        }

        public Employee SelectedChef
        {
            get { return _selectedChef; }
            set { Announce(() => _selectedChef = value); }
        }

        public ICommand HireCommand 
        {
            get
            {
                _hireCommand ??= new RelayCommand(async () => await HireChef());
                return _hireCommand;
            }
        }

        public List<Country> Countries
        {
            get { return _countries; }
            set { Announce(() => _countries = value); }
        }

        private async Task HireChef()
        {
            if (this.SelectedChef is null)
                return;

            SelectedChef.Id = Guid.NewGuid();
            //var chefCreated = new ChefCreated(SelectedChef);
            //await _dolittleClient.EventStore
            //    .ForTenant(TenantId.Development)
            //    .Commit(chefCreated, chefCreated.EmployeeId);
            await Task.CompletedTask;
        }



        private async Task OwningWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var chefs  = await _chefReader.GetAll();
            HiredChefs = new ObservableCollection<Employee>(chefs);


            var initializer = _countriesLoader as IMustBeInitialized;
            await initializer.Initialize();

            Countries = _countriesLoader.Countries.ToList();
        }

        private static Client BuildDolittleClient()
        {
            var settings = MicroserviceConfiguration.Dolittle;
            return Client
                .ForMicroservice(settings.ServiceId)
                .WithEventTypes(eventTypes => eventTypes.Register<HireNewEmployee>())
                .WithRuntimeOn(settings.HostName, settings.HostPort)
                .Build();
        }
    }
}