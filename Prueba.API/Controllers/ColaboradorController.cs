using Prueba.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Prueba.API.Controllers
{
    [RoutePrefix("api/v1/colaborador")]
    public class ColaboradorController : ApiController
    {

        [HttpGet]
        [Route("colaboradores")]
        public List<Colaborador> GetColaboradores()

        {
            var ctx = new Entities();
            List<Colaborador> retorno = ctx.Colaborador.Where(x => x.activo == true).ToList();
            return retorno;
        }
    }
}



