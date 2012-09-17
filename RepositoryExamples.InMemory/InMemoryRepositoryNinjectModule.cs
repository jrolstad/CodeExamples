using Ninject.Modules;
using RepositoryExamples.Core;

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