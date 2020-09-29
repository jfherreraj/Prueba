using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Prueba.WEB.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Prueba.WEB.Controllers
{
    public class HomeController : Controller
    { 
        public ActionResult Index()
        {
            List<Colaborador> colaboadores = getColaboradores();
            List<Estado> estados = getEstados();
            List<Prioridad> prioridades = getPrioridades();

            ViewBag.Colaboradores = colaboadores;
            ViewBag.Estados = estados;
            ViewBag.Prioridades = prioridades;

            return View();
        }

        public ActionResult AgregaTarea()
        {
            List<Colaborador> colaboadores = getColaboradores();
            List<Estado> estados = getEstados();
            List<Prioridad> prioridades = getPrioridades();

            ViewBag.Colaboradores = colaboadores;
            ViewBag.Estados = estados;
            ViewBag.Prioridades = prioridades;
            return View();
        }

        public ActionResult _TareasAgregadas()
        {
            List<Tarea> tareas = getTareas();

            ViewBag.Tareas = tareas;
            ViewBag.Colaboradores = getColaboradores();

            return PartialView();
        }

        public ActionResult _TareasAgregadasFiltro(FiltroTarea filtro)
        {
            List<TareasFitros> tareas = getTareasFiltro(filtro);

            ViewBag.Tareas = tareas;

            return PartialView();
        }

        #region llamadas al api

        public List<Tarea> getTareas()
        {
            JArray temp;
            var url = $"https://localhost:44375/api/v1/tarea/tareas";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();
            var responseReader = new StreamReader(webStream);
            var response = responseReader.ReadToEnd();
            temp = JArray.Parse(response);

            List<Tarea> lista = ((JArray)temp).Select(x => new Tarea
            {
                id_tarea = (int)x["id_tarea"],
                id_colaborador = String.IsNullOrEmpty(x["id_colaborador"].ToString()) ? null : (int?)x["id_colaborador"],
                descripcion = (string)x["descripcion"],
                codigo_estado = (string)x["codigo_estado"],
                codigo_prioridad = (string)x["codigo_prioridad"],
                fecha_inicio = (DateTime)x["fecha_inicio"],
                fecha_fin = (DateTime)x["fecha_fin"],
                nota = (string)x["nota"],


            }).ToList();

            responseReader.Close();
            return lista;
        }

        public List<Colaborador> getColaboradores()
        {
            JArray temp;
            var url = $"https://localhost:44375/api/v1/colaborador/colaboradores";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();
            var responseReader = new StreamReader(webStream);
            var response = responseReader.ReadToEnd();
            temp = JArray.Parse(response);

            List<Colaborador> lista = ((JArray)temp).Select(x => new Colaborador
            {
                id_colaborador = (int)x["id_colaborador"],
                nombre = (string)x["nombre"],
                apellido = (string)x["apellido"],
                email = (string)x["email"],
                activo = (bool)x["activo"]
            }).ToList();

            responseReader.Close();
            return lista;
        }


        public List<Estado> getEstados()
        {
            JArray temp;
            var url = $"https://localhost:44375/api/v1/estado/estados";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();
            var responseReader = new StreamReader(webStream);
            var response = responseReader.ReadToEnd();
            temp = JArray.Parse(response);

            List<Estado> lista = ((JArray)temp).Select(x => new Estado
            {
                codigo_estado = (string)x["codigo_estado"],
                descripcion = (string)x["descripcion"],
                activo = (bool)x["activo"]
            }).ToList();

            responseReader.Close();
            return lista;
        }



        public List<Prioridad> getPrioridades()
        {
            JArray temp;
            var url = $"https://localhost:44375/api/v1/prioridad/prioridades";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();
            var responseReader = new StreamReader(webStream);
            var response = responseReader.ReadToEnd();
            temp = JArray.Parse(response);

            List<Prioridad> lista = ((JArray)temp).Select(x => new Prioridad
            {
                codigo_prioridad = (string)x["codigo_prioridad"],
                descripcion = (string)x["descripcion"],
                Activo = (bool)x["Activo"]
            }).ToList();

            responseReader.Close();
            return lista;
        }


        public List<TareasFitros> getTareasFiltro(FiltroTarea filtro)
        {
            JArray temp;

            filtro.codigo_estado = filtro.codigo_estado == "Seleccione" ? " " : filtro.codigo_estado;
            filtro.codigo_prioridad = filtro.codigo_prioridad == "Seleccione" ? " " : filtro.codigo_prioridad;
            var url = $"https://localhost:44375/api/v1/tarea/tareaFiltros?fecha_inicio=" + filtro.fecha_inicio.ToString("yyyy-MM-dd") + "&fecha_fin=" + filtro.fecha_fin.ToString("yyyy-MM-dd")
                                                                                                + "&id_colaborador=" + filtro.id_colaborador + "&codigo_estado=" + filtro.codigo_estado
                                                                                                + "&codigo_prioridad=" + filtro.codigo_prioridad;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();
            var responseReader = new StreamReader(webStream);
            var response = responseReader.ReadToEnd();
            temp = JArray.Parse(response);

            List<TareasFitros> lista = ((JArray)temp).Select(x => new TareasFitros
            {
                id_tarea = (int)x["id_tarea"],
                descripcion = (string)x["descripcion"],
                nombre = (string)x["nombre"],
                codigo_estado = (string)x["codigo_estado"],
                codigo_prioridad = (string)x["codigo_prioridad"],
                fecha_inicio = (DateTime)x["fecha_inicio"],
                fecha_fin = (DateTime)x["fecha_fin"],
            }).ToList();

            responseReader.Close();
            return lista;
        }


        [HttpPost]
        public JsonResult InsertarTarea(Tarea tarea)
        {
            Object x;
            var url = $"https://localhost:44375/api/v1/tarea/postTarea";
            var request = (HttpWebRequest)WebRequest.Create(url);
            var caracteristicas = JsonConvert.SerializeObject(tarea);
            //var compannias = JsonConvert.SerializeObject(lista_compannias);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(caracteristicas);
                streamWriter.Flush();
                streamWriter.Close();
            }

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader != null)
                        {
                            x = JsonResponseFactory.SuccessResponse("Envío correcto del formulario");
                            return Json(x, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            x = JsonResponseFactory.ErrorResponse("No se pudo envíar el formulario");
                            return Json(x, JsonRequestBehavior.DenyGet);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                x = JsonResponseFactory.ErrorResponse("No se pudo envíar el formulario");
                return Json(x, JsonRequestBehavior.DenyGet);
            }

        }






        #endregion

    }
}
