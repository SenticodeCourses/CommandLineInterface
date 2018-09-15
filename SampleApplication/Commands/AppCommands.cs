using CommandLineInterface;
using Common.Interfaces;
using Senticode.AppEnvironment.Common.Interfaces;

namespace SampleApplication.Commands
{
    public partial class AppCommands : AppCommandsBase<AppSettings>, IInitializer
    {
        public AppCommands(AppSettings settings) : base(settings)
        {
            
        }

        ILogger Logger { get; set; }
        IIoCContainer Container { get; set; }

        private IService1 _service1;
        private IService2 _service2;
        private IService3 _service3;

        public void Initialize(IIoCContainer container)
        {
            //TODO Initialize service instances
            Container = container;
            Logger = Container.Resolve<ILogger>();

            _service1 = Container.Resolve<IService1>();
            _service2 = Container.Resolve<IService2>();
            _service3 = Container.Resolve<IService3>();
        }
    }
}
