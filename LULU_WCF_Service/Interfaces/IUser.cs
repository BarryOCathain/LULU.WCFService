using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace LULU_WCF_Service.Interfaces
{
    [ServiceContract]
    interface IUser
    {
        [OperationContract]
        bool AddLecturer(string title, string staffNumber, string firstName, string surname, string email, string password, bool isSysAdmin);

        [OperationContract]
        bool AddStaffUser(string staffNumber, string firstName, string surname, string email, string password, bool isSysAdmin);

        [OperationContract]
        bool AddStudent(string studentNumber, string firstName, string surname, string email, string password);

        [OperationContract]
        bool DeleteUser(int userID);

        [OperationContract]
        bool UpdateUser(string userString);

        [OperationContract]
        string GetAllUsersOfType(string typeString);
    }
}
