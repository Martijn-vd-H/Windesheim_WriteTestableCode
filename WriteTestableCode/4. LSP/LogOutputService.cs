﻿using WriteTestableCode.Libraries;

namespace WriteTestableCode._4._LSP;

public class LogOutputService : IOutputService
{
    public void WriteLine(string message)
    {
        Logger.WriteMessage(message);
    }

    public void SetSeverity(string severity)
    {
        Logger.SetSeverity(severity);
    }

    public void SetColor(ConsoleColor color)
    {
        // Color is not relevant
    }
}