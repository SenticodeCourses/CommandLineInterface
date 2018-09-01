namespace CommandLineInterface
{
    /// <summary>
    /// Входит в приложение, распознает аргументы коммандной строки,
    /// стартует и инициализирует пользовательский интерфейс.
    /// Регистрация основных типов, классов и методов.
    /// Чтение настроек из БД и т.д.
    /// Отлавливает ошибки на уровне приложения, если они не отловлены ранее
    /// (пишется в лог).
    /// Безопасность работы приложения.
    /// Стартует CLI процесс.
    /// </summary>
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
