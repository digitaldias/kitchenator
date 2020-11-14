using Kitchenator.Recruiter.ViewModels;
using PubSub;
using System.Windows;

namespace Kitchenator.Recruiter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Hub _hub = Hub.Default;

        public MainWindow()
        {
            DataContext = new MainWindowViewModel(this, _hub);
            InitializeComponent();
        }
    }
}
