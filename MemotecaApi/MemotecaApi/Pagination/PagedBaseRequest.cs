namespace MemotecaApi.Core;

public class PagedBaseRequest
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public string OrderBy { get; set; }
    public string Busca { get; set; }
    public bool Reverse { get; set; }

    public PagedBaseRequest(int page, int pageSize, string orderByProperty, string busca, bool reverse)
    {
        Page = page;
        PageSize = pageSize;
        OrderBy = orderByProperty;
        Busca = busca;
        Reverse = reverse;
    }
}
