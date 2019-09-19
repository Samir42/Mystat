using Mystat.Domain.Data;
using MaterialDesignThemes.Wpf;
using Mystat.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Mystat.ViewModel
{
    public class HomeworkViewModel : BaseViewModel
    {
        public WrapPanel CurrentContainer { get; set; }
        public WrapPanel ReviewedContainer { get; set; }
        public WrapPanel OverdueContainer { get; set; }


        public HomeworkViewModel()
        {
            StudentHomeworks = new ObservableCollection<StudentHomework>(App.CurrentStudent.StudentHomeworks);
        }

        public void LoadViewControls()
        {
            CurrentContainer.Children.Clear();
            ReviewedContainer.Children.Clear();
            OverdueContainer.Children.Clear();

            foreach (var homework in StudentHomeworks)
            {
                HomeworkItemViewModel vm = new HomeworkItemViewModel();
                vm.StudentHomework = homework;
                if (homework.Homework.LastDay < DateTime.Now)
                {
                    //homework.Student.Points.
                    OverdueHomeworkItemUC uc = new OverdueHomeworkItemUC();
                    uc.DataContext = vm;
                    OverdueContainer.Children.Add(uc);
                }
                else if (homework.Homework.LastDay > DateTime.Now)
                {
                    HomeworkItem uc = new HomeworkItem();
                    uc.DataContext = vm;
                    CurrentContainer.Children.Add(uc);
                }
            }
        }





        public void LoadControls()
        {
            CurrentContainer.Children.Clear();

            #region MyRegion

            for (int i = 0; i < 5; i++)
            {
                Grid grid = new Grid()
                {
                    Margin = new Thickness(5),
                    Height = 150,
                    Width = 300,
                    Background = new SolidColorBrush(Colors.White)
                };

                RowDefinition rd1 = new RowDefinition();
                RowDefinition rd2 = new RowDefinition();
                rd2.Height = new GridLength(2.5, GridUnitType.Star);
                RowDefinition rd3 = new RowDefinition();

                grid.RowDefinitions.Add(rd1);
                grid.RowDefinitions.Add(rd2);
                grid.RowDefinitions.Add(rd3);



                #region Row2
                StackPanel sp = new StackPanel()
                {
                    Background = new SolidColorBrush(Colors.Black),
                    Orientation = Orientation.Horizontal,
                };
                Grid.SetRow(sp, 2);

                Label lb = new Label()
                {
                    Content = "22.09.2019",
                    Foreground = new SolidColorBrush(Colors.White)
                };

                PackIcon pi = new PackIcon()
                {
                    Kind = PackIconKind.ArrowDownBoldHexagonOutline,
                    Foreground = new SolidColorBrush(Colors.White),
                    VerticalAlignment = VerticalAlignment.Center,
                    Height = 25,
                    Width = 30
                };

                sp.Children.Add(lb);
                sp.Children.Add(pi);
                #endregion

                #region Row1
                Grid gr = new Grid();

                ColumnDefinition cd = new ColumnDefinition();
                ColumnDefinition cd2 = new ColumnDefinition();

                gr.ColumnDefinitions.Add(cd);
                gr.ColumnDefinitions.Add(cd2);

                Grid.SetRow(gr, 1);

                Grid gr_gr1 = new Grid() { };
                Grid gr_gr2 = new Grid() { };

                Grid.SetColumn(gr_gr1, 0);
                Grid.SetColumn(gr_gr2, 1);

                Button loadBtn = new Button()
                {
                    BorderThickness = new Thickness(0),
                    Background = null,
                    Height = 60,
                    Width = 50,
                };


                PackIcon gr_pi = new PackIcon()
                {
                    Foreground = new SolidColorBrush(Colors.Black),
                    Kind = PackIconKind.FileUpload,
                    Height = 50,
                    Width = 50
                };

                Button uploadBtn = new Button()
                {
                    BorderThickness = new Thickness(0),
                    Background = null,
                    Height = 60,
                    Width = 50,
                };


                PackIcon gr_pi2 = new PackIcon()
                {
                    Foreground = new SolidColorBrush(Colors.Black),
                    Kind = PackIconKind.FileDownload,
                    Height = 50,
                    Width = 50
                };

                uploadBtn.Content = gr_pi2;
                loadBtn.Content = gr_pi;

                gr_gr1.Children.Add(loadBtn);
                gr_gr2.Children.Add(uploadBtn);

                gr.Children.Add(gr_gr2);
                gr.Children.Add(gr_gr1);


                #endregion

                #region Row0
                StackPanel spanel = new StackPanel();
                Grid.SetRow(spanel, 0);

                Label lab = new Label() { Content = "Lesson 1" };

                spanel.Children.Add(lab);

                StackPanel span = new StackPanel()
                {
                    Width = 150,
                    Height = 20,
                    Background = new SolidColorBrush(Colors.White)
                };

                Label label = new Label()
                {
                    Content = new AccessText()
                    {
                        TextWrapping = TextWrapping.WrapWithOverflow,
                        Text = "Uwaglar dersi eledizmi ?"
                    }
                };

                span.Children.Add(label);

                PopupBox pbox = new PopupBox()
                {
                    HorizontalAlignment = HorizontalAlignment.Right,
                    PlacementMode = PopupBoxPlacementMode.BottomAndAlignCentres,
                    StaysOpen = false,
                    Margin = new Thickness(10, -30, 50, 0),
                    ToggleContent = new PackIcon() { Kind = PackIconKind.CommentMultipleOutline },
                    Content = span
                };
                PopupBox pbox2 = new PopupBox()
                {
                    HorizontalAlignment = HorizontalAlignment.Right,
                    PlacementMode = PopupBoxPlacementMode.BottomAndAlignCentres,
                    StaysOpen = false,
                    Margin = new Thickness(10, -30, 20, 0),
                    ToggleContent = new PackIcon() { Kind = PackIconKind.InfoVariant },
                    Content = span
                };

                spanel.Children.Add(pbox2);
                spanel.Children.Add(pbox);

                #endregion


                grid.Children.Add(gr);
                grid.Children.Add(sp);
                grid.Children.Add(spanel);

                CurrentContainer.Children.Add(grid);
            }

            #endregion
        }
        #region FullProperties
        private ObservableCollection<StudentHomework> studentHomeworks;

        public ObservableCollection<StudentHomework> StudentHomeworks
        {
            get { return studentHomeworks; }
            set
            {
                if (value == studentHomeworks) return;

                studentHomeworks = value;
                OnPropertyChanged();
            }
        }



        #endregion
    }
}
