using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using Senticode.AppEnvironment.Common.Interfaces;

namespace MocObjects
{
    public class MocInitializer : IInitializer
    {
        public void Initialize(IIoCContainer container)
        {
            container.RegisterType<IService1, MocService>();
            container.RegisterType<IService2, MocService>();
            container.RegisterType<IService3, MocService>();
        }
    }
}
