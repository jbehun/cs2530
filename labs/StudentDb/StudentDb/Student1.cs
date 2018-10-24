using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDb
{
    public partial class Student
    {
        public override string ToString()
        {
            return string.Format("{0,-9} {1,-9} {2,-5} {3,-6} {4,-11} {5,-9}"
                ,FirstName, LastName, Gpa, GraduationYear, PhoneNumber, Email);
        }
    }
}
