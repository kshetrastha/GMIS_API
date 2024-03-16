using Microsoft.AspNetCore.Http;
using gmis.Infrastructure.Auth.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gmis.Infrastructure.Auth.Middleware
{
    public class CurrentUserMiddleware : IMiddleware
    {
        private readonly ICurrentUserInitializer _currentUserInitializer;

        public CurrentUserMiddleware(ICurrentUserInitializer currentUserInitializer) =>
            _currentUserInitializer = currentUserInitializer;

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _currentUserInitializer.SetCurrentUser(context.User);
            await next(context);
        }
    }
}
