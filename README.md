# dRofus-tasks


## Part 1

### Visual Studio
Open the solution in Visual Studio. It can now be run in Visual Studio, or the project can be built and the resulting executable can be run through a terminal.

### VSCode
The project can be run and/or built in VSCode as well. Install the C# Dev Kit extension in order to use VSCode.

### Running executable
If you build the project using either Visual Studio or VSCode, the executable should be found at 'Part1/VendingMachine/bin/Debug/net8.0/VendingMachine.exe'


## Part 2

### Server
Open the server solution in Visual Studio and run it. The API should now be running at https://localhost:7213. 
Accessible endpoints are GET /contacts and GET /contacs/:id.

### Client
Open client folder in VSCode. Run 'ng add @angular/material' to get material stuff. 'ng serve' to start the client. It should be available at http://localhost:4200.

The client and server run separately, since I ran into issues with CORS errors which I didn't find time to sort out.


## Relevant version numbers
.NET 8.0, Node 20.11.1, npm 10.2.4, 