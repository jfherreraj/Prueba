using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prueba.Models
{
    [MetadataType(typeof(PersonaMetaData))]
    public partial class Persona
    {

        public List<Persona> Listar_Persona()
        {
            var personas = new List<Persona>();
            try
            {
                using (var ctx = new Model())
                {
                    //ctx.Database.Log = msg => Debug.WriteLine(msg);
                    personas = ctx.Persona.ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return personas;
        }

        public class PersonaMetaData
        {
            [Key]
            public int Id { get; set; }

            [Key]
            [StringLength(30)]
            public string nombre { get; set; }

            [Key]
            [StringLength(30)]
            public string email { get; set; }

            [StringLength(30)]
            public string cedula { get; set; }
        }
    }
}