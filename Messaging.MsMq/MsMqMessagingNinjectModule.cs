using System.Messaging;
using Examples.Core.Messaging;
using Messaging.MsMq.Formatters;
using Ninject.Modules;

namespace Messaging.MsMq
{
    public class MsMqMessagingNinjectModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IMessageFormatter>().To<JsonMessageFormatter>();
            Bind<IMessenger>().To<MsMqMessenger>();

            Bind<IMessageSubscriber<object>>()
                .To<MsMqMessageSubscriber<object>>(); // Should be specific message type here
        }
    }
}