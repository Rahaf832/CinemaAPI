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
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                // نجمع كل رسائل الأخطاء المتداخلة
                string GetFullExceptionMessage(Exception exception)
                {
                    if (exception.InnerException == null) return exception.Message;
                    return exception.Message + " --> " + GetFullExceptionMessage(exception.InnerException);
                }

                var response = new
                {
                    message = "Something Wrong, Please Try Again",
                    error = GetFullExceptionMessage(ex)
                };

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json = JsonSerializer.Serialize(response, options);

                await context.Response.WriteAsync(json);
            }

        }
    }
}
