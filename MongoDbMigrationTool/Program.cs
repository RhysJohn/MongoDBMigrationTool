using System;
using System.Collections.Generic;
using System.Reflection;
using MongoDbMigrationTool.Models;
using MongoDbMigrationTool.Models.Enums;

namespace MongoDbMigrationTool
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                var versionString = Assembly.GetEntryAssembly()
                    .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                    ?.InformationalVersion;

                Console.WriteLine($"MongoDbMigrationTool v{versionString}");
                Console.WriteLine("-------------");
                Console.WriteLine("\nUsage:");
                // Command: 'Add-Migration' - This will add a new snap shot of the MongoDb models.
                // eg. dotnet MongoDbMigrationTool add --project Jasper.Repositories --startup-project Jasper.Api
                Console.WriteLine(
                    "  MongoDbMigrationTool Add-Migration [-ProjectNameArgument] <ProjectName> [-StartupProjectArgument] <StartupProject>");
                // Command: 'Update-Database' - This will initialise through the migrations and apply to the connection string passed.
                // eg. dotnet MongoDbMigrationTool update --mongodb-connection-string https://mongodb:8080 --sql-connection-string Data Source=.;Initial Catalog=.;
                Console.WriteLine(
                    "  MongoDbMigrationTool Update-Database [-MongoDbConnectionString] <ConnectionString> [-SqlConnectionString] <ConnectionString>");
                // Command: 'Remove-Migration' - This will remove the latest migration.
                // eg. dotnet MongoDbMigrationTool remove --project Jasper.Repositories --startup-project Jasper.Api --and-update true
                Console.WriteLine(
                    "  MongoDbMigrationTool Remove-Migration [-ProjectNameArgument] <ProjectName> [-StartupProjectArgument] <StartupProject> [-AndUpdate] <UpdateDb>");
                return;
            }

            var userInput = Console.ReadLine();
            var operation = ParseUserInput(userInput);

            operation.Perform();
        }

        static IOperation ParseUserInput(string input)
        {
            var tokens = input.Split(" ");

            // first token is the operation type - try parse to see if valid operation
            var userOperation = tokens[0];
            var isValidOperation = Enum.TryParse(userOperation, out OperationType operationType);
            if (isValidOperation)
            {
                return CreateOperation(operationType, tokens);


                // var userInput = new UserInput();
                // userInput.Type = operation;
                // var argumentsNeeded = userInput.ArgumentsNeededForOperation();
                //
                // var hasCorrectArguments = (tokens.Length - 1) / 2;
                // if (hasCorrectArguments == argumentsNeeded)
                // {
                //     
                //     return userInput;
                // }
                //  throw new Exception("Invalid count of operations supplied.");
            }

            throw new Exception("Operation input is not valid.");
        }

        public static IOperation CreateOperation(OperationType type, IEnumerable<string> tokens)
        {
            switch (type)
            {
                case OperationType.AddMigration:
                    return new AddMigrationOperation(tokens);
                case OperationType.UpdateDatabase:
                    return new UpdateDatabaseOperation(tokens);
                case OperationType.RemoveMigration:
                    return new RemoveMigrationOperation(tokens);
            }
            
            throw new Exception($"Cannot create operation of type: {type}");
        }
    }
}