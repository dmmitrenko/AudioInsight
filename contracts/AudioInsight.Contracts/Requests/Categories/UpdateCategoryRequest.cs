using AudioInsight.Contracts.Models;

namespace AudioInsight.Contracts.Requests.Categories;

public record UpdateCategoryRequest(string title, List<Point> points)
{
    public const string Route = "/category/{category_id}";
}
