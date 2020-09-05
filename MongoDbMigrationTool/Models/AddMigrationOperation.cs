using System;
using System.Collections.Generic;
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
                
            }
            
            throw new ArgumentException("Incorrect amount of arguments supplied.");
        }

        public IEnumerable<(ArgumentType, string)> ParseArguments(IEnumerable<(string, string)> argumentTokens)
        {
            throw new System.NotImplementedException();
        }

        public bool Perform()
        {
            throw new System.NotImplementedException();
        }
    }
}