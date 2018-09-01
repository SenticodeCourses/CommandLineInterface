namespace CommandLineInterface.Infrastructure
{
    public class CommandInput
    {
        public CommandInput(string commandName, string[] parameters)
        {
            CommandName = commandName;
            Params = parameters;
        }

        public string CommandName { get; set; }
        public string[] Params { get; set; }
    }
}
