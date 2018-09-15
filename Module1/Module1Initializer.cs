using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using Module1.Services;
using Senticode.AppEnvironment.Common.Interfaces;

namespace Module1
{
    public class Module1Initializer : IInitializer
    {
        public void Initialize(IIoCContainer container)
        {
            container.RegisterType<IService1, Service1>();
        }
    }
}
