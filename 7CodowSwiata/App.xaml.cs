using System.Windows;
using GalaSoft.MvvmLight.Threading;

namespace _7CodowSwiata
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static App()
        {
            DispatcherHelper.Initialize();
        }
    }
}
