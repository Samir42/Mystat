using Mystat.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mystat.Domain.Abstractions
{
    public interface IStudentRepository:IRepository<Student>
    {
        Student GetStudentById(int id);
        ICollection<Point> GetStudentPointsById(int id);
        int GetStudentPositionById(int id);
        int GetCurrentStudentGeneralPointById(int id);
        ICollection<Student> GetStudentsByGroup(string group);
        int GetGroupStudentsGeneralPointById(int id);
        
    }
}
