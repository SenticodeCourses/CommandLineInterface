using System.Threading;
using CommandLineInterface;
using SampleApplication.Commands;
using SampleApplication.Services;
using Senticode.AppEnvironment.Common.Interfaces;
using Senticode.UnityIoC;
using Senticode.AppEnvironment.AssemblyAgregator;

namespace SampleApplication
{
    public class Application : ApplicationBase<AppSettings, AppCommands>, IApplication
    {
        static readonly AppSettings Settings = new AppSettings();

        Application() : base(Settings, new AppCommands(Settings))
        {
            
        }

        public override void Initialize()
        {
            RegisterTypes();
            AssemblyAgregator.IsTested = true;
            AssemblyAgregator.Instance.Initialize(Container);
            //TODO subscribe unhandler errors
            base.Initialize();
            AppCommands.Initialize(Container);
        }

        public ILogger Logger { get; private set; }

        public static Application Instance { get; } = new Application();
        public IIoCContainer Container { get; } = ServiceLocator.Container;
        
        void RegisterTypes()
        {
            Container.RegisterType<ILogger, ConsoleLogger>();
            Logger = Container.Resolve<ILogger>();
        }
    }
}
