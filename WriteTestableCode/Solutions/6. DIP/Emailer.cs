using WriteTestableCode.Shared.Libraries;

namespace WriteTestableCode.Solutions._6._DIP;

public class Emailer : IEmailer
{
    public void SendEmail(Email email)
    {
        Console.WriteLine(email.Body);
    }
}