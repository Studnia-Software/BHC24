using GithubClient.Interfaces;
using Refit;
using Microsoft.Extensions.DependencyInjection;

namespace GithubClient;

public static class DependencyInjection
{
    public static IServiceCollection AddGithubClient(this IServiceCollection services)
    {
        services
            .AddRefitClient<IGithubApi>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://api.github.com"));;

        return services;
    }
}