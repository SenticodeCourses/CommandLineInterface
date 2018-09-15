using MocObjects;
using Module1;
using Module2;
using Module3;
using Senticode.AppEnvironment.Common.Interfaces;

namespace Senticode.AppEnvironment.AssemblyAgregator
{
    public class AssemblyAgregator : IIoCContainerHolder, IInitializer
    {
        public IIoCContainer Container { get; private set; }

        public void Initialize(IIoCContainer container)
        {
            Container = container;

            if (IsTested)
            {
                new MocInitializer().Initialize(Container);
            }
            else
            {
                new Module1Initializer().Initialize(Container);
                new Module2Initializer().Initialize(Container);
                new Module3Initializer().Initialize(Container);
            }
        }

        public static AssemblyAgregator Instance { get; } = new AssemblyAgregator();

        public static bool IsTested { get; set; } = false;
    }
}
