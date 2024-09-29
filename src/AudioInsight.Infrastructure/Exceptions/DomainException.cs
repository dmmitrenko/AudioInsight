using System.Net;

namespace AudioInsight.Infrastructure.Exceptions;

public class DomainException : Exception
{
    public DomainException(string message, HttpStatusCode statusCode)
    {
    }

    public DomainException(string message, HttpStatusCode statusCode, Exception innerException)
    {
    }
}
