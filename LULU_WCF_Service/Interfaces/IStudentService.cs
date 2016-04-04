using System.Collections.Generic;
using System.ServiceModel;

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
        List<LULU_Model_DLL.Student> SearchStudentsByFirstName(string firstName);

        [OperationContract]
        List<LULU_Model_DLL.Student> SearchStudentsBySurname(string surname);

        [OperationContract]
        LULU_Model_DLL.Student SearchStudentByStudentNumber(string studentNumber);
    }
}
