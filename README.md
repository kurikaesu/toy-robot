Toy Robot Solution
==================
## By: Aren Villanueva

Build instructions:

Install the DotNET Core 2.1 SDK or higher from https://www.microsoft.com/net/download

Then:
```
> git clone https://github.com/kurikaesu/toy-robot.git
> cd toy-robot/Application
> dotnet restore
> dotnet run <Input File>
```

Test data is provided in the toy-robot/TestData folder and can be used by example:
```
> dotnet run TestData/Test1
```

Unit tests are also provided and can be invoked by:
```
> cd toy-robot/Tests
> dotnet restore
> dotnet test
```