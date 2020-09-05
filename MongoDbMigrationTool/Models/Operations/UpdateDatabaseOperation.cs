using System.Collections.Generic;
using MongoDbMigrationTool.Models.Enums;

namespace MongoDbMigrationTool.Models
{
    public class UpdateDatabaseOperation : BaseOperation, IOperation
    {
        public override int ArgumentsNeeded { get; } = 2;

        public UpdateDatabaseOperation(IEnumerable<string> tokens)
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