using AudioInsight.Contracts.Models;

namespace AudioInsight.Contracts.Requests.Categories;

public record UpdateCategoryRequest(string? title = null, List<string>? points = null)
{
    public const string Route = "/category/{category_id}";
}
