using Ninject.Modules;
using log4net;

namespace NinjectBindingExamples.Modules
{
    public class LoggingModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILog>().ToMethod(context => LogManager.GetLogger(context.Binding.Target.GetType()));
        }
    }
}