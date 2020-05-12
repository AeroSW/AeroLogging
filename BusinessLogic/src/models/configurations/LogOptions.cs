using Microsoft.Extensions.Configuration.UserSecrets;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace BusinessLogic.src.models.configurations
{
    public class LogOptions
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string Collection { get; set; }
        public string Username { get; set; }
        public string Passsword { get; set; }
        public bool SSL { get; set; }
    }
}
