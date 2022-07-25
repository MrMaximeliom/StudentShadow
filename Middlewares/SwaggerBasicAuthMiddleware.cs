using StudentShadow.Controllers;
using StudentShadow.Data;
using StudentShadow.Models;
using StudentShadow.UnitOfWork;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace StudentShadow.Middlewares
{
    public  class SwaggerBasicAuthMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ApplicationDBContext context;
        private readonly IUnitOfWork unitOfWork;

       

        public SwaggerBasicAuthMiddleware(RequestDelegate next)
        {
            this.next = next;
            this.context = new();
            unitOfWork = new StudentShadow.UnitOfWork.UnitOfWork(context);

        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/swagger"))
            {
                string authHeader = context.Request.Headers["Authorization"];
                if (authHeader != null && authHeader.StartsWith("Basic "))
                {
                    // Get the credentials from request header
                    var header = AuthenticationHeaderValue.Parse(authHeader);
                    var inBytes = Convert.FromBase64String(header.Parameter);
                    var credentials = Encoding.UTF8.GetString(inBytes).Split(':');
                    var username = credentials[0];
                    var password = credentials[1];
                    User? user =  await unitOfWork.Users.FindAsync(prop => prop.Username == credentials[0] && prop.Password == credentials[1],null);
                    // validate credentials
                    if (user != null)
                    {
                        await next.Invoke(context).ConfigureAwait(false);
                        return;
                    }
                }
                context.Response.Headers["WWW-Authenticate"] = "Basic";
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            else
            {
                await next.Invoke(context).ConfigureAwait(false);
            }
        }
    }
}
