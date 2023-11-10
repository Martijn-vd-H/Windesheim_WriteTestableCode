namespace WriteTestableCode.SingleResponsibility;

public class APICaller
{
    public ApiResult OrderLaptops(int number)
    {
        Console.WriteLine($"Ordering {number} laptops...");
        
        return new ApiResult()
        {
            HasSucceeded = true,
            Price = number * 1200
        };
    }
    
    public ApiResult OrderMonitors(int number)
    {
        Console.WriteLine($"Ordering {number} monitors...");
        
        return new ApiResult()
        {
            HasSucceeded = true,
            Price = number * 250
        };
    }
    
    public ApiResult OrderDesks(int number)
    {
        Console.WriteLine($"Ordering {number} desks...");
        
        return new ApiResult()
        {
            HasSucceeded = true,
            Price = number * 900
        };
    }
}