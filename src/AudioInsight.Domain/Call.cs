namespace AudioInsight.Domain;

public class Call
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Location { get; set; }

    public EmotionalTone EmotionalTone { get; set; }

    public string TranscribedText { get; set; }

    public List<string> Categories { get; set; }
}
