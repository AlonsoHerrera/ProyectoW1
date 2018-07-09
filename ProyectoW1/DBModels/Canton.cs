using System;
using System.Collections.Generic;

namespace ProyectoW1.DBModels
{
    public partial class Canton
    {
        public Canton()
        {
            Ubicacion = new HashSet<Ubicacion>();
        }

        public int Idcanton { get; set; }
        public int? Idprovicia { get; set; }
        public int? CodCanton { get; set; }
        public string Nombre { get; set; }

        public ICollection<Ubicacion> Ubicacion { get; set; }
    }
}
