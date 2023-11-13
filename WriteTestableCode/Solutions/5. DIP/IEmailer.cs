using WriteTestableCode.Shared.Libraries;

namespace WriteTestableCode.Solutions._5._DIP;

public interface IEmailer
{
    void SendEmail(Email email);
}