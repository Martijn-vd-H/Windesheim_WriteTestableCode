using WriteTestableCode.Shared.Libraries;

namespace WriteTestableCode.Solutions._6._DIP;

public interface IEmailer
{
    void SendEmail(Email email);
}