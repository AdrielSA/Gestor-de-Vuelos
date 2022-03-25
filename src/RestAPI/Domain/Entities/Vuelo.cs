using System;

namespace Domain.Entities
{
    public partial class Vuelo
    {
        public int Id { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public DateTime Partida { get; set; }
        public DateTime Regreso { get; set; }
        public int Pasajeros { get; set; }
        public int UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
