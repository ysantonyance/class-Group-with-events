using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__basics__classes__exceptions
{
    internal class GroupFullException : GroupManagmentException
    {
        public int Full {  get; set; }

        public GroupFullException() : this("The group is full", 0, "") { }

        public GroupFullException(string message, int full, string details = "")
            : base(message, details)
        {
            Full = full;
        }
    }
}
