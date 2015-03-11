using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactHelper
{
    public class InvalidFileTypeException : Exception
    {
        public new string Message;
        public InvalidFileTypeException(string path, string validType)
        {
            this.Message = string.Format("File type '{0}' in not a valid file type.The valid format is: Lastname, Firstnametype is: '{1}'", path, validType);
        }
    }
}
