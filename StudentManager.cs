using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppg_databaser
{
    class StudentManager
    {
        public StudentDbCntxt dbCntxt = new StudentDbCntxt();

        internal void AddNewStudent (string firstname, string lastname, string city) 
        {
            var student = new Student() 
            { 
                FirstName = firstname,
                LastName = lastname,
                City = city
            };
            dbCntxt.Add(student);
            dbCntxt.SaveChanges();
        }
        internal void EditStudent(int id, string firstname, string lastname, string city) 
        {
            var student = dbCntxt.Students.Single(s => s.StudentId == id);
            student.FirstName = firstname;
            student.LastName = lastname;
            student.City = city;
            dbCntxt.SaveChanges();
        }
        internal void DeleteStudent(int id) 
        {
            var student = dbCntxt.Students.Single(s => s.StudentId == id);
            dbCntxt.Students.Remove(student);
            dbCntxt.SaveChanges();
        }
    }
}
