using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace LULU_WCF_Service.Interfaces
{
    [ServiceContract]
    interface IClass
    {
        [OperationContract]
        bool AddClass(string newClass);

        [OperationContract]
        bool DeleteClass(int classID);

        [OperationContract]
        bool UpdateClass(string updatedClass);

        [OperationContract]
        string GetAllClasses();

        [OperationContract]
        string GetAllClassesByCourse(int courseID);

        [OperationContract]
        string GetAllClassesByDate(DateTime classDate);

        [OperationContract]
        string GetAllClassesByClassroom(int classroomID);

        [OperationContract]
        string GetClassesByName(string name);

        [OperationContract]
        string GetClassesByStudentNumberAndDateRange(string studentNumber, DateTime startDate, DateTime endDate, bool includeAttendedClasses);

        [OperationContract]
        string GetAttendedClassesByStudentNumberAndDateRange(string studentNumber, DateTime startDate, DateTime endDate);

        [OperationContract]
        string GetMissedClassesByStudentNumberAndDateRange(string studentNumber, DateTime startDate, DateTime endDate);
    }
}
