using System.Collections.Generic;
using MongoDbMigrationTool.Models.Enums;

namespace MongoDbMigrationTool.Models
{
    public class RemoveMigrationOperation : BaseOperation, IOperation
    {
        public override int ArgumentsNeeded { get; } = 3;

        public RemoveMigrationOperation(IEnumerable<string> tokens)
        {
            
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