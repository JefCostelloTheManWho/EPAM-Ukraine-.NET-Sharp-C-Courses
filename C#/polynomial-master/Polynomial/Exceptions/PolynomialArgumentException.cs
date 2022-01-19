using System;

namespace PolynomialObject.Exceptions
{
    [Serializable]
    public class PolynomialArgumentException : Exception
    {

        public PolynomialArgumentException() { }

        public PolynomialArgumentException(string message) { }
    }
}
