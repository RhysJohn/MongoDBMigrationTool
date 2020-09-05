using System.Collections.Generic;
using MongoDbMigrationTool.Models.Enums;

namespace MongoDbMigrationTool.Models
{
    public interface IOperation
    {
        void ParseArguments(IEnumerable<string> argumentTokens);

        bool Perform();
    }
}