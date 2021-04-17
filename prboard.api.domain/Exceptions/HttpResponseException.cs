using System;
using Sentry;

namespace prboard.api.domain.Exceptions
{
    public class HttpResponseException : Exception
    {
        public HttpResponseException()
        {
            
        }
        
        public HttpResponseException(int status, string message) : base($"error - code: {status}, message: {message}")
        {
            Status = status;

            SentrySdk.CaptureException(this);
        }

        public HttpResponseException(int status) : base($"error - code: {status}")
        {
            Status = status;

            SentrySdk.CaptureException(this);
        }
        
        public int Status { get; set; } = 500;

        public object Value { get; set; }
    }
}