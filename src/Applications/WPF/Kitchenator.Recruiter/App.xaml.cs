using Kitchenator.Recruiter.DependencyInversion;
using System.Windows;

namespace Kitchenator.Recruiter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static Lamar.Container _lamarContainer = new Lamar.Container(new RuntimeRegistry());

        public static Lamar.Container DependencyResolver => _lamarContainer;
    }
}
