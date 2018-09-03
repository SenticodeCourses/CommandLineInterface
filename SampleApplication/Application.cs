using CommandLineInterface;
using SampleApplication.Commands;

namespace SampleApplication
{
    public class Application : ApplicationBase<AppSettings, AppCommands>
    {
        static readonly AppSettings Settings = new AppSettings();

        Application() : base(Settings, new AppCommands(Settings))
        {

        }

        public override void Initialize()
        {
            //TODO register types
            //TODO subscribe unhandler errors
            base.Initialize();
        }

        public static Application Instance { get; } = new Application();
    }
}
