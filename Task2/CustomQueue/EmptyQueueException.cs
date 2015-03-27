using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomQueue
{
    class EmptyQueueException : Exception
    {
        public EmptyQueueException()
        {
            
        }

        public EmptyQueueException(string message)
            : base(message)
        {

        }

        public EmptyQueueException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
