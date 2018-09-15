using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using Senticode.AppEnvironment.Common.Interfaces;

namespace Module2.Services
{
    class Service2 : IService2
    {
        public string GetData()
        {
            return nameof(Service2);
        }

        public Service2(IIoCContainer container)
        {
            container.Resolve<ILogger>().WriteLog("create instance service2");
            container.RegisterInstance<IService2>(this);
        }
    }
}
