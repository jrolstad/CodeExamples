using Examples.Core.Repositories;
using Ninject.Modules;

namespace RepositoryExamples.AmazonSimpleDb
{
    public class AmazonSimpleDbRepositoryNinjectModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository>().To<AmazonSimpleDbRepository>();
            Bind<SimpleDbProviderFactory>().ToMethod(context =>
                {
                    var awsAccessKey = "<Aws Access Key Value Here>";
                    var awsSecretKey = "<Aws Secret Key Value Here>";
                    return new SimpleDbProviderFactory(awsAccessKey,awsSecretKey);
                });
        }
    }
}