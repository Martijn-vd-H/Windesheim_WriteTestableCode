﻿namespace WriteTestableCode.Shared.Libraries;

public abstract class Emailer
{
    public static void SendEmail(Email email)
    {
        Console.WriteLine(email.Body);
    }
}