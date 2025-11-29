using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__basics__classes__exceptions
{
    internal class GroupManagmentException : ApplicationException
    {
        public string ErrorDetails { get; set; }

        public GroupManagmentException() : this("There's a problem with managing a group", "") { }

        public GroupManagmentException(string message, string details = "") : base(message)
        {
            ErrorDetails = details;
        }
    }
}
