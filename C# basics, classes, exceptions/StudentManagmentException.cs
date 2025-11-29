using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__basics__classes__exceptions
{
    internal class StudentManagmentException : ApplicationException
    {
        public string ErrorDetails {  get; set; }

        public StudentManagmentException() : this("There's a problem with managing a student", "") { }

        public StudentManagmentException(string message, string details = "") : base(message)
        {
            ErrorDetails = details;
        }
    }
}
