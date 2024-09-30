using System.Net;

namespace AudioInsight.Infrastructure.Exceptions;

public class DomainException : Exception
{
    public DomainException(string message, HttpStatusCode statusCode)
        : base(message)
    {
        StatusCode = statusCode;
    }

    public DomainException(string message, HttpStatusCode statusCode, Exception innerException)
        : base(message, innerException)
    {
        StatusCode = statusCode;
    }

    public HttpStatusCode StatusCode { get; set; }
}
