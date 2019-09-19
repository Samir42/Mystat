using Mystat.Domain.Data;
using Mystat.AdditionalClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Mystat.ViewModel
{
    public class ProgressViewModel : BaseViewModel
    {
        public WrapPanel Container { get; set; }
        public ProgressViewModel()
        {
            Points = new List<Mystat.Domain.Data.Point>(App.CurrentStudent.Points);
            Lessons = new List<Lesson>(App.CurrentStudent.Group.Lessons);
            Lessons = new List<Lesson>(Lessons.OrderByDescending(x => x.StartedAt));
        }

        public void LoadViewControls()
        {
            LoadBorders();
        }
        private void LoadBorders()
        {
            Container.Children.Clear();

            for (int i = 0; i < Lessons.Count; i++)
            {
                Border border = new Border();
                border.Height = 80; border.Width = 80;
                border.Margin = new Thickness(3);
                border.Background = Brushes.White;

                Grid grid = new Grid();


                Label date = new Label();
                date.Foreground = Brushes.Black;
                date.Content = Lessons[i].StartedAt.Value.ToShortDateString();
                date.FontSize = 13;
                date.HorizontalAlignment = HorizontalAlignment.Center;
                date.VerticalAlignment = VerticalAlignment.Top;

                Label point = new Label();
                point.Foreground = Brushes.Black;
                point.Content = Lessons.Count - i;
                point.HorizontalAlignment = HorizontalAlignment.Center;
                point.VerticalAlignment = VerticalAlignment.Center;


                Label label3 = new Label();
                label3.Foreground = Brushes.Black;
                label3.FontSize = 16;
                label3.VerticalAlignment = VerticalAlignment.Bottom;
                label3.HorizontalAlignment = HorizontalAlignment.Right;

                //var price = Lessons.FirstOrDefault(l => l.Points.FirstOrDefault(p => p.LessonId == l.Id).Id == Points[i].LessonId);
                PointStatu status = null;

                var res = Lessons[i].Points.Where(x => x.LessonId == Lessons[i].Id || x.StudentId == App.CurrentStudent.Id);


                var currentStudentPoint = res.FirstOrDefault(x => x.StudentId == App.CurrentStudent.Id);

                if (currentStudentPoint != null)
                {
                    currentStudentPoint.PointStatu = Points.FirstOrDefault(x => x.Id == currentStudentPoint.Id).PointStatu;
                    label3.Content = currentStudentPoint.Point1.Value;

                    if (currentStudentPoint.PointStatu.Status == "Homework")
                    {
                        label3.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#1BD2C7"));
                        border.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFAAAA"));
                    }
                    else if (currentStudentPoint.PointStatu.Status == "Labs")
                    {
                        label3.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#62B6FE"));
                        border.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFAAAA"));
                    }
                    else if (currentStudentPoint.PointStatu.Status == "Classwork")
                    {
                        label3.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFC730"));
                        border.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#F1F6FA"));
                    }
                    else
                        border.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#F1F6FA"));

                }
                else
                    border.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#F1F6FA"));


                //if (status != null)
                //{

                //}

                grid.Children.Add(date);
                grid.Children.Add(point);
                grid.Children.Add(label3);

                border.Child = grid;

                Container.Children.Add(border);
            }
        }
        private List<Lesson> lessons;

        public List<Lesson> Lessons
        {
            get { return lessons; }
            set
            {
                if (value == lessons) return;

                lessons = value;

                OnPropertyChanged();
            }
        }

        private List<Mystat.Domain.Data.Point> points;

        public List<Mystat.Domain.Data.Point> Points
        {
            get { return points; }
            set
            {
                if (value == points) return;

                points = value;

                OnPropertyChanged();
            }
        }
    }
}
