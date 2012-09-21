using Ninject.Modules;
using Examples.Core;
using Examples.Core.Repositories;

namespace RepositoryExamples.InMemory
{
    public class InMemoryRepositoryNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository>().To<InMemoryRepository>().InSingletonScope();
        }
    }
}