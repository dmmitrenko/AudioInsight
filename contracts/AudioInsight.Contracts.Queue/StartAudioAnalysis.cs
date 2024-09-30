namespace AudioInsight.Contracts.Queue;

public class StartAudioAnalysis
{
    public Guid Id { get; set; }

    public string AudioUrl { get; set; }
}
