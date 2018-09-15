using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using Module3.Services;
using Senticode.AppEnvironment.Common.Interfaces;

namespace Module3
{
    public class Module3Initializer : IInitializer
    {
        public void Initialize(IIoCContainer container)
        {
            container.RegisterType<IService3, Service3>();
        }
    }
}
