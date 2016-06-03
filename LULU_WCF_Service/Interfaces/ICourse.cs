using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace LULU_WCF_Service.Interfaces
{
    [ServiceContract]
    interface ICourse
    {
        [OperationContract]
        bool AddCourse(string courseString);

        [OperationContract]
        bool DeleteCourse(string courseString);

        [OperationContract]
        bool UpdateCourse(string courseString);

        [OperationContract]
        string GetAllCourses();
    }
}
