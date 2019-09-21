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
    public class MainWindowViewModel : BaseViewModel
    {
        public LoginWindow Lwd { get; set; }
        public MainWindow Mwd { get; set; }
        public Grid MainGrid { get; set; }
        public RelayCommand LoadHomeCommand => new RelayCommand(e =>
        {
            MainGrid.Children.Clear();
            MainUC puc = new MainUC();
            puc.Padding = new Thickness(5);
            MainViewModel pvm = new MainViewModel();
            puc.DataContext = pvm;
            MainGrid.Children.Add(puc);
        });

        public RelayCommand GoBackToLoginCommand => new RelayCommand(e =>
        {
            LoginWindow lwd = new LoginWindow();
            lwd.Show();
            this.Mwd.Close();

        });

        public RelayCommand LoadHomeworkCommand => new RelayCommand(e =>
        {
            MainGrid.Children.Clear();
            HomeWorkUC uc = new HomeWorkUC();
            HomeworkViewModel vm = new HomeworkViewModel();
            vm.MainGrid = this.MainGrid;

            vm.CurrentContainer = uc.CurrentContainer;
            vm.OverdueContainer = uc.OverdueContainer;
            vm.ReviewedContainer = uc.ReviewedContainer;
            vm.UnderReviewContainer = uc.UnderReviewContainer;

            vm.LoadViewControls();
            uc.DataContext = vm;

            MainGrid.Children.Add(uc);
        });

        public RelayCommand LoadProgressCommand => new RelayCommand(e =>
        {
            MainGrid.Children.Clear();
            ProgressUC puc = new ProgressUC();
            ProgressViewModel pvm = new ProgressViewModel();
            pvm.Container = puc.Container;
            puc.DataContext = pvm;
            pvm.LoadViewControls();
            MainGrid.Children.Add(puc);
        });

        public RelayCommand LoadSettingsCommand => new RelayCommand(e =>
        {
            MainGrid.Children.Clear();
            SettingUC uc = new SettingUC();
            SettingViewModel svm = new SettingViewModel();
            uc.DataContext = svm;
            MainGrid.Children.Add(uc);
        });

        public RelayCommand LoadPaymentCommand => new RelayCommand(e =>
        {
            MainGrid.Children.Clear();
            PaymentUC uc = new PaymentUC();
            MainGrid.Children.Add(uc);
        });

        public RelayCommand LoadNewsCommand => new RelayCommand(e =>
        {
            MainGrid.Children.Clear();
            NewsUC uc = new NewsUC();
            NewsViewModel nvm = new NewsViewModel();
            nvm.NewsContainer = uc.NewsContainer;
            nvm.LoadViewControls();
            uc.DataContext = nvm;
            MainGrid.Children.Add(uc);
        });

        public RelayCommand LoadContactCommand => new RelayCommand(e =>
        {
            MainGrid.Children.Clear();
            ContactUC uc = new ContactUC();
            ContactViewModel vm = new ContactViewModel();
            uc.DataContext = vm;
            MainGrid.Children.Add(uc);
        });

        #region FullProperties
        private String fullname;

        public String Fullname
        {
            get => App.CurrentStudent.Fullname;

            set
            {
                if (value == fullname) return;

                fullname = value;

                OnPropertyChanged();
            }
        }

        private String groupName;

        public String GroupName
        {
            get => App.CurrentStudent.Group.Name;

            set
            {
                if (value == groupName) return;

                groupName = value;

                OnPropertyChanged();
            }
        }



        private int coinCount;

        public int CoinCount
        {
            get
            {
                var hw = App.CurrentStudent.Points.Where(x => x.PointStatu.Status == "Homework" || x.PointStatu.Status == "Examination" ||
                                                              x.PointStatu.Status == "Labs" || x.PointStatu.Status == "Classwork");



                return hw.Sum(x => x.Point1.Value);
            }
            set
            {

                coinCount = value;

                OnPropertyChanged();
            }
        }


        private int diamondCount;

        public int DiamondCount
        {
            get
            {
                var hw = App.CurrentStudent.Points.Where(x => x.PointStatu.Status == "Attendance" || x.PointStatu.Status == "Activity");

                return hw.Sum(x => x.Point1.Value);
            }
            set
            {
                if (value == diamondCount) return;

                diamondCount = value;

                OnPropertyChanged();
            }
        }

        private int generalPoint;

        public int GeneralPoint
        {
            get
            {
                return CoinCount + DiamondCount;
            }
            set
            {

                generalPoint = value;

                OnPropertyChanged();
            }
        }
        #endregion
    }
}
