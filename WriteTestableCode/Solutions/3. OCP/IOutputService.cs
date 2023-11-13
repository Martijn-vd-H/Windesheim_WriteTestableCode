namespace WriteTestableCode.Solutions._3._OCP;

public interface IOutputService : IHasSeverity, IHasColor
{
    void WriteLine(string message);
}

public interface IHasSeverity
{
    void SetSeverity(string severity);
}

public interface IHasColor
{
    void SetColor(ConsoleColor color);
}