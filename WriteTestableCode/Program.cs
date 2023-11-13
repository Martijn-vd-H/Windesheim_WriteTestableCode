// See https://aka.ms/new-console-template for more information

using WriteTestableCode.Shared;
using WriteTestableCode.Solutions._3._OCP;

var orderModule = new OrderModule1();

orderModule.Order(HardwareType.Laptop, 3);
orderModule.Order(HardwareType.Monitor, 6);
orderModule.Order(HardwareType.Desk, 2);

// Available from order module 3
//orderModule.Order(HardwareType.Mouse, 2);