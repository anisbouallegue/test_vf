using Backend_Test.Models;
using Backend_Test.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Backend_Test.Controllers
{
    [RoutePrefix("api/v1")]
    public class CalculController : ApiController
    {
        private readonly ICalculService _service;

        public CalculController() : this(new CalculService()) { }

        public CalculController(ICalculService calculService)
        {
            _service = calculService;
        }

        [HttpPost]
        [Route("calculate")]
        public IHttpActionResult Calculate([FromBody] RequeteCalcul request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = _service.Calculer(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}