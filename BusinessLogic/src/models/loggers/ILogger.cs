using BusinessLogic.src.enums;
using System;
using System.Collections.Generic;

namespace BusinessLogic.src.models
{
    public interface ILogger
    {
        string ApplicationName { get; set; }
        string ProjectName { get; set; }
        string FunctionName { get; set; }
        string LineNumber { get; set; }
        string Message { get; set; }
        LoggerType LogType { get; set; }
        List<string> EmailList { get; set; }
        string CreateUsername { get; set; }
        DateTime CreateDateTime { get; set; }
    }
}
