namespace MemotecaApi.Dtos;

public record PagedBaseResponseDto<T>(
    string? OrderBy,
    int PageNumber,
    int PageSize,
    int TotalPages,
    int TotalRegisters,
    bool Reverse,
    List<T> Data
);
