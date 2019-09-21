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
        public WrapPanel UnderReviewContainer { get; set; }
        public WrapPanel OverdueContainer { get; set; }
        public Grid MainGrid { get; set; }

        public HomeworkViewModel()
        {
            Initialize();
        }


        public void Initialize()
        {
            StudentHomeworks = new ObservableCollection<StudentHomework>(App.CurrentStudent.StudentHomeworks);

            foreach (var item in StudentHomeworks)
            {
                item.Points = new List<Domain.Data.Point>(App.CurrentStudent.Points.Where(x => x.StudentHomeworkId == item.Id));
            }
        }

        public void LoadViewControls()
        {
            CurrentContainer.Children.Clear();
            ReviewedContainer.Children.Clear();
            OverdueContainer.Children.Clear();
            UnderReviewContainer.Children.Clear();


            foreach (var homework in StudentHomeworks)
            {
                HomeworkItemViewModel vm = new HomeworkItemViewModel();
                vm.MainGrid = this.MainGrid;

                vm.StudentHomework = homework;
                vm.Content = homework.Homework.Content;
                vm.SentAt = homework.SentAt;
                vm.EndAt = homework.Homework.LastDay;
                //vm.Subject = homework.Homework.Lesson.Subject.Name;

                var point = homework.Points.FirstOrDefault(x => x.PointStatu.Status == "Homework");
                bool endsWith_txt = false, endsWith_pdf = false;

                if (homework.File.EndsWith(".txt")) endsWith_txt = true;
                if (homework.File.EndsWith(".pdf")) endsWith_pdf = true;

                if (point != null)
                    vm.Point = point.Point1.Value;


                if (homework.Homework.LastDay > DateTime.Now && point == null && !endsWith_pdf && !endsWith_txt)
                {
                    HomeworkItem uc = new HomeworkItem();
                    uc.DataContext = vm;
                    CurrentContainer.Children.Add(uc);
                }
                else if (homework.Homework.LastDay < DateTime.Now && point == null && !endsWith_pdf && !endsWith_txt)
                {
                    OverdueHomeworkItemUC uc = new OverdueHomeworkItemUC();
                    uc.DataContext = vm;
                    OverdueContainer.Children.Add(uc);
                }
                else if (endsWith_pdf || endsWith_txt && homework.Checked.Value && point != null)
                {
                    ReviewedHomeworkItemUC uc = new ReviewedHomeworkItemUC();
                    uc.DataContext = vm;
                    ReviewedContainer.Children.Add(uc);
                }
                else if (endsWith_pdf || endsWith_txt && !homework.Checked.Value)
                {
                    UnderReviewHomeworkItemUC uc = new UnderReviewHomeworkItemUC();
                    uc.DataContext = vm;
                    UnderReviewContainer.Children.Add(uc);
                }
            }
        }





        #region FullProperties

        private int allTaskCount;

        public int AllTaskCount
        {
            get
            {
                return UnderReviewCount + CurrentCount +
                       OverdueCount + ReviewedCount; }
            set { allTaskCount = value; }
        }


        private int underReviewCount;

        public int UnderReviewCount
        {
            get { return UnderReviewContainer.Children.Count; }
            set { underReviewCount = value; }
        }


        private int currentCount;

        public int CurrentCount
        {
            get { return CurrentContainer.Children.Count; }
            set { currentCount = value; }
        }

        private int overdueCount;

        public int OverdueCount
        {
            get { return OverdueContainer.Children.Count; }
            set { overdueCount = value; }
        }

        private int reviewedCount;

        public int ReviewedCount
        {
            get { return ReviewedContainer.Children.Count; }
            set { reviewedCount = value; }
        }


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
