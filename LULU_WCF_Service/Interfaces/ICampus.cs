using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace LULU_WCF_Service.Interfaces
{
    [ServiceContract]
    interface ICampus
    {
        [OperationContract]
        void AddCampus(string name);
        [OperationContract]
        bool DeleteCampus(string name);
        [OperationContract]
        string GetAllCampuses();
        [OperationContract]
        string GetCampusByClassroom(string classroom);
    }
}
