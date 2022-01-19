using System;

namespace PolynomialObject.Exceptions
{
    [Serializable]
    public class PolynomialArgumentNullException : Exception
    {
        public PolynomialArgumentNullException() { }

        public PolynomialArgumentNullException(string message) { }
    }
}
