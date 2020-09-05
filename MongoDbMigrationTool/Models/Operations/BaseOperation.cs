using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using MongoDbMigrationTool.Models.Enums;

namespace MongoDbMigrationTool.Models
{
    public abstract class BaseOperation
    {
        /// <summary>
        /// Gets or sets the amount of arguments need for the operation to carry out successful.
        /// </summary>
        public abstract int ArgumentsNeeded { get; }
        
        /// <summary>
        /// Gets or sets ...
        /// </summary>
        public OperationType Type { get; set; }

        /// <summary>
        /// Gets or sets ...
        /// </summary>
        public ICollection<(ArgumentType, string)> Arguments { get; set; } = new List<(ArgumentType, string)>();

        /// <summary>
        /// Checks the amount of arguments passed in is correct to the operation they are trying to perform.
        /// </summary>
        /// <param name="tokens">Parsed tokens from the input.</param>
        /// <returns>Bool whether the user supplied the correct amount.</returns>
        /// <exception cref="Exception">Exception is thrown if the amount of arguments supplied is incorrect.</exception>
        public bool HasCorrectArguments(IEnumerable<string> tokens)
        {
            var hasCorrectArguments = (tokens.Count() - 1) / 2;
            if (hasCorrectArguments == ArgumentsNeeded)
            {
                return true;
            }

            return false;
             throw new Exception("Invalid count of operations supplied.");
        }
        
        protected Type GetCurrentMongoDbContext(string repoAssembly)
        {
            var assembly = Assembly.Load(repoAssembly);

            var instances = assembly
                .GetTypes()
                .Where(t => t.GetInterfaces().Contains(typeof(IMongoDbContextMigrations)));

            if (instances.Count() == 1)
            {
                return instances.Single();
            }

            // foreach (var instance in instances)
            // {
            //     instance.GetProperties().Where(prop => prop.GetType() == );
            // }
            //
            // //if you want the abstract classes drop the !TheType.IsAbstract but it is probably to instance so its a good idea to keep it.
            // return Assembly.GetAssembly(MyType).GetTypes().Where(TheType => TheType.IsClass && !TheType.IsAbstract && TheType.IsSubclassOf(MyType));
        }
    }
}