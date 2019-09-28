using Mystat.Command;
using Mystat.UserControls;
using Mystat.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Mystat.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public StackPanel Entry { get; set; }
        public LoginWindow lwd { get; set; }
        public RelayCommand ForgotPasswordCommand => new RelayCommand(e =>
        {
            Entry.Children.Clear();
            RepairPasswordUC uc = new RepairPasswordUC();
            RepairPasswordViewModel vm = new RepairPasswordViewModel();

            vm.Entry = this.Entry;

            uc.DataContext = vm;

            Entry.Children.Add(uc);
        });

        public RelayCommand LoginCommand => new RelayCommand(e =>
        {
            var IsExist = App.db.StudentRepository.Exist(Login, Password);

            if (IsExist)
            {
                App.CurrentStudent = App.db.StudentRepository.GetStudentByUsername(login);

                MainWindowViewModel vm = new MainWindowViewModel();
                MainWindow wd = new MainWindow(vm);
                wd.Lwd = this.lwd;
                vm.Mwd = wd;
                lwd.Close();
                wd.Show();

            }
            else MessageBox.Show("No!");
        });

       

        private String login = "";

        public String Login
        {
            get { return login; }
            set { login = value; }
        }


        private String password = "";

        public String Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}
