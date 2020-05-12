using MongoDB.Driver;
using BusinessLogic.src.models;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using BusinessLogic.contexts.aero_logging;
using Microsoft.Extensions.Options;
using BusinessLogic.src.models.configurations;

namespace BusinessLogic.src.repositories.aero_logging
{
    public class AeroLoggerRepository : IAeroLoggerRepository
    {
        private ICosmosLoggerDBContext _dbContext { get; set; }
        private readonly IMongoCollection<ILogger> _collection;
        public AeroLoggerRepository(ICosmosLoggerDBContext dbContext, IOptions<LogOptions> options)
        {
            this._dbContext = dbContext;
            this._collection = this._dbContext.GetCollection<ILogger>(options.Value.Collection);
        }
        public void CreateLog(ILogger log)
        {
            try
            {
                this._collection.InsertOne(log);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public ILogger GetLog(ulong id)
        {
            throw new NotImplementedException();
        }

        public List<ILogger> GetLogs(string application = null, string function = null, DateTime? datetime = null)
        {
            throw new NotImplementedException();
        }

        public void UpdateLog(ulong id, string message)
        {
            throw new NotImplementedException();
        }
    }
}
