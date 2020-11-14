using Dolittle.SDK;
using kitchenator.Domain;
using kitchenator.Domain.Events;
using Kitchenator.Wpf.Common;
using KitchenatorReporter.Models;
using PubSub;
using System.Collections.ObjectModel;
using System.Linq;

namespace KitchenatorReporter.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly Client                   _client;
        readonly DishCounterHandler               _handler;
        private ObservableCollection<CountedChef> _statusList;
        private ObservableCollection<CountedDish> _mealList;

        public MainWindowViewModel(MainWindow mainWindow, Hub hub)
            : base(mainWindow, hub)
        {
            _handler = new DishCounterHandler(hub);
            var settings = MicroserviceConfiguration.Dolittle;

            var builder = Client.ForMicroservice(settings.ServiceId)                
                .WithEventTypes(eventTypes => eventTypes.Register<DishPrepared>())
                .WithEventHandlers(builder => builder.RegisterEventHandler<DishCounterHandler>(_handler));
            
            _client = builder.Build();

            // Local event subscriptions
            Hub.Subscribe<CountedChef>(HandleUpdatesToDishCount);
            Hub.Subscribe<CountedDish>(HandleDishServed);
        }

        private void HandleDishServed(CountedDish countedDish)
        {
            ThisWindow.Dispatcher.Invoke(() =>
            {
                _mealList ??= new ObservableCollection<CountedDish>();
                var found = _mealList.FirstOrDefault(m => m.Dish == countedDish.Dish);
                if (found is { })
                {
                    _mealList.Remove(found);
                }
                
                _mealList.Add(countedDish);
                DishesServed = new ObservableCollection<CountedDish>(_mealList.OrderByDescending(c => c.Count));
            });
        }

        private void HandleUpdatesToDishCount(CountedChef countedChef)
        {
            ThisWindow.Dispatcher.Invoke(() =>
            {
                _statusList ??= new ObservableCollection<CountedChef>();
                var found = _statusList.FirstOrDefault(c => c.Chef == countedChef.Chef);
                if(found is { })
                {
                    _statusList.Remove(found);
                }
                _statusList.Add(countedChef);
                ChefsList = new ObservableCollection<CountedChef>(_statusList.OrderByDescending(c => c.Count));
            });
        }

        public ObservableCollection<CountedDish> DishesServed
        {
            get { return _mealList; }
            set { Announce(() => _mealList = value); }
        }

        public ObservableCollection<CountedChef> ChefsList
        {
            get { return _statusList; }
            set { Announce(() => _statusList = value); }
        }
    }
}
