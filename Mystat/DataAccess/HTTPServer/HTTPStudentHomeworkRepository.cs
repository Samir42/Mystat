using Mystat.Domain.Abstractions;
using Mystat.Domain.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mystat.DataAccess.HTTPServer
{
    public class HTTPStudentHomeworkRepository : IStudentHomeworkRepository
    {
        public void InsertStudentHomeworkRequest(string studentHomework)
        {
            Task task = Task.Run(async () =>
            {
                var response = await App.client.PostAsync($"http://{App.ip}:{App.Port}/InsertStudentHomework/", new StringContent(studentHomework, Encoding.UTF8, "application/json"));
            });
            task.Wait(500);
        }

        public void UpdateStudentHomeworkRequest(string studentHomework)
        {
            Task task = Task.Run(async () =>
            {
                var response = await App.client.PostAsync($"http://{App.ip}:{App.Port}/UpdateStudentHomework/", new StringContent(studentHomework, Encoding.UTF8, "application/json"));
            });
            task.Wait(500);
        }

        public String GetStudenHomeworkByIdResponse(int id)
        {
            String responsestring = "";
            Task task = Task.Run(async () =>
            {
                responsestring = await App.client.GetStringAsync($"http://{App.ip}:{App.Port}/GetStudentHomeworkById/{id}");
            });

            task.Wait();
            return responsestring;
        }

        public StudentHomework GetStudentHomeworkById(int id)
        {
            var data = GetStudenHomeworkByIdResponse(id);

            return JsonConvert.DeserializeObject<StudentHomework>(data);
        }

        public void Delete(StudentHomework deleted)
        {
            throw new NotImplementedException();
        }

        public ICollection<StudentHomework> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(StudentHomework inserted)
        {
            var shw = JsonConvert.SerializeObject(inserted);

            InsertStudentHomeworkRequest(shw);
        }

        public void Update(StudentHomework updated)
        {
            var shw = JsonConvert.SerializeObject(updated);

            UpdateStudentHomeworkRequest(shw);
        }
    }
}
