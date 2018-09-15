using Senticode.AppEnvironment.Common.Interfaces;

namespace Senticode.UnityIoC
{
    public static class ServiceLocator
    {
        public static IIoCContainer Container { get; } = new UnityContainerFasade();
    }
}
