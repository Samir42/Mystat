using Mystat.UserControls;
using Mystat.View;
using Mystat.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mystat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public LoginWindow Lwd { get; set; }
        public MainWindowViewModel vm { get; set; }
        public MainWindow(MainWindowViewModel vm)
        {
            InitializeComponent();

            this.vm = vm;
            vm.MainGrid = Bottom;
            this.DataContext = this.vm;

            Bottom.Children.Clear();
            MainUC uc = new MainUC();
            MainViewModel mvm = new MainViewModel();
            uc.DataContext = mvm;
            Bottom.Children.Add(uc);

            this.DataContext = vm;
        }
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }
    }

}
