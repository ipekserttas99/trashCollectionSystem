using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Homework_.Middleware
{
    public class GetVehicleByIdMiddleware
    {
        private readonly RequestDelegate next;

        public GetVehicleByIdMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke (HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/GetVehicleById")) //GetVehicleById metoduna gidildiğinde
            {
                context.Response.StatusCode = 403; //403 dön
                await context.Response.WriteAsync("403 -  3. odev kosulu saglandi...");
                
                return;
        }

        await next.Invoke(context);
        }
    }
}
