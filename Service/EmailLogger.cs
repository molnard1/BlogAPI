using System.Text;
using MailKit;

namespace MailTest.Service;

public class EmailLogger(StringBuilder builder) : IProtocolLogger
{
    public void LogConnect(Uri uri)
    {
        builder.AppendLine($"Connected to {uri}");
    }

    public void LogClient(byte[] buffer, int offset, int count)
    {
        string str = Encoding.UTF8.GetString(buffer, offset, count);
        if (str.StartsWith("AUTH PLAIN")) str = "[REMOVED]";
        builder.AppendLine(str);
    }

    public void LogServer(byte[] buffer, int offset, int count)
    {
        builder.AppendLine(Encoding.UTF8.GetString(buffer, offset, count));
    }

    public IAuthenticationSecretDetector AuthenticationSecretDetector
    {
        get => null!;
        set { }
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}