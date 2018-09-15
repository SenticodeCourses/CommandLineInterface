namespace Senticode.AppEnvironment.Common.Interfaces
{
    public interface IApplication : IIoCContainerHolder
    {
        void Run(string[] args);
        void Run();
        void Initialize();
        ILogger Logger { get; }
    }
}
