namespace CommandLineInterface
{
    /// <summary>
    /// Абстрактный класс-контейнер для команд и глобальных свойств приложения.
    /// Содержит особую команду «-?» которая выводит справку о всех командах и свойствах.
    /// Есть команда «-settings» которая выводит все свойства AppSettings и их текущие значения.
    /// </summary>
    public abstract class AppCommandsBase
    {
        /// <summary>
        /// Предоставляет доступ командам к свойствам приложения.
        /// </summary>
        public AppSettingsBase AppSettings { get; set; }
    }
}
