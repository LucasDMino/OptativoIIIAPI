using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPWEBAPI2.Models
{
    public class Persona
    {
        public int idPersona { get; set; }
        public int idCiudad { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Edad { get; set; }
    }
}
