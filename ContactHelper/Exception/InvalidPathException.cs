using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactHelper
{
    public class InvalidFileFormatException : Exception
    {
        public new string Message;
        public InvalidFileFormatException(string path)
        {
            this.Message = string.Format("'{0}' does not have valid format. The valid format is Lastname, Firstname", path);
        }
    }
}
