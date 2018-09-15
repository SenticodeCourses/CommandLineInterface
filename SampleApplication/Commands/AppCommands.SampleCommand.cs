using CommandLineInterface;
using CommandLineInterface.Attributes;

namespace SampleApplication.Commands
{
    public partial class AppCommands
    {
        [SubscriptionCommand("-sample", "help")]
        public Command CommandNameCommand => _commandNameCommand ??
            (_commandNameCommand = new Command(ExecuteCommandName, CanExecuteCommandName));

        private Command _commandNameCommand;
        
        private void ExecuteCommandName()
        {
            Logger.WriteResult(_service1.GetData());
            Logger.WriteResult(_service2.GetData());
            Logger.WriteResult(_service3.GetData());
        }
        
        private bool CanExecuteCommandName()
        {
            return true;
        }
    }
}
