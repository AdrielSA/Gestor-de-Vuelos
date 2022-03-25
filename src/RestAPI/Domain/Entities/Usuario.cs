using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            Vuelos = new HashSet<Vuelo>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public string CodigoRol { get; set; }

        public virtual Rol CodigoRolNavigation { get; set; }
        public virtual ICollection<Vuelo> Vuelos { get; set; }
    }
}
