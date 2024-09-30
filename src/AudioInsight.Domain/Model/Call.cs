using AudioInsight.Domain.Enums;

namespace AudioInsight.Domain.Model;

public class Call
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Location { get; set; }

    public EmotionalTone EmotionalTone { get; set; }

    public string Text { get; set; }

    public List<string> Categories { get; set; }

    public CallStatus Status { get; set; }
}
