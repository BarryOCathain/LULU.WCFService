using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LULU_WCF_Service.Interfaces
{
    interface IClassRoom
    {
        bool AddClassRoom(string classroomString);

        bool DeleteClassRoom(string classroomString);

        bool UpdateClassRoom(string classRoomString);

        string GetAllClassRooms();

        string GetAllClassRoomsByCampus(string campusString);
    }
}
