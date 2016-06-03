using LULU_WCF_Service.Interfaces;
using System;
using System.Diagnostics;
using System.Linq;
using LULU_Model_DLL;
using LULU_WCF_Service.Common;
using System.Reflection;

namespace LULU_WCF_Service
{
    public class LULU_Service : IStudent, ICampus, IClass, IClassRoom, ICourse, IUser
    {
        #region Private Members
        private LULU_ModelContainer context; 
        #endregion

        #region Constructor
        public LULU_Service()
        {
            context = new LULU_ModelContainer();

            // Stops the cration of proxy objects at runtime which causes issues with serialization
            context.Configuration.ProxyCreationEnabled = false;

            // Stops Lazy Loading which will load all related entities the first time that an object is accessed.
            // This could be a problem where there are thousands of related entiies.
            // For example, if we queried for a specific ClassRoom, then with Lazy Loading, the first time that we access
            // this ClassRoom, all related Classes would be loaded into memory.
            context.Configuration.LazyLoadingEnabled = false;
        } 
        #endregion

        #region IStudent Implementation
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
                return Serializers<Class>.SerializeList(context.Classes
                    .Include("Course")
                    .Include("ClassRoom")
                    .Include("ClassRoom.Campu")
                    .ToList());
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

        #region IClassRoom Implementation
        public bool AddClassRoom(string classroomString)
        {
            ClassRoom cl = Serializers<ClassRoom>.Deserialize(classroomString);

            if (cl != null)
            {
                try
                {
                    if (!context.ClassRooms1.Any(c => c.Name.Equals(cl.Name) && c.Campus.Equals(cl.Campus)))
                    {
                        context.ClassRooms1.Add(cl);
                        context.SaveChanges();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return false;
        }

        public bool DeleteClassRoom(string classroomString)
        {
            ClassRoom cl = Serializers<ClassRoom>.Deserialize(classroomString);

            if (cl != null)
            {
                try
                {
                    if (context.ClassRooms1.Any(c => c.Equals(cl)))
                    {
                        context.ClassRooms1.Remove(cl);
                        context.SaveChanges();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return false;
        }

        public bool UpdateClassRoom(string classRoomString)
        {
            ClassRoom cl = Serializers<ClassRoom>.Deserialize(classRoomString);

            if (cl != null)
            {
                if (context.ClassRooms1.Any(c => c.Equals(cl)))
                {
                    try
                    {
                        ClassRoom classroomToUpdate = context.ClassRooms1.Where(c => c.Equals(cl)).FirstOrDefault();

                        classroomToUpdate.Name = cl.Name;
                        classroomToUpdate.Longitude = cl.Longitude;
                        classroomToUpdate.Latitude = cl.Latitude;
                        classroomToUpdate.Campus = cl.Campus;

                        context.SaveChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }
            return false;
        }

        public string GetAllClassRooms()
        {
            return Serializers<ClassRoom>.SerializeList(context.ClassRooms1.ToList());
        }

        public string GetAllClassRoomsByCampus(string campusString)
        {
            Campus ca = Serializers<Campus>.Deserialize(campusString);

            if (ca != null)
            {
                if (context.Campus.Any(c => c.Equals(ca)))
                {
                    Serializers<ClassRoom>.SerializeList(context.ClassRooms1.Where(cl => cl.Campus.Equals(ca)).ToList()); 
                }
            }
            return null;
        }
        #endregion

        #region ICourse Implementation
        public bool AddCourse(string courseString)
        {
            Course course = Serializers<Course>.Deserialize(courseString);

            if (course != null)
            {
                if (!context.Courses1.Any(c => c.CourseCode.Equals(course.CourseCode) && c.Name.Equals(course.Name)))
                {
                    context.Courses1.Add(course);
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool DeleteCourse(string courseString)
        {
            Course course = Serializers<Course>.Deserialize(courseString);

            if (course != null)
            {
                if(context.Courses1.Any(c => c.Equals(course)))
                {
                    context.Courses1.Remove(course);
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool UpdateCourse(string courseString)
        {
            Course course = Serializers<Course>.Deserialize(courseString);

            if (course != null)
            {
                if (context.Courses1.Any(c => c.Equals(course)))
                {
                    Course courseToUpdate = context.Courses1.Where(c => c.Equals(course)).FirstOrDefault();

                    courseToUpdate.CourseCode = course.CourseCode;
                    courseToUpdate.Name = course.Name;

                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public string GetAllCourses()
        {
            return Serializers<Course>.SerializeList(context.Courses1.ToList());
        }
        #endregion

        #region IUser Implementation
        public bool AddUser(string userString)
        {
            User user = Serializers<User>.Deserialize(userString);

            if (user != null)
            {
                try
                {
                    if (!context.Users.Any(u => u.FirstName.Equals(user.FirstName) && u.Surname.Equals(user.Surname)
                    && u.Email.Equals(user.Email)))
                    {
                        context.Users.Add(user);
                        context.SaveChanges();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return false;
        }

        public bool DeleteUser(string userString)
        {
            User user = Serializers<User>.Deserialize(userString);

            if (user != null)
            {
                try
                {
                    if (context.Users.Any(u => u.Equals(user)))
                    {
                        context.Users.Remove(user);
                        context.SaveChanges();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return false;
        }

        public bool UpdateUser(string userString)
        {
            User user = Serializers<User>.Deserialize(userString);

            if (user != null)
            {
                try
                {
                    Student student = user as Student;

                    if (student != null)
                    {
                        Student studentToUpdate = context.Users.OfType<Student>().Where(s => s.Equals(student)).FirstOrDefault();

                        studentToUpdate.FirstName = student.FirstName;
                        studentToUpdate.Surname = student.Surname;
                        studentToUpdate.Email = student.Email;
                        studentToUpdate.Password = student.Password;
                    }
                    else
                    {
                        Staff_User staff = user as Staff_User;

                        Staff_User staffUserToUpdate = context.Users.OfType<Staff_User>()
                            .Where(st => st.Equals(staff)).FirstOrDefault();

                        staffUserToUpdate.FirstName = staff.FirstName;
                        staffUserToUpdate.Surname = staff.Surname;
                        staffUserToUpdate.Email = staff.Email;
                        staffUserToUpdate.Password = staff.Password;
                        staffUserToUpdate.IsSysAdmin = staff.IsSysAdmin;
                    }
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return false;
        }

        public string GetAllUsers()
        {
            return Serializers<User>.SerializeList(context.Users.ToList());
        }

        public string GetAllUsersOfType(string typeString)
        {
            Assembly model = typeof(User).Assembly;
            Type userType = model.GetType(typeString);

            if (userType == typeof(Student))
                return true.ToString();


            if (userType != null)
            {
                if (userType == typeof(Student))
                    return Serializers<Student>.SerializeList(context.Users.OfType<Student>().ToList());
                else if (userType == typeof(Staff_User))
                    return Serializers<Staff_User>.SerializeList(context.Users.OfType<Staff_User>().ToList());
                else if (userType == typeof(Lecturer))
                    Serializers<Lecturer>.SerializeList(context.Users.OfType<Lecturer>().ToList());
            }
            return null;
        }
        #endregion
    }
}
