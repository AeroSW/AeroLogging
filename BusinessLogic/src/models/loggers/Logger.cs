using BusinessLogic.src.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLogic.src.models
{
    public class Logger : ILogger
    {
        [Required]
        public string ApplicationName { get; set; }
        [Required]
        public string ProjectName { get; set; }
        public string FunctionName { get; set; }
        public string LineNumber { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public LoggerType LogType { get; set; }
        public List<string> EmailList { get; set; }
        [Required]
        public string CreateUsername { get; set; }
        [Required]
        public DateTime CreateDateTime { get; set; }
    }
}
