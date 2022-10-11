using SmartRental.Operations;
using System.Net;

namespace SmartRental.Diagnostics
{
    public class ApiExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ApiExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/api"))
            {
                try
                {
                    await _next(context);
                }
                catch (Exception e)
                {
                    var response = context.Response;
                    response.ContentType = "application/json";

                    switch (e)
                    {
                        case OperationException oe:
                            // resolve exception to status code and relevant response content
                            // create problem details and serialize to application/json and write to response
                            response.StatusCode = (int)HttpStatusCode.Conflict;
                            // await response.WriteAsync(JsonSerializer.Serialize(...));
                            break;
                        default:
                            // unhandled error
                            response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            // await response.WriteAsync(JsonSerializer.Serialize(...));
                            break;
                    }

                }
            }
            else
            {
                await _next(context);
            }
        }
    }
}
