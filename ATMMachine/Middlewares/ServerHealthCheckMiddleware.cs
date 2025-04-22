using ATMMachine.Constants;
using ATMMachine.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace ATMMachine.Middlewares
{
    public class ServerHealthCheckMiddleware
    {
        private readonly RequestDelegate _next;

        public ServerHealthCheckMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ATMDbContext dbContext)
        {
            try
            {
                await dbContext.Database.ExecuteSqlRawAsync(ApplicationConstant.ServerAvailabilityQuery);
                await _next(context);
            }
            catch (Exception)
            {
                context.Response.StatusCode = 503;
                await context.Response.WriteAsync(ApplicationConstant.ServerNotAvailableException);
            }
        }
    }
}
