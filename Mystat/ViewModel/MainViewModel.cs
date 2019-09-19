using Mystat.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mystat.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            Students = App.db.StudentRepository.GetStudentsByGroup(App.CurrentStudent.Group.Name) as List<Student>;

            foreach (var student in Students)
            {
                

                student.GeneralPoint = App.db.StudentRepository.GetGroupStudentsGeneralPointById(student.Id);
            }

            Students = new List<Student>(Students.OrderByDescending(x => x.GeneralPoint));

            Points = new List<Point>(App.CurrentStudent.Points);
        }



        private List<Student> students;

        public List<Student> Students
        {
            get { return students; }
            set { students = value; }
        }

        private List<Point> points;

        public List<Point> Points
        {
            get { return points; }
            set { points = value; }
        }



        private int positionInTheGroup;

        public int PositionInTheGroup
        {
            get => this.Students.FindIndex(x => x.Email == App.CurrentStudent.Email)+1;
            set
            {
                if (value == positionInTheGroup) return;

                positionInTheGroup = value;

                OnPropertyChanged();
            }
        }

        private int lessonMaterialCount;

        public int LessonMaterialCount
        {
            get
            {
                var material = App.db.MaterialRepository.GetAll().FirstOrDefault(x => x.MaterialStatu.Status == "Lesson");

                if (material != null)
                    return App.db.MaterialRepository.
                                  GetMaterialCount(material.MaterialStatusId);
                else
                    return 0;
            }
            set
            {
                if (value == lessonMaterialCount) return;

                lessonMaterialCount = value;

                OnPropertyChanged();
            }
        }

        private int libraryMaterialCount;

        public int LibraryMaterialCount
        {
            get
            {
                var material = App.db.MaterialRepository.GetAll().FirstOrDefault(x => x.MaterialStatu.Status == "Library");

                if (material != null)
                    return App.db.MaterialRepository.
                                  GetMaterialCount(material.MaterialStatusId);
                else
                    return 0;
            }
            set
            {
                if (value == libraryMaterialCount) return;

                libraryMaterialCount = value;

                OnPropertyChanged();
            }
        }

        private int videoMaterialCount;

        public int VideoMaterialCount
        {
            get
            {
                var material = App.db.MaterialRepository.GetAll().FirstOrDefault(x => x.MaterialStatu.Status == "Video");

                if (material != null)
                    return App.db.MaterialRepository.
                                  GetMaterialCount(material.MaterialStatusId);
                else
                    return 0;
            }
            set
            {
                if (value == videoMaterialCount) return;

                videoMaterialCount = value;

                OnPropertyChanged();
            }
        }

        private int presentationMaterialCount;

        public int PresentationMaterialCount
        {
            get
            {
                var material = App.db.MaterialRepository.GetAll().FirstOrDefault(x => x.MaterialStatu.Status == "Presentation");

                if (material != null)
                    return App.db.MaterialRepository.
                                  GetMaterialCount(material.MaterialStatusId);
                else
                    return 0;
            }
            set
            {
                if (value == presentationMaterialCount) return;

                presentationMaterialCount = value;

                OnPropertyChanged();
            }
        }

        private int articleMaterialCount;

        public int ArticleMaterialCount
        {
            get
            {
                var material = App.db.MaterialRepository.GetAll().FirstOrDefault(x => x.MaterialStatu.Status == "Article");

                if (material != null)
                    return App.db.MaterialRepository.
                                  GetMaterialCount(material.MaterialStatusId);
                else
                    return 0;
            }
            set
            {
                if (value == articleMaterialCount) return;

                articleMaterialCount = value;

                OnPropertyChanged();
            }
        }


        private int selfStudyMaterialCount;

        public int SelfStudyMaterialCount
        {
            get
            {
                var material = App.db.MaterialRepository.GetAll().FirstOrDefault(x => x.MaterialStatu.Status == "SelfStudy");

                if (material != null)
                    return App.db.MaterialRepository.
                                  GetMaterialCount(material.MaterialStatusId);
                else
                    return 0;
            }
            set
            {
                if (value == selfStudyMaterialCount) return;

                selfStudyMaterialCount = value;

                OnPropertyChanged();
            }
        }


        private int testMaterialCount;

        public int TestMaterialCount
        {
            get
            {
                var material = App.db.MaterialRepository.GetAll().FirstOrDefault(x => x.MaterialStatu.Status == "Test");

                if (material != null)
                    return App.db.MaterialRepository.
                                  GetMaterialCount(material.MaterialStatusId);
                else
                    return 0;
            }
            set
            {
                if (value == testMaterialCount) return;

                testMaterialCount = value;

                OnPropertyChanged();
            }
        }
    }
}
