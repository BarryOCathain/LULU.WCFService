using LULU_WCF_Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using LULU_Model_DLL;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Text;
using System.IO;
using LULU_WCF_Service.Common;

namespace LULU_WCF_Service
{
    public class LULU_Service : IStudentService, ICampus
    {
        LULU_ModelContainer context;

        public LULU_Service()
        {
            context = new LULU_ModelContainer();
            context.Configuration.ProxyCreationEnabled = false;
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
                Student st = context.Users.OfType<Student>()
                .Where(s => s.StudentNumber == studentNumber).FirstOrDefault();

                context.Users.Remove(st);

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
            Student st = context.Users.OfType<Student>()
                .Where(s => s.StudentNumber == studentNumber).FirstOrDefault();

            st.FirstName = firstName;
            st.Surname = surname;
            st.Email = email;
            st.Password = password;

            context.SaveChanges();
        }

        public string SearchStudentsByFirstName(string firstName)
        {
            return Serializers<Student>.SerializeList(context.Users.OfType<Student>().Where(s => s.FirstName.Equals(firstName)).ToList());
        }

        public string SearchStudentsBySurname(string surname)
        {
            return Serializers<Student>.SerializeList(context.Users.OfType<Student>().Where(s => s.Surname.Equals(surname)).ToList());
        }

        public string SearchStudentByStudentNumber(string studentNumber)
        {
            return Serializers<Student>.Serialize(context.Users.OfType<Student>()
                .Where(s => s.StudentNumber == studentNumber).FirstOrDefault());
        }
        #endregion

        #region ICampus Implementation
        public void AddCampus(string name)
        {
            try
            {
                Campus cs = context.Campus.Where(c => c.Name.Equals(name)).FirstOrDefault();

                if (cs == null)
                {
                    context.Campus.Add(new Campus
                    {
                        Name = name
                    });

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        public bool DeleteCampus(string name)
        {
            try
            {
                Campus cs = context.Campus.Where(c => c.Name.Equals(name)).FirstOrDefault();

                if (cs != null)
                {
                    context.Campus.Remove(cs);
                    context.SaveChanges();
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return false;
            }
            return true;
        }

        public string GetAllCampuses()
        {
            return Serializers<Campus>.SerializeList(context.Campus.ToList());
        }

        public string GetCampusByClassroom(string classroom)
        {
            ClassRoom cl = Serializers<ClassRoom>.Deserialize(classroom);

            if (cl != null)
            {
                return Serializers<Campus>.Serialize(context.Campus.Where(c => c.ClassRooms.Contains(cl)).FirstOrDefault()); 
            }
            return null;
        }
        #endregion
    }
}
