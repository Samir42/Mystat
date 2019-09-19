using Mystat.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mystat.AdditionalClasses
{
    public class MathHelper
    {
        public static double CalculatePercentage(Student student)
        {
            int notNullPropertyCount = 0;

            if (student.Address != null) notNullPropertyCount++;
            if (student.Birthdate != null) notNullPropertyCount++;
            if (student.Education != null) notNullPropertyCount++;
            if (student.Email != null) notNullPropertyCount++;
            if (student.Facebook != null) notNullPropertyCount++;
            if (student.Fullname != null) notNullPropertyCount++;
            //if (student.Linkedin != null) notNullPropertyCount++;
            //if (student.Phone != null) notNullPropertyCount++;
            if (student.SocialMedia != null) notNullPropertyCount++;



            return (notNullPropertyCount / 9) * 100;
        }
    }
}
