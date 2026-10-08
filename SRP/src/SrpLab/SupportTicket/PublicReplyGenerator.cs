namespace SrpLab;

public class PublicReplyGenerator
{
    public string Generate(string id, string priority, string agentName, DateTimeOffset deadline)
    {
        var apology = priority == "P1"
            ? "We are treating this as a critical incident."
            : "Thanks for reaching out.";

        return $"Hi,\n{apology}\nTicket {id} is with {agentName}. Next update before {deadline:u}.\n";
    }
}
