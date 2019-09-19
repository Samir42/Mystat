using Mystat.Domain.Data;
using Mystat.Domain.Abstractions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mystat.DataAccess.HTTPServer
{
    public class HTTPNewsRepository : INewsRepository
    {
        public void Delete(News deleted)
        {
            throw new NotImplementedException();
        }
        public  String GetResponse()
        {
            String responsestring = "";
            Task task = Task.Run(async () =>
            {
                responsestring = await App.client.GetStringAsync($"http://{App.ip}:{App.Port}/GetNews/-1");
            });
            task.Wait();
            return responsestring;

        }

        public ICollection<News> GetAll()
        {
            var data = GetResponse();

            return JsonConvert.DeserializeObject<List<News>>(data);
        }

        public void Insert(News inserted)
        {
            throw new NotImplementedException();
        }

        public void Update(News updated)
        {
            throw new NotImplementedException();
        }
    }
}
