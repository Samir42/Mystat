using Mystat.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mystat.DataAccess.HTTPServer
{
    public class HTTPUnitOfWork : IUnitOfWork
    {
        public IStudentHomeworkRepository StudentHomeworkRepository => new HTTPStudentHomeworkRepository();
        public INewsRepository NewsRepository => new HTTPNewsRepository();

        public IStudentRepository StudentRepository => new HTTPStudentRepository();

        public IMaterialRepository MaterialRepository => new HTTPMaterialRepository();

        public IImageRepository ImageRepository => new HTTPImageRepository();
    }
}
