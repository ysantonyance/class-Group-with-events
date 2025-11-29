using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__basics__classes__exceptions
{
    internal class InvalidStudentDataException : StudentManagmentException
    {
        public string InvalidData { get; set; }

        public InvalidStudentDataException() : this("Invalid student's data", "", "") { }

        public InvalidStudentDataException(string message, string data, string details = "")
            : base(message, details)
        {
            InvalidData = data;
        }
    }
}
