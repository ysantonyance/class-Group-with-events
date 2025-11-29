using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__basics__classes__exceptions
{
    internal class TransferFailedException : GroupManagmentException
    {
        public string StudentName { get; set; }

        public TransferFailedException() : this("Failed to transfer a student", "", "") { }

        public TransferFailedException(string message, string studentname, string details = "")
            : base(message, details)
        {
            StudentName = studentname;
        }
    }
}
