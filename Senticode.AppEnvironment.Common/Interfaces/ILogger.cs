using System;

namespace Senticode.AppEnvironment.Common.Interfaces
{
    public interface ILogger
    {
        void WriteLog(string log);
        void WriteResult(string result);
        void WriteInformation(string information);
        void WriteException(Exception exception);
    }
}
