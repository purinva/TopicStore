using Shared.Exceptions;

namespace Api.Middlewares
{
    public class ExceptionMiddleware(
        RequestDelegate requestDelegate)
    {
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await requestDelegate(httpContext);
            }
            catch (CustomException ex)
            {
                httpContext.Response.StatusCode = ex.StatusCode;
                await httpContext.Response.WriteAsync(ex.Message);
            }
            catch (Exception)
            {
                httpContext.Response.StatusCode = 500;
                await httpContext.Response
                    .WriteAsync("Internal Server Error");
            }
        }
    }
}