using Mystat.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mystat.Domain.Abstractions
{
    public interface IMaterialRepository :IRepository<Material>
    {
        int GetMaterialCount(int materialStatusId);
    }
}
