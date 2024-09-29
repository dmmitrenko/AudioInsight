namespace AudioInsight.Contracts.Queue;
public class AudioAnalysisCompleted
{
    public string Name { get; set; }

    public string Text { get; set; }

    public string EmotionalTone { get; set; }

    public string Location { get; set; }

    public List<string> Categories { get; set; }
}
