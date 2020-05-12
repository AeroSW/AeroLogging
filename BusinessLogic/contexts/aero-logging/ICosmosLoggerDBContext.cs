using BusinessLogic.src.models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.contexts.aero_logging
{
    public interface ICosmosLoggerDBContext
    {
        IMongoCollection<ILogger> GetCollection<ILogger>(string name);
    }
}
