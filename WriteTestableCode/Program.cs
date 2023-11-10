// See https://aka.ms/new-console-template for more information

using WriteTestableCode.SingleResponsibility;

var orderModule = new OrderModule();

orderModule.Order(HardwareType.Laptop, 3);
orderModule.Order(HardwareType.Monitor, 6);
orderModule.Order(HardwareType.Desk, 2);