using Prueba.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Prueba.API.Controllers
{
    [RoutePrefix("api/v1/tarea")]
    public class TareaController : ApiController
    {
        [HttpGet]
        [Route("tareas")]
        public List<Tarea> GetTareas()

        {
            var ctx = new Entities();
            List<Tarea> retorno = ctx.Tarea.ToList();

            return retorno;
        }


        [HttpPost]
        [Route("postTarea")]
        public IHttpActionResult PostTarea(TareaViewModel body)
        {
            var ctx = new Entities();
            try
            {
                Tarea tarea = new Tarea();

                tarea.codigo_estado = body.codigo_estado;
                tarea.descripcion = body.descripcion;
                tarea.codigo_prioridad = body.codigo_prioridad;
                tarea.fecha_fin = body.fecha_fin;
                tarea.fecha_inicio = body.fecha_inicio;
                tarea.id_colaborador = body.id_colaborador;
                tarea.nota = body.nota;

                ctx.Tarea.Add(tarea);
                ctx.SaveChanges();
                return Ok(true);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }


        [HttpGet]
        [Route("tareaFiltros")]
        public List<obtenerTareaFiltro_Result> GetTaeraFiltros(string fecha_inicio, string fecha_fin, int? id_colaborador = null, string codigo_estado = "", string codigo_prioridad = "")
        {
            var ctx = new Entities();
            DateTime fecha_inicial = DateTime.Parse(fecha_inicio);
            DateTime fecha_final = DateTime.Parse(fecha_fin);
            var cadigoEstado = String.IsNullOrEmpty(codigo_estado) ? null : codigo_estado;
            var cadigoPrioridad = String.IsNullOrEmpty(codigo_prioridad) ? null : codigo_prioridad;
            List<obtenerTareaFiltro_Result> retorno = ctx.obtenerTareaFiltro(fecha_inicial, fecha_final, id_colaborador, cadigoEstado, cadigoPrioridad).ToList();
            return retorno;
        }

    }
}
