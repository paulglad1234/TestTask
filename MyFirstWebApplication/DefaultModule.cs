using Autofac;

namespace MyFirstWebApplication
{
    public class DefaultModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Services.JsonFileWorker>().As<Services.IFileWorker>();
        }
    }
}