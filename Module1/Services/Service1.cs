using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using Senticode.AppEnvironment.Common.Interfaces;

namespace Module1.Services
{
    class Service1 : IService1
    {
        public string GetData()
        {
            return nameof(Service1);
        }

        public Service1(IIoCContainer container)
        {
            container.Resolve<ILogger>().WriteLog("create instance service1");
            container.RegisterInstance<IService1>(this);
        }
    }
}
