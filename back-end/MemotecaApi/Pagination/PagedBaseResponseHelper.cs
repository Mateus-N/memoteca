using MemotecaApi.Core;
using Microsoft.EntityFrameworkCore;

namespace MemotecaApi.Pagination;

public static class PagedBaseResponseHelper
{
    public static async Task<TResponse> GetResponseAsync<TResponse, T>(IQueryable<T> query, PagedBaseRequest request)
        where TResponse : PagedBaseResponse<T>, new()
    {
        TResponse response = new();
        response = await ModelResponse(response, request, query);

        response.Data = query.OrderByDynamic(response.OrderBy!)
                            .ReverseOrder(response.Reverse)
                            .Skip((response.PageNumber - 1) * response.PageSize)
                            .Take(response.PageSize)
                            .ToList();

        return response;
    }

    private static async Task<TResponse> ModelResponse<TResponse, T>
        (TResponse response, PagedBaseRequest request, IQueryable<T> query)
        where TResponse : PagedBaseResponse<T>, new()
    {
        int count = await query.CountAsync();
        response.TotalPages = (int)Math.Ceiling((double)count / request.PageSize);

        response.PageSize = request.PageSize > 10 || request.PageSize < 0 ? 10 : request.PageSize;
        response.PageNumber = request.Page > response.TotalPages ? 1 : request.Page;

        response.OrderBy = $"{request.OrderBy[..1].ToUpper()}{request.OrderBy[1..]}";
        response.Reverse = request.Reverse;
        response.TotalRegisters = count;

        return response;
    }

    private static IEnumerable<T> OrderByDynamic<T>(this IEnumerable<T> query, string propertyName)
    {
        return query.OrderBy(x => x?.GetType().GetProperty(propertyName)?.GetValue(x, null));
    }

    private static IEnumerable<T> ReverseOrder<T>(this IEnumerable<T> query, bool reverse)
    {
        if (reverse)
            return query.Reverse();
        return query;
    }
}
