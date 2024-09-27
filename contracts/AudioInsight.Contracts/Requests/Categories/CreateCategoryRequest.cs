using AudioInsight.Contracts.Models;

namespace AudioInsight.Contracts.Requests.Categories;

public record CreateCategoryRequest(string topic, List<Point> points)
{
    public const string Route = " /category";
}
