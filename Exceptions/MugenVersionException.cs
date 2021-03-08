using System;
using System.Collections.Generic;
using System.Text;

namespace MugenWatcher.Exceptions
{
    public class MugenVersionException : Exception
    {
        public MugenVersionException()
        {

        }

        public MugenVersionException(string message) : base(message)
        {

        }

        public MugenVersionException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
