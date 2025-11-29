using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__basics__classes__exceptions
{
    internal class StudentNotFoundException : StudentManagmentException
    {
        public string StudentName { get; set; }

        public StudentNotFoundException() : this("Student is not found", "", "") { }

        public StudentNotFoundException(string message, string studentname, string details = "") 
            : base(message, details)
        {
            StudentName = studentname;
        }
    }
}
