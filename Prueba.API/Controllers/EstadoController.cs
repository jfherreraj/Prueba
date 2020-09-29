using Prueba.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Prueba.API.Controllers
{
    [RoutePrefix("api/v1/estado")]
    public class EstadoController : ApiController
    {
        [HttpGet]
        [Route("estados")]
        public List<Estado> GetEstados()

        {
            var ctx = new Entities();
            List<Estado> retorno = ctx.Estado.Where(x => x.activo == true).ToList();
            return retorno;
        }
    }
}
