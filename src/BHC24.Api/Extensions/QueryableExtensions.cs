using System.Runtime.CompilerServices;
using BHC24.Api.Models;
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
    
    public static async Task<PaginationResponse<TEntity>> PaginateAsync<TEntity>(
        this IQueryable<TEntity> query, PaginationRequest request, CancellationToken ct = default)
    {
        return await query.PaginateAsync(request.Page, request.PageSize, ct);
    }
    
    public static async Task<PaginationResponse<TEntity>> PaginateAsync<TEntity>(
        this IQueryable<TEntity> query, int page, int pageSize, CancellationToken ct = default)
    {
        var totalItems = await query.CountAsync(ct);
        var items = await query.Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);
        
        return new PaginationResponse<TEntity>
        {
            Data = items,
            TotalCount = totalItems,
            Page = page,
            PageSize = pageSize
        };
    }
}