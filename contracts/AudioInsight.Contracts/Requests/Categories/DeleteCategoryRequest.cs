namespace AudioInsight.Contracts.Requests.Categories;

public record DeleteCategoryRequest(string id)
{
    public const string Route = "/category/{category_id}";
}
