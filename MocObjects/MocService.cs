using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using Senticode.AppEnvironment.Common.Interfaces;

namespace MocObjects
{
    public class MocService : IService1, IService2, IService3
    {
        public MocService(IIoCContainer container)
        {
            container.Resolve<ILogger>().WriteLog("create instance mocservice");
        }

        public string GetData()
        {
            return nameof(MocService);
        }
    }
}
