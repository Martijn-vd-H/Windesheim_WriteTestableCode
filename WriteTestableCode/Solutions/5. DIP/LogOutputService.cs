using WriteTestableCode.Shared.Libraries;
using WriteTestableCode.Solutions._4._LSP___ISP;

namespace WriteTestableCode.Solutions._5._DIP;

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