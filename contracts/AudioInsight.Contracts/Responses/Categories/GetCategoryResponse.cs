using AudioInsight.Contracts.Models;

namespace AudioInsight.Contracts.Responses.Categories;

public record GetCategoryResponse(List<ConversationTopic> topics);
