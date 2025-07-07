using Hangfire;
using Hangfire.Dashboard;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIE.ScheduleServer
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseHangfireDashboard("", new DashboardOptions()
            {
                Authorization = new[] { new CustomAuthorizeFilter() }
            });
        }

        public void ConfigureServices(IServiceCollection servicecollection)
        {
            servicecollection
                .AddHangfire((provider, configuration) => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseStorage("hangfire"));
        }
    }

    public class CustomAuthorizeFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            return true;
        }
    }
}
