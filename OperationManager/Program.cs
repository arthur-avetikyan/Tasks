using Autofac;
using OperationManager.IOperationServices;
using OperationManager.OperationServices;
using OperationManager.UI;

namespace OperationManager
{
    class Program
    {
        private static IContainer _container;

        static void Main(string[] args)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<Logger>().As<ILogger>().SingleInstance();
            builder.RegisterType<PluginManager>().As<IPluginManagerService>().InstancePerLifetimeScope();
            builder.RegisterType<OperationResolver>().As<IOperationResolver>().InstancePerLifetimeScope();
            builder.RegisterType<OperationPerformer>().As<IOperationPerformer>().InstancePerLifetimeScope();
            _container = builder.Build();

            using (var scope = _container.BeginLifetimeScope())
            {
                Start(scope);
            }
        }

        private static void Start(ILifetimeScope scope)
        {
            IOperationResolver lResolver = scope.Resolve<IOperationResolver>();
            IOperationPerformer lOperationPerformer = scope.Resolve<IOperationPerformer>();
            string lOption;
            double[] lNumbers;
            double lResult;
            bool lNext;

            do
            {
                lOption = UIHandler.GetOperationInput(lResolver.Operations);
                lOperationPerformer.SetOperation(lResolver.ResolveOperation(lOption));

                lNumbers = UIHandler.GetNumbersInput();
                lResult = lOperationPerformer.PerformOperation(lNumbers);

                UIHandler.DisplayOutput(lOption, lResult, lNumbers);
                lNext = UIHandler.GetExitOption();
            }
            while (lNext);
        }
    }
}