using Mystat.Command;
using Mystat.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Mystat.ViewModel
{
    public class RepairPasswordViewModel : BaseViewModel
    {
        public StackPanel Entry { get; set; }
        public RelayCommand GoToBackCommand => new RelayCommand(e =>
        {
            Entry.Children.Clear();

            LoginUC uc = new LoginUC();
            LoginViewModel vm = new LoginViewModel();
            vm.Entry = this.Entry;
            uc.DataContext = vm;

            Entry.Children.Add(uc);
        });
    }
}
