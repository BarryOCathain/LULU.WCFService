using System.Collections.Generic;
using System.ServiceModel;
using LULU_Model_DLL;

namespace LULU_WCF_Service.Interfaces
{
    [ServiceContract]
    interface IStudentService
    {
        [OperationContract]
        void CreateStudent(string studentNumber, string firstName, string surname, string email, string password);

        [OperationContract]
        bool DeleteStudent(string studentNumber);

        [OperationContract]
        void UpdateStudent(string studentNumber, string firstName, string surname, string email, string password);

        [OperationContract]
        string SearchStudentsByFirstName(string firstName);

        [OperationContract]
        string SearchStudentsBySurname(string surname);

        [OperationContract]
        string SearchStudentByStudentNumber(string studentNumber);
    }
}
