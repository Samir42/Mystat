using Mystat.Domain.Data;
using Mystat.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Mystat.ViewModel
{
    public class ReviewedHomeworkItemViewModel :BaseViewModel
    {
        public RelayCommand DownloadFileCommand => new RelayCommand(x =>
        {
            MessageBox.Show($"{StudentHomework.SentAt.Value.ToShortDateString()} downloaded");
        });

        public RelayCommand UploadFileCommand => new RelayCommand(x =>
        {
            MessageBox.Show($"{StudentHomework.SentAt.Value.ToShortDateString()} uploaded");
        });


        private StudentHomework studentHomework;

        public StudentHomework StudentHomework
        {
            get { return studentHomework; }
            set
            {
                if (value == studentHomework) return;

                studentHomework = value;

                OnPropertyChanged();
            }
        }
    }
}
