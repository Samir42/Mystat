using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mystat.Domain.Abstractions
{
    public interface IRepository<T>
    {
        ICollection<T> GetAll();
        void Insert(T inserted);
        void Update(T updated);
        void Delete(T deleted);
    }
}
