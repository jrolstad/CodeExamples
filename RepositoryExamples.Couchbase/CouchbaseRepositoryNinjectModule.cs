using System;
using Couchbase;
using Couchbase.Configuration;
using Ninject.Modules;

namespace RepositoryExamples.Couchbase
{
    public class CouchbaseRepositoryNinjectModule:NinjectModule
    {
        public override void Load()
        {
            Bind<CouchbaseClient>().ToMethod(context =>
                {
                    var config = new CouchbaseClientConfiguration
                        {
                            Bucket = "<bucket name to store object", 
                            BucketPassword = "<password for the bucket"
                        };
                    config.Urls.Add(new Uri("http://localhost:8091/pools"));
                    return new CouchbaseClient(config);
                });
        }
    }
}