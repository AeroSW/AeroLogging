using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BusinessLogic.src.models;
using BusinessLogic.src.repositories.aero_logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AeroLogging.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private IAeroLoggerRepository _repository { get; set; }
        public LogController(IAeroLoggerRepository repository)
        {
            this._repository = repository;
        }
        [HttpPost, Route("PostLog")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PostLog(Logger log)
        {
            try
            {
                _repository.CreateLog(log);
                return Ok("POST successful");
            }
            catch(Exception exception)
            {
                var result = new ContentResult();
                result.StatusCode = StatusCodes.Status500InternalServerError;
                result.Content = exception.Message + "\n" + exception.StackTrace;
                return result;
            }
        }
    }
}