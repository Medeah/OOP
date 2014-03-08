using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l5
{
    public class QueueException : Exception
    {
        public QueueException() : base() { }
        public QueueException(string s) : base(s) { }
        public QueueException(string s, Exception ex) : base(s, ex) { }
    }
}
