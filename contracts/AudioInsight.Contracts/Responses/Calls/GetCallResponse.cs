using AudioInsight.Contracts.Models;

namespace AudioInsight.Contracts.Responses.Calls;

public record GetCallResponse(
    Guid id,
    string name,
    string location,
    EmotionalTone emotionalTone,
    string text,
    List<string> categories
    );