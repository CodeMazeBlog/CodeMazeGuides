using System;

namespace Entities.Models;

public abstract class QueryStringParameters
{
    const int MaxPageSize = 50;

    private int _pageNumber = 1;
    private int _pageSize = 10;

    public int PageNumber
    {
        get => _pageNumber;
        set => _pageNumber = Math.Max(value, 1);
    }

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = Math.Clamp(value, 1, MaxPageSize);
    }

    public string? OrderBy { get; set; }
}
