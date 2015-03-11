using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactHelper
{
   public class InvalidPathException : Exception
    {
        public new string Message;
        public InvalidPathException(string path)
        {
            this.Message = string.Format("'{0}' in not a valid Path", path);
        }
    }
}
