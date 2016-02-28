using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LULU_WCF_Service.Interfaces
{
    interface IStudentService
    {
        void CreateStudent(string studentNumber, string firstName, string surname, string email, string password);

        bool DeleteStudent(string studentNumber);

        void UpdateStudent(string studentNumber, string firstName, string surname, string email, string password);

        List<Student> SearchStudentsByFirstName(string firstName);

        List<Student> SearchStudentsBySurname(string surname);

        Student SearchStudentByStudentNumber(string studentNumber);
    }
}
