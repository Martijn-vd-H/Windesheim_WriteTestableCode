// \TODO move to module3 ??
using WriteTestableCode.Solutions._4._LSP___ISP;

namespace WriteTestableCode.Solutions._3._OCP;

public interface IOutputService : IHasSeverity, IHasColor
{
    void WriteLine(string message);
}