using GithubClient.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace GithubClient;

public static class DependencyInjection
{
    public static IServiceCollection AddGithubClient(this IServiceCollection services)
    {
        services
            .AddRefitClient<IGithubClient>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://api.github.com"));
        
        return services;
    }
}