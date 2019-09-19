using Mystat.AdditionalClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mystat.Domain.Abstractions
{
    public interface IImageRepository : IRepository<ImageOperation>
    {
        void PostImage();
    }
}
