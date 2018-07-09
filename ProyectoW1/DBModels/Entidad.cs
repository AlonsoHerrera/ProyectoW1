using System;
using System.Collections.Generic;

namespace ProyectoW1.DBModels
{
    public partial class Entidad
    {
        public Entidad()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int Identidad { get; set; }
        public string Descripcion { get; set; }
        public int? Estado { get; set; }

        public ICollection<Usuario> Usuario { get; set; }
    }
}
