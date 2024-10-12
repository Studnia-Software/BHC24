using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace BHC24.Api.Extensions;

public static class QueryableExtensions
{
    public static async IAsyncEnumerable<TEntity> ToAsyncEnumerable<TEntity>(this IQueryable<TEntity> query,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await foreach (var entity in query.AsAsyncEnumerable().WithCancellation(ct))
        {
            yield return entity;
        }
    }
}