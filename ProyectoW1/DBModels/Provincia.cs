using System;
using System.Collections.Generic;

namespace ProyectoW1.DBModels
{
    public partial class Provincia
    {
        public Provincia()
        {
            Ubicacion = new HashSet<Ubicacion>();
        }

        public int Idprovincia { get; set; }
        public string Nombre { get; set; }

        public ICollection<Ubicacion> Ubicacion { get; set; }
    }
}
