namespace MemotecaApi.Core;

public class PagedBaseRequest
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public string OrderBy { get; set; }
    public string Busca { get; set; }
    public bool Reverse { get; set; }

    public PagedBaseRequest()
    {
        Page = 1;
        PageSize = 10;
        OrderBy = "Id";
        Busca = "";
        Reverse = false;
    }
}
