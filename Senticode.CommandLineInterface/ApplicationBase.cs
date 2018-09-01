namespace CommandLineInterface
{
    public abstract class ApplicationBase<TSettings, TCommands>
        where TSettings : AppSettingsBase
        where TCommands : AppCommandsBase
    {
        protected ApplicationBase(TSettings appSettingsBase, TCommands appCommandsBase)
        {
            AppSettings = appSettingsBase;
            AppCommands = appCommandsBase;
        }

        public abstract void Run();

        public abstract void Run(string[] args);

        public abstract void Initialize();

        public TSettings AppSettings { get; }
        public TCommands AppCommands { get; }
    }
}
