using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientRecordApplication
{
    /// <summary>
    /// Exception for when a value should not be negative
    /// </summary>
    class NegativeException : Exception
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public NegativeException()
        {
        }
        /// <summary>
        /// Allows for a message to be saved to new object
        /// </summary>
        /// <param name="message"></param>
        public NegativeException(string message) : base(message)
        {
        }
    }
}
