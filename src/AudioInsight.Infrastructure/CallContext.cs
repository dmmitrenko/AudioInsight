namespace AudioInsight.Infrastructure;
public class CallContext
{
    public string AudioUrl { get; set; }
    public byte[] AudioData { get; set; }
    public string Transcription { get; set; }
    public string EmotionalTone { get; set; }
}
