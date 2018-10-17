using Microsoft.Extensions.DependencyInjection;

namespace IS4.Api.Middleware
{
    public static class Policy
    {

        public static void AddPolyce(this IServiceCollection services)
        {
            services.AddAuthorization(
            options =>
                    options.AddPolicy("Competition",
                                 policy => policy.RequireClaim("scope", "CompetitionAPI"))
                                 );
            services.AddAuthorization(
            options =>
                    options.AddPolicy("Player",
                                 policy => policy.RequireClaim("scope", "PlayerAPI"))
                                 );
            services.AddAuthorization(
            options =>
                    options.AddPolicy("Score",
                                 policy => policy.RequireClaim("scope", "ScoreAPI"))
                                 );
            services.AddAuthorization(
            options =>
                    options.AddPolicy("Team",
                                 policy => policy.RequireClaim("scope", "TeamAPI"))
                                 );
        }
    }
}
