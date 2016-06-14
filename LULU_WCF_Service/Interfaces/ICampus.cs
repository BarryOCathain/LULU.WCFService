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
        bool AddCampus(string name);
        [OperationContract]
        bool DeleteCampus(int campusID);
        [OperationContract]
        string GetAllCampuses();
        [OperationContract]
        string GetCampusByClassroom(int classroomID);
    }
}
