namespace MongoDbMigrationTool.Models.Migrations
{
    /// <summary>
    /// A base class inherited by each MongoDb migration.
    /// </summary>
    public abstract class Migration
    {





        protected abstract void Up();

        protected abstract void Down();
    }
}