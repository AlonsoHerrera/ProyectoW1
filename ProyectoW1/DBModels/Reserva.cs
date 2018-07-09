using System;
using System.Collections.Generic;

namespace ProyectoW1.DBModels
{
    public partial class Reserva
    {
        public int Idreserva { get; set; }
        public int? Idevento { get; set; }
        public int? Idusuario { get; set; }
        public int? Reserva1 { get; set; }
        public int? Confirma { get; set; }

        public Evento IdeventoNavigation { get; set; }
        public Usuario IdusuarioNavigation { get; set; }
    }
}
