﻿using WriteTestableCode.Shared;

namespace WriteTestableCode._4._LSP;

public class OrderParameters
{
    public HardwareType Type { get; set; }
    public int Number { get; set; }
    
    public OrderParameters(HardwareType type, int number)
    {
        Type = type;
        Number = number;
    }
}