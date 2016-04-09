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
    public class LULU_Service : IStudent, ICampus, IClass
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

        #region IClass Implementation
        public bool AddClass(string newClass)
        {
            if (string.IsNullOrEmpty(newClass.Trim()))
                throw new ArgumentException("The Class to be added has not been specified");

            try
            {
                Class c = null;

                c = Serializers<Class>.Deserialize(newClass);

                if (c != null)
                {
                    context.Classes.Add(c);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool DeleteClass(string classToDelete)
        {
            if (string.IsNullOrEmpty(classToDelete.Trim()))
                throw new ArgumentException("The Class to be deleted has not been specified");

            try
            {
                Class c = null;

                c = Serializers<Class>.Deserialize(classToDelete);

                if (c != null)
                {
                    context.Classes.Remove(c);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool UpdateClass(string updatedClass)
        {
            if (string.IsNullOrEmpty(updatedClass.Trim()))
                throw new ArgumentException("The Class to be updated has not been specified");

            try
            {
                Class c = null;

                c = Serializers<Class>.Deserialize(updatedClass.Trim());

                if (c != null)
                {
                    Class original = context.Classes.Where(cl => cl.ClassID == c.ClassID).FirstOrDefault();

                    if (original != null)
                    {
                        original.Name = c.Name;
                        original.ClassDate = c.ClassDate;
                        original.Compulsory = c.Compulsory;
                        original.StartTime = c.StartTime;
                        original.EndTime = c.EndTime;
                        original.Course = c.Course;
                        original.ClassRoom = c.ClassRoom;

                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public string GetAllClasses()
        {
            try
            {
                return Serializers<Class>.SerializeList(context.Classes.ToList());
            }
            catch (Exception ex)
            {
                return ex.InnerException.ToString();
            }
        }

        public string GetAllClassesByCourse(string course)
        {
            if (string.IsNullOrEmpty(course.Trim()))
                throw new ArgumentException("Course for which Classes are to be found, has not been specified");

            try
            {
                Course _course = Serializers<Course>.Deserialize(course);

                if (_course != null)
                {
                    return Serializers<Class>.SerializeList(context.Classes.Where(c => c.Course.Equals(_course)).ToList());
                }
            }
            catch (Exception ex)
            {
                return ex.InnerException.ToString();
            }
            return null;
        }

        public string GetAllClassesByDate(DateTime classDate)
        {
            if (classDate == null)
                throw new ArgumentException("The Date of the Classes to be found has not been specified");

            try
            {
                return Serializers<Class>.SerializeList(context.Classes.Where(c => c.ClassDate == classDate).ToList());
            }
            catch (Exception ex)
            {
                return ex.InnerException.ToString();
            }
        }

        public string GetAllClassesByClassroom(string classroom)
        {
            if (string.IsNullOrEmpty(classroom.Trim()))
                throw new ArgumentException("Classroom for which Classes are to be found, has not been specified");

            try
            {
                ClassRoom cl = Serializers<ClassRoom>.Deserialize(classroom);

                if (cl != null)
                {
                    return Serializers<Class>.SerializeList(context.Classes.Where(c => c.ClassRoom.Equals(cl)).ToList());
                }
            }
            catch (Exception ex)
            {
                return ex.InnerException.ToString();
            }
            return "The Classroom for which Classes are to be found, does not exist";
        }

        public string GetClassesByName(string name)
        {
            if (string.IsNullOrEmpty(name.Trim()))
                throw new ArgumentException("THe Name for which CLasses are to be found, has not been specified");

            try
            {
                return Serializers<Class>.SerializeList(context.Classes.Where(c => c.Name.Contains(name)).ToList());
            }
            catch (Exception ex)
            {
                return ex.InnerException.ToString();
            }
        }
        #endregion
    }
}
