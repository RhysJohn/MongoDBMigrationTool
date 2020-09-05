using System;
using System.Collections.Generic;
using System.Linq;
using MongoDbMigrationTool.Models.Enums;

namespace MongoDbMigrationTool.Models
{
    public class AddMigrationOperation : BaseOperation, IOperation
    {
        public override int ArgumentsNeeded { get; } = 2;

        public AddMigrationOperation(IEnumerable<string> tokens)
        {
            var hasCorrectAmount = HasCorrectArguments(tokens);

            if (hasCorrectAmount)
            {
                ParseArguments(tokens);
            }
            
            throw new ArgumentException("Incorrect amount of arguments supplied.");
        }

        public void ParseArguments(IEnumerable<string> argumentTokens)
        {
            // remove the first one as this is the operation token.
            var arguments = argumentTokens.ToList();
            arguments.RemoveAt(0);

            for (int i = 0; i < ArgumentsNeeded; i++)
            {
                int index;
                if (i == 0)
                {
                    index = 0;
                }
                else
                {
                    index = i * 2;
                }
                
                var type = arguments.ElementAt(index);
                var isValidArgumentType = Enum.TryParse(type, out ArgumentType argumentType);
                if (isValidArgumentType)
                {
                    var argumentValue = arguments.ElementAt(index: index + 1);
                    Arguments.Add((argumentType, argumentValue));
                    continue;
                }
                
                throw new ArgumentException($"Argument: {type} is not a correct argument type for 'add' operation.");
            }
        }

        public bool Perform()
        {
            // check if the migration name is valid
            
            // get the old MongoDbContext
            // run through and build the mongodbcontext from the previous migrations
            
            // get the new MongoDbContext
            var mongoDbContext = GetCurrentMongoDbContext(Arguments.Single(arg=> arg.Item1 == ArgumentType.ProjectName).Item2);
            
            // Compare the models to check where the differences are. - check if the properties are the same.
            
            if (true)
            {
                // models have differences - determine what the differences are
                
                // create a new file with the difference in the models
                
                // add this migration into the table "dbo._MongoMigrationHistory"
            }
            
            //return with that there are no changes to the model and log this out to the user.

            return false;
        }
    }
}