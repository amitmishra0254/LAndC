using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceLocator.Exceptions
{
    public class GeocodingException : Exception
    {
        public GeocodingException()
        {
        }

        public GeocodingException(string message)
            : base(message)
        {
        }

        public GeocodingException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
