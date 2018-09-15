using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using Module2.Services;
using Senticode.AppEnvironment.Common.Interfaces;

namespace Module2
{
    public class Module2Initializer : IInitializer
    {
        public void Initialize(IIoCContainer container)
        {
            container.RegisterType<IService2, Service2>();
        }
    }
}
