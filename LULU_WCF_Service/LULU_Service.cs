using LULU_WCF_Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;

namespace LULU_WCF_Service
{
    public class LULU_Service : IStudentService
    {
        LULU_ModelContainer context;

        public LULU_Service()
        {
            context = new LULU_ModelContainer();
        }

        #region IStudentService Implementation
        public void CreateStudent(string studentNumber, string firstName, string surname, string email, string password)
        {
            context.Users.Add(new Student
            {
                StudentNumber = studentNumber,
                FirstName = firstName,
                Surname = surname,
                Email = email,
                Password = password
            });
            context.SaveChanges();
        }

        public bool DeleteStudent(string studentNumber)
        {
            try
            {
                Student s = SearchStudentByStudentNumber(studentNumber);

                context.Users.Remove(s);

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("An error occurred deleting the student: " + ex.ToString());
                return false;
            }
            return true;
        }

        public void UpdateStudent(string studentNumber, string firstName, string surname, string email, string password)
        {
            Student s = SearchStudentByStudentNumber(studentNumber);

            s.FirstName = firstName;
            s.Surname = surname;
            s.Email = email;
            s.Password = password;

            context.SaveChanges();
        }

        public List<Student> SearchStudentsByFirstName(string firstName)
        {
            return context.Users.OfType<Student>().Where(s => s.FirstName.Equals(firstName)).ToList();
        }

        public List<Student> SearchStudentsBySurname(string surname)
        {
            return context.Users.OfType<Student>().Where(s => s.Surname.Equals(surname)).ToList();
        }

        public Student SearchStudentByStudentNumber(string studentNumber)
        {
            return context.Users.OfType<Student>().Where(s => s.StudentNumber == studentNumber).FirstOrDefault();
        } 
        #endregion
    }
}
