using CommandLineInterface;

namespace SampleApplication.Commands
{
    public partial class AppCommands : AppCommandsBase<AppSettings>
    {
        public AppCommands(AppSettings settings) : base(settings)
        {
            //TODO Initialize service instances
        }
    }
}
