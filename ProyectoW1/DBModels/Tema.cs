using System;
using System.Collections.Generic;

namespace ProyectoW1.DBModels
{
    public partial class Tema
    {
        public Tema()
        {
            Evento = new HashSet<Evento>();
        }

        public int Idtema { get; set; }
        public int? Idtipo { get; set; }
        public string Descripcion { get; set; }

        public TipoEvento IdtipoNavigation { get; set; }
        public ICollection<Evento> Evento { get; set; }
    }
}
