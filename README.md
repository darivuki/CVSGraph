# CVSGraph #

Reads data from a provided (structured) sample file, stores it to a database, and displays the data in a graph format.

## Technology used
- Visual Studio 2017
- Asp.net core 1.1
- Entity framework core 1.1.2
- Sql server (localDB)
- Angular CLI 
- Typescript 
- ECharts
- npm (5.3.0), NodeJS (8.2.1)

## Architecture and patterns used
- Simpple CQRS
- Repository and UOW
- Simple event bus with subject services using RxJS

## Building, running, installing...

- Open CMD in root folder and dotnet restore. Run dotnet build after that. This should take care of backend packages and assemblies.

- Cd into WebClient and exeute npm install (this will take some time since Angular CLI has been added as a dev dependency). 

- Run npm build after that to package up client side files.

- To run the application WebService and WebClient must be up and running. They can be started using Visual Studio or by executing dotnet run in their respective roots

## NOTE
Only few tests have been added to the solution using xUnit and Moq to prove the concept. This goes for client side javascript code as well. Error handling has also not been added for simplicity.
Backend code is only adding distinct records for a given file (date - market price). Potential duplicate records which already reside inside the database are not being taking care of. This problem could be solved by adding a unique multiple unique index with ignore-dup-key on date and market price columns. SQL Server would ignore duplicate records this way.

#### Run the app. Press "Upload File" button. Find the sampleSheet.csv file in the root directory of the solution. Wait for the data. Min and Max are displayed with red pins and the most expensive hour is displayed using a blue line from point A to point B. Zoom into the blue part of the graph to see the data. 
