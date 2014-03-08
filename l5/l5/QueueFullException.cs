using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l5
{
    public class QueueFullException : QueueException
    {
        public QueueFullException() : base() { }
        public QueueFullException(string s) : base(s) { }
        public QueueFullException(string s, Exception ex) : base(s, ex) { }
    }
}
