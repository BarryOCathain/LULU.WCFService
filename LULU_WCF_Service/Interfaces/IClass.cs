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
        bool DeleteClass(string classToDelete);

        [OperationContract]
        bool UpdateClass(string updatedClass);

        [OperationContract]
        string GetAllClasses();

        [OperationContract]
        string GetAllClassesByCourse(string course);

        [OperationContract]
        string GetAllClassesByDate(DateTime classDate);

        [OperationContract]
        string GetAllClassesByClassroom(string classroom);

        [OperationContract]
        string GetClassesByName(string name);
    }
}
