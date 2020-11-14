using KitchenatorReporter.ViewModels;
using PubSub;
using System.Windows;

namespace KitchenatorReporter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Hub _defaultHub = new Hub();
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new MainWindowViewModel(this, _defaultHub);
        }
    }
}
