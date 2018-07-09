using System;
using System.Collections.Generic;

namespace ProyectoW1.DBModels
{
    public partial class TipoEvento
    {
        public TipoEvento()
        {
            Tema = new HashSet<Tema>();
        }

        public int Idevento { get; set; }
        public string Descripcion { get; set; }
        public int? Estado { get; set; }

        public ICollection<Tema> Tema { get; set; }
    }
}
