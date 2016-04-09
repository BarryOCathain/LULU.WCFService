using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LULU_WCF_Service.Interfaces
{
    interface ICourse
    {
        bool AddCourse(string courseString);

        bool DeleteCourse(string courseString);

        bool UpdateCourse(string courseString);

        string GetAllCourses();
    }
}
