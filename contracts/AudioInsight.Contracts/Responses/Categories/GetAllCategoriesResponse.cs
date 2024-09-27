using AudioInsight.Contracts.Models;

namespace AudioInsight.Contracts.Responses.Categories;

public record GetAllCategoriesResponse(List<ConversationTopic> topics);
