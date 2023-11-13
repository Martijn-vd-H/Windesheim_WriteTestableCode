using WriteTestableCode.Shared.Libraries;

namespace WriteTestableCode.Solutions._4._LSP___ISP;

public class LogOutputService : IOutputService, IHasSeverity
{
    public void WriteLine(string message)
    {
        Logger.WriteMessage(message);
    }

    public void SetSeverity(string severity)
    {
        Logger.SetSeverity(severity);
    }

    public void SetInformationMode()
    {
        Logger.SetSeverity("Information");
    }
}