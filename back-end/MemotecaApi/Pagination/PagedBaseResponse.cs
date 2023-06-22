namespace MemotecaApi.Core;

public class PagedBaseResponse<T>
{
    public string? OrderBy { get; set; }
    public List<T>? Data { get; set; }
    public int TotalPages { get; set; }
    public int TotalRegisters { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public bool Reverse { get; set; }
}
