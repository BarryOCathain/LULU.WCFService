using System.Collections.Generic;
using System.ServiceModel;
using LULU_Model_DLL;

namespace LULU_WCF_Service.Interfaces
{
    [ServiceContract]
    //[ServiceContractAttribute(ConfigurationName="IStudentService")]
    interface IStudent
    {
        [OperationContract]
        bool CreateStudent(string studentNumber, string firstName, string surname, string email, string password);

        [OperationContract]
        bool DeleteStudent(string studentNumber);

        [OperationContract]
        bool UpdateStudent(string studentNumber, string firstName, string surname, string email, string password);

        [OperationContract]
        string GetAllStudents();

        [OperationContract]
        string SearchStudentsByFirstName(string firstName);

        [OperationContract]
        string SearchStudentsBySurname(string surname);

        [OperationContract]
        string SearchStudentByStudentNumber(string studentNumber);

        [OperationContract]
        bool LoginStudent(string studentNumber, string password);

        [OperationContract]
        bool StudentAttendedClass(string studentNumber, int classID, string loginString);
    }
}
