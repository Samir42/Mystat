using Mystat.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mystat.Domain.Abstractions
{
    public interface IStudentHomeworkRepository :IRepository<StudentHomework>
    {
        StudentHomework GetStudentHomeworkById(int id);
    }
}
