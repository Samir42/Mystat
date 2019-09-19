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
    public class HTTPMaterialRepository : IMaterialRepository
    {
        public String GetResponse()
        {
            String responsestring = "";
            Task task = Task.Run(async () =>
            {
                responsestring = await App.client.GetStringAsync($"http://{App.ip}:{App.Port}/GetMaterials/-1");
            });
            task.Wait();
            return responsestring;

        }
        public void Delete(Material deleted)
        {
            throw new NotImplementedException();
        }

        public ICollection<Material> GetAll()
        {
            var data = GetResponse();

            return JsonConvert.DeserializeObject<List<Material>>(data);
        }


        public void Insert(Material inserted)
        {
            throw new NotImplementedException();
        }

        public void Update(Material updated)
        {
            throw new NotImplementedException();
        }

        public int GetMaterialCount(int materialStatusId)
        {
            var result = App.db.MaterialRepository.GetAll()
                                                  .GroupBy(g => g.MaterialStatusId)
                                                  .Select(x => new
                                                  {
                                                      Status = x.Key,
                                                      MaterialCount = x.Count()
                                                  })
                                                  .ToList();

            var temp = result.FirstOrDefault(x => x.Status == materialStatusId);

            return temp.MaterialCount;
        }
    }
}
