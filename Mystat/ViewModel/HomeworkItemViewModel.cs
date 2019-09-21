using Mystat.Domain.Data;
using Mystat.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using Mystat.AdditionalClasses;
using System.Diagnostics;
using System.Windows.Controls;
using Mystat.UserControls;

namespace Mystat.ViewModel
{
    public class HomeworkItemViewModel : BaseViewModel
    {
        public Grid MainGrid { get; set; }
        public RelayCommand DownloadFileCommand => new RelayCommand(x =>
        {
            var res = App.db.StudentHomeworkRepository.GetStudentHomeworkById(StudentHomework.HomeworkId);

            FileHelper.SaveFile($@"C:\Users\SAMIR\Desktop\MyHomeworks\babatHomework3.txt", res.Homework.FileBytes);

            Process.Start($@"C:\Users\SAMIR\Desktop\MyHomeworks\babatHomework3.txt");
        });

        public RelayCommand UploadFileCommand => new RelayCommand(x =>
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "(*.txt)|*.txt";
            openFileDialog.ShowDialog();

            String fileName = openFileDialog.FileName;

            if (fileName != null)
            {
                Homework.FileBytes = FileHelper.GetBytesOfFile(fileName);
                Homework.HomeworkId = StudentHomework.HomeworkId;
                Homework.StudentId = App.CurrentStudent.Id;
                Homework.SentAt = DateTime.Now;
                Homework.Checked = StudentHomework.Checked;
                Homework.Id = StudentHomework.Id;

                if (fileName.EndsWith(".pdf")) Homework.File = ".pdf";
                else Homework.File = ".txt";

                App.db.StudentHomeworkRepository.Update(this.Homework);




                MainGrid.Children.Clear();
                HomeWorkUC uc = new HomeWorkUC();
                HomeworkViewModel vm = new HomeworkViewModel();

                App.CurrentStudent = App.db.StudentRepository.GetStudentById(App.CurrentStudent.Id);
                vm.MainGrid = this.MainGrid;

                vm.CurrentContainer = uc.CurrentContainer;
                vm.OverdueContainer = uc.OverdueContainer;
                vm.ReviewedContainer = uc.ReviewedContainer;
                vm.UnderReviewContainer = uc.UnderReviewContainer;


                vm.Initialize();
                vm.LoadViewControls();

                uc.DataContext = vm;

                MainGrid.Children.Add(uc);
            }
        });

        public StudentHomework Homework { get; set; } = new StudentHomework();

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

        private int point;

        public int Point
        {
            get { return point; }
            set { point = value; }
        }


        private string teacherName;

        public string TeacherName
        {
            get { return App.CurrentStudent.Group.Teacher.Fullname; }
            set { teacherName = value; }
        }


        private string content;

        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        private DateTime? sentAt;

        public DateTime? SentAt
        {
            get { return sentAt; }
            set { sentAt = value; }
        }

        private DateTime? endAt;

        public DateTime? EndAt
        {
            get { return endAt; }
            set { endAt = value; }
        }

        private string subject;

        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }
    }
}
