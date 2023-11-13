namespace WriteTestableCode.Shared.Libraries;

public class Emailer
{
    public static void SendEmail(Email email)
    {
        Console.WriteLine(email.Body);
    }
}