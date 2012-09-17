using System.Configuration;
using MongoDB.Driver;
using Ninject.Modules;
using RepositoryExamples.Core;

namespace RepositoryExamples.MongoDb
{
    public class MongoDbRepositoryNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository>().To<MongoDbRepository>().InSingletonScope();
            Bind<MongoDatabase>().ToMethod(context =>
            {
                var connectionString = ConfigurationManager.AppSettings["MONGODB_URL"];
                var server = MongoServer.Create(connectionString);

                var dbNameStartPosition = connectionString.LastIndexOf(@"/", System.StringComparison.Ordinal);
                var databaseName = connectionString.Substring(dbNameStartPosition + 1);

                var db = server.GetDatabase(databaseName);

                return db;
            });
        }
    }
}