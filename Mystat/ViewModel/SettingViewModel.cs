using Mystat.Domain.Data;
using Microsoft.Win32;
using Mystat.AdditionalClasses;
using Mystat.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using Point = Mystat.Domain.Data.Point;

namespace Mystat.ViewModel
{
    public class SettingViewModel : BaseViewModel
    {
        string FileName { get;set; } = "";
        public RelayCommand OpenFileDialogCommand => new RelayCommand(e=> {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "(*.jpg)|*.png";
            openFileDialog1.ShowDialog();
            FileName = openFileDialog1.FileName;

            var bytes = ImageHelper.GetBytesOfImage(FileName);

            ImageOperation operation = new ImageOperation();
            operation.Bytes = bytes;
        });


        public RelayCommand SaveCommand => new RelayCommand(e=> {
            //MathHelper.CalculatePercentage(App.CurrentStudent);
            this.Student.Points = new List<Point>();
            this.Student.Comments = new List<Comment>();
            App.db.StudentRepository.Update(this.Student);

            App.CurrentStudent = App.db.StudentRepository.GetStudentById(App.CurrentStudent.Id);
        });

        public SettingViewModel()
        {
            Student = App.CurrentStudent;
        }

        #region Full Properties


        private double to = MathHelper.CalculatePercentage(App.CurrentStudent);

        public double To
        {
            get => to;

            set { to = value; }
        }


        private Student student;
        public Student Student
        {
            get { return student; }
            set { student = value; }
        }
        #endregion
    }
}
