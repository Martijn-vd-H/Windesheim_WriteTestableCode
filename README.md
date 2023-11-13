# Windesheim_WriteTestableCode
A sample application where I've written some flawed code that will be refactored into testable and more maintainable code

The idea of the application is that someone can order hardware for employees and receive the invoice via email.

We are going to make this code testable by applying the [SOLID Princples.](https://en.wikipedia.org/wiki/SOLID)

## Build, Run & Test

Type in the terminal:

- `dotnet build`
- `dotnet test`

## Structure

We have one solution with two projects:

**WriteTestableCode**

This contains the example code with the SOLID violations. I've divided this in separate folders:

_1. Start:_ We have one class containing all SOLID violations. 

_Solutions:_ Contains every principle applied seperately in their own folders.

**WriteTestableCode.Test**

We have one test class in the _1. Start_ folder. Here you can write your own tests while trying to make the OrderModule testable.
You can look at tests in the _Solutions_ folder when you get stuck or need some inspiration.


