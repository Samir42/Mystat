using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mystat.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        IImageRepository ImageRepository { get; }
        INewsRepository NewsRepository { get; }
        IStudentRepository StudentRepository { get; }
        IMaterialRepository MaterialRepository { get; }
    }
}
