namespace WriteTestableCode.SingleResponsibility;

public static class Constants
{
    public static readonly Dictionary<HardwareType, int> HardwareTypes = new()
    {
        {HardwareType.Laptop, 1200},
        {HardwareType.Monitor, 250},
        {HardwareType.Desk, 500},
    };
}