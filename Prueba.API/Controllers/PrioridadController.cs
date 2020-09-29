using Prueba.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Prueba.API.Controllers
{
    [RoutePrefix("api/v1/prioridad")]
    public class PrioridadController : ApiController
    {
        [HttpGet]
        [Route("prioridades")]
        public List<Prioridad> GetPrioridades()

        {
            var ctx = new Entities();
            List<Prioridad> retorno = ctx.Prioridad.Where(x => x.Activo == true).ToList();
            return retorno;
        }
    }
}
