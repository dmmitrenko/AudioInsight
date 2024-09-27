namespace AudioInsight.Contracts.Requests.Categories;

public record CreateCategoryRequest(string title, List<string> points)
{
    public const string Route = "/category";
}
