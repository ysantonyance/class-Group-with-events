using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__basics__classes__exceptions
{
    internal class InvalidGradeException : StudentManagmentException
    {
        public int InvalidGrade { get; set; }

        public InvalidGradeException() : this("There's an invalid grade", 0, "") { }

        public InvalidGradeException(string message, int grade, string details = "") : base(message, details)
        {
            InvalidGrade = grade;
        }
    }
}
