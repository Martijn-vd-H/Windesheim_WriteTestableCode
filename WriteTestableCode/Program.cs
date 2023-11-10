// See https://aka.ms/new-console-template for more information

using WriteTestableCode._1._Start;
using WriteTestableCode._3._OCP;
using WriteTestableCode.Shared;

var orderModule = new OrderModule3();

orderModule.Order(HardwareType.Laptop, 3);
orderModule.Order(HardwareType.Monitor, 6);
orderModule.Order(HardwareType.Desk, 2);
orderModule.Order(HardwareType.Mouse, 2);