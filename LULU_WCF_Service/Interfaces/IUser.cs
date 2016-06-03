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
        bool AddUser(string userString);

        [OperationContract]
        bool DeleteUser(string userString);

        [OperationContract]
        bool UpdateUser(string userString);

        [OperationContract]
        string GetAllUsers();

        [OperationContract]
        string GetAllUsersOfType(string typeString);
    }
}
