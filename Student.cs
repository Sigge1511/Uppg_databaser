using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppg_databaser
{
    internal class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string City { get; set; } = "";

        //public Student(string firstname, string lastname, string city)
        //{
        //    FirstName = firstname;
        //    LastName = lastname;
        //    City = city;
        //}

    }
}
