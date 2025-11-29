using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__basics__classes__exceptions
{
    internal class InvalidGroupDataException : GroupManagmentException
    {
        public string InvalidData { get; set; }

        public InvalidGroupDataException() : this("Invalid Group's data", "", "") { }

        public InvalidGroupDataException(string message, string data, string details = "")
            : base(message, details)
        {
            InvalidData = data;
        }
    }
}
