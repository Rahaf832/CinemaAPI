using System.Net;
using System.Text.Json;

namespace CinemaAPI.MiddleWire
{
    public class HandlingErrors
    {
        private readonly RequestDelegate _next;

        public HandlingErrors(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                int statusCode = (int)HttpStatusCode.InternalServerError;
                if (ex is ArgumentException)
                {
                    statusCode = (int)HttpStatusCode.BadRequest;  // 400
                }
                context.Response.StatusCode = statusCode;

                // نجمع كل رسائل الأخطاء المتداخلة
                string GetFullExceptionMessage(Exception exception)
                {
                    if (exception.InnerException == null) return exception.Message;
                    return exception.Message + " --> " + GetFullExceptionMessage(exception.InnerException);
                }

                var response = new
                {
                    message = ex.Message,
                    error = GetFullExceptionMessage(ex)
                };

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json = JsonSerializer.Serialize(response, options);

                await context.Response.WriteAsync(json);
            }

        }
    }
}
