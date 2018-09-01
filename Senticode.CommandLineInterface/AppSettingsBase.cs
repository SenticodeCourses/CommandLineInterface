namespace CommandLineInterface
{
    /// <summary>
    /// Абстрактный класс-контейнер для команд и глобальных свойств приложения.
    /// </summary>
    public abstract class AppSettingsBase
    {
        /// <summary>
        /// Будет проверять корректность введенных пользователем данных
        /// и если корректно, то возвращать значение,
        /// преобразованное к типу соответствующему изменяемому свойству.
        /// </summary>
        public abstract bool Validate(string command, string[] parameters, out object value);
    }
}
