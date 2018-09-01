namespace CommandLineInterface
{
    public abstract class AppSettingsBase
    {
        public abstract bool Validate(string command, string[] parameters, out object value);
    }
}
