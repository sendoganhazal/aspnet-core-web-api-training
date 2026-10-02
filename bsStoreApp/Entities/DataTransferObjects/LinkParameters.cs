using Entities.RequestFeatures;
using Microsoft.AspNetCore.Http;


namespace Entities.DataTransferObjects
{
    public record LinkParameters
    {
        public LinkParameters ( )
        {
        }

        public LinkParameters ( BookParameters bookParameters, HttpContext httpContext )
        {
            BookParameters = bookParameters;
            HttpContext = httpContext;
        }

        public BookParameters BookParameters { get; init; }
        public HttpContext HttpContext { get; init; }
    }
}
