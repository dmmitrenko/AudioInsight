using System.Net;

namespace AudioInsight.Infrastructure;

public class DomainException : Exception
{
    public DomainException(string message, HttpStatusCode statusCode)
    {
    }

    public DomainException(string message, HttpStatusCode statusCode, Exception innerException)
    {
    }
}
