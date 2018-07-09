using System;
using System.Collections.Generic;

namespace ProyectoW1.DBModels
{
    public partial class Distrito
    {
        public Distrito()
        {
            Ubicacion = new HashSet<Ubicacion>();
        }

        public int Iddistrito { get; set; }
        public int? Idprovicia { get; set; }
        public int? Idcanton { get; set; }
        public int? CodDistrito { get; set; }
        public string Nombre { get; set; }

        public ICollection<Ubicacion> Ubicacion { get; set; }
    }
}
