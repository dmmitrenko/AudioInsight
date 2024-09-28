namespace AudioInsight.Contracts.Models;

public record Call(
    Guid id,
    string name,
    string location,
    EmotionalTone emotionalTone,
    string text,
    List<string> categories
    );