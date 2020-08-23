using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SwarmDotNET
{
    public class SwarmServiceException : Exception
    {
        public SwarmServiceException()
        {
        }

        public SwarmServiceException(string message) : base(message)
        {
        }

        public SwarmServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
