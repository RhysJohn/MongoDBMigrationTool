using System.Collections.Generic;
using MongoDbMigrationTool.Models.Enums;

namespace MongoDbMigrationTool.Models
{
    public interface IOperation
    {
        IEnumerable<(ArgumentType, string)> ParseArguments(IEnumerable<(string, string)> argumentTokens);

        bool Perform();
    }
}