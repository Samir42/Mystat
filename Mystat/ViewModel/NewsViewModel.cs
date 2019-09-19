using Mystat.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace Mystat.ViewModel
{
    public class NewsViewModel : BaseViewModel
    {
        public WrapPanel NewsContainer { get; set; }
        public NewsViewModel()
        {
            News = new List<News>(App.db.NewsRepository.GetAll());
        }

        public void LoadViewControls()
        {
            LoadBorders();
        }

        private void LoadBorders()
        {
            NewsContainer.Children.Clear();
            for (int i = 0; i < News.Count; i++)
            {
                Border border = new Border();
                border.Height = 200; border.Width = 290;
                border.Background = Brushes.White;
                border.BorderThickness = new Thickness(0, 3, 0, 0);
                border.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#28D4CA"));
                DropShadowEffect dse = new DropShadowEffect();
                dse.Color = Color.FromRgb(224, 229, 233);


                border.Effect = dse;
                border.Margin = new Thickness(5);

                //if (i == 0)
                //    border.Margin = new Thickness(0, 0, 0, 20);
                //else
                //    border.Margin = new Thickness(20, 0, 0, 20);


                //----
                Grid grid = new Grid();

                grid.Margin = new Thickness(10);

                Label label = new Label();
                label.Foreground = Brushes.Black;

                AccessText at = new AccessText();
                at.TextWrapping = TextWrapping.WrapWithOverflow;
                at.Text = News[i].Content;

                label.Content = at;

                Label label2 = new Label();
                label2.Foreground = Brushes.Black;
                label2.Content = News[i].CreatedAt;
                label2.VerticalAlignment = VerticalAlignment.Bottom;

                grid.Children.Add(label);
                grid.Children.Add(label2);


                border.Child = grid;

                NewsContainer.Children.Add(border);
            }
        }

       


        private List<Border> borders;

        public List<Border> Borders
        {
            get { return borders; }
            set { borders = value; }
        }


        private List<News> news;

        public List<News> News
        {
            get { return news; }
            set
            {
                if (value == news) return;

                news = value;

                OnPropertyChanged();
            }
        }

    }
}
