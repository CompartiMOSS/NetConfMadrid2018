using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISA.Credentials.API.Middleware
{

    public static class Policy
    {

        public static void AddPolicies(this IServiceCollection services)
        {
            services.AddAuthorization(
            options =>
                    options.AddPolicy("Team",
                                 policy => policy.RequireClaim("scope", "teamAPI")));
            services.AddAuthorization(
           options =>
                   options.AddPolicy("Player",
                                policy => policy.RequireClaim("scope", "playerAPI")));

        }
    }
}
