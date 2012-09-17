using Ninject.Modules;
using Raven.Client;
using Raven.Client.Document;
using RepositoryExamples.Core;

namespace RepositoryExamples.RavenDb
{
    public class RavenDbRepositoryNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository>().To<RavenDbRepository>();
            Bind<IDocumentStore>().ToMethod(context =>
                {
                    var store = new DocumentStore {ConnectionStringName = "RavenDB"};
                    store.Initialize();

                    return store;
                });
        }
    }

}