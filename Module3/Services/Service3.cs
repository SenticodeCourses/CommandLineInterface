using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using Senticode.AppEnvironment.Common.Interfaces;

namespace Module3.Services
{
    class Service3 : IService3
    {
        public string GetData()
        {
            return nameof(Service3);
        }

        public Service3(IIoCContainer container)
        {
            container.Resolve<ILogger>().WriteLog("create instance service3");
            container.RegisterInstance<IService3>(this);
        }
    }
}
