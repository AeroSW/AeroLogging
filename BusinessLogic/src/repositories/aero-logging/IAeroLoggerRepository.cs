using BusinessLogic.src.models;
using System;
using System.Collections.Generic;

namespace BusinessLogic.src.repositories.aero_logging
{
    public interface IAeroLoggerRepository
    {
        void CreateLog(ILogger log);
        void UpdateLog(ulong id, string message);
        ILogger GetLog(ulong id);
        List<ILogger> GetLogs(string application = null, string function = null, DateTime? datetime = null);
    }
}
