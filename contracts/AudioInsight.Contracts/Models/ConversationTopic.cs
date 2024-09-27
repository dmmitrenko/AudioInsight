namespace AudioInsight.Contracts.Models;

public record ConversationTopic(
    Guid id,
    string title,
    List<Point> points);
