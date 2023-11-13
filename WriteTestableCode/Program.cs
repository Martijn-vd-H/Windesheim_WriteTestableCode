// See https://aka.ms/new-console-template for more information

using WriteTestableCode._1._Start;
using WriteTestableCode.Shared;

var orderModule = new OrderModule1();

orderModule.Order(HardwareType.Laptop, 3);
orderModule.Order(HardwareType.Monitor, 6);
orderModule.Order(HardwareType.Desk, 2);

// Available from order module 3
//orderModule.Order(HardwareType.Mouse, 2);