using System;
using System.Collections.Generic;

namespace ProyectoW1.DBModels
{
    public partial class Evento
    {
        public Evento()
        {
            CalificacionNavigation = new HashSet<Calificacion>();
            Reserva = new HashSet<Reserva>();
            Ubicacion = new HashSet<Ubicacion>();
        }

        public int Idevento { get; set; }
        public int? IdtipoEvento { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFinal { get; set; }
        public int? Idexpositor { get; set; }
        public int? Idtema { get; set; }
        public int? Limite { get; set; }
        public int? Estado { get; set; }
        public int? Calificacion { get; set; }
        public int? Idubicacion { get; set; }

        public Usuario IdexpositorNavigation { get; set; }
        public Tema IdtemaNavigation { get; set; }
        public Ubicacion IdubicacionNavigation { get; set; }
        public ICollection<Calificacion> CalificacionNavigation { get; set; }
        public ICollection<Reserva> Reserva { get; set; }
        public ICollection<Ubicacion> Ubicacion { get; set; }
    }
}
