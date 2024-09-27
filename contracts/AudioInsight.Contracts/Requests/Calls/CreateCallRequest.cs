namespace AudioInsight.Contracts.Requests.Calls;

public record CreateCallRequest(string audioUrl)
{
    public const string Route = "/call";
}
