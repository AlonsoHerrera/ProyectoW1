using System;
using System.Collections.Generic;

namespace ProyectoW1.DBModels
{
    public partial class NivelAcademico
    {
        public NivelAcademico()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int Idnivel { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Usuario> Usuario { get; set; }
    }
}
