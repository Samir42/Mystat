using Mystat.Domain.Data;
using Mystat.Domain.Abstractions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mystat.DataAccess.HTTPServer
{
    public class HTTPStudentRepository : IStudentRepository
    {
        public String GetPointResponse(int id)
        {
            String responsestring = "";
            Task task = Task.Run(async () =>
            {
                responsestring = await App.client.GetStringAsync($"http://{App.ip}:{App.Port}/GetStudentPointsById/{id}");
            });

            task.Wait();

            return responsestring;

        }

        public String GetStudentResponse(int id)
        {
            String responsestring = "";
            Task task = Task.Run(async () =>
            {
                responsestring = await App.client.GetStringAsync($"http://{App.ip}:{App.Port}/GetStudentById/{id}");
            });
            task.Wait();
            return responsestring;

        }

        public String GetStudentGroupResponse(string group)
        {
            String responsestring = "";
            Task task = Task.Run(async () =>
            {
                responsestring = await App.client.GetStringAsync($"http://{App.ip}:{App.Port}/GetStudentByGroup/{group}");
            });
            task.Wait();
            return responsestring;

        }

        public void UpdateStudentResponse(string student)
        {
            Task task = Task.Run(async () =>
            {
                var response = await App.client.PostAsync($"http://{App.ip}:{App.Port}/UpdateStudent/", new StringContent(student, Encoding.UTF8, "application/json"));
            });
            task.Wait(500);
        }


        public void Delete(Student deleted)
        {
            throw new NotImplementedException();
        }

        public ICollection<Student> GetAll()
        {
            throw new NotImplementedException();
        }

        public ICollection<Point> GetStudentPointsById(int id)
        {
            var data = GetPointResponse(id);

            return JsonConvert.DeserializeObject<List<Point>>(data);
        }

        public void Insert(Student inserted)
        {
            throw new NotImplementedException();
        }

        public void Update(Student updated)
        {
            var student = JsonConvert.SerializeObject(updated);

            UpdateStudentResponse(student);
        }

        public Student GetStudentById(int id)
        {
            var data = GetStudentResponse(id);

            return JsonConvert.DeserializeObject<Student>(data);
        }

        public ICollection<Student> GetStudentsByGroup(string group)
        {
            var data = GetStudentGroupResponse(group);

            return JsonConvert.DeserializeObject<List<Student>>(data);
        }


        public int GetCurrentStudentGeneralPointById(int id)
        {
           

            var result = App.db.StudentRepository.GetStudentsByGroup(App.CurrentStudent.Group.Name)
                                                .GroupBy(g => g.Username)
                                                .Select(x => new
                                                {
                                                    Username = x.Key,
                                                    GeneralPoint = x.Sum(s => s.DiamondCount + s.CoinCount)
                                                })
                                                .OrderByDescending(o => o.GeneralPoint)
                                                .ToList();

            var student = result.FirstOrDefault(x => x.Username == App.CurrentStudent.Username);

            return (int)student.GeneralPoint;
        }

        public int GetGroupStudentsGeneralPointById(int id)
        {
            var student = App.db.StudentRepository.GetStudentById(id);

            var coinCount = student.Points.Where(x => x.PointStatu.Status == "Homework" || x.PointStatu.Status == "Exam" ||
                                                         x.PointStatu.Status == "Labs" || x.PointStatu.Status == "Classwork").Sum(s=>s.Point1.Value);

            var diamondCount = student.Points.Where(x => x.PointStatu.Status == "Attendance" || x.PointStatu.Status == "Activity").Sum(s=>s.Point1.Value);



            return coinCount + diamondCount;
        }

        public int GetStudentPositionById(int id)
        {
            var result = App.db.StudentRepository.GetStudentsByGroup(App.CurrentStudent.Group.Name)
                                                 .GroupBy(g => g.Username)
                                                 .Select(x => new
                                                 {
                                                     Username = x.Key,
                                                     GeneralPoint = x.Sum(s=> s.DiamondCount+s.CoinCount)
                                                 })
                                                 .OrderByDescending(o => o.GeneralPoint)
                                                 .ToList();

            var student = result.FirstOrDefault(x => x.Username == App.CurrentStudent.Username);
            return result.IndexOf(student);
        }
    }
}
