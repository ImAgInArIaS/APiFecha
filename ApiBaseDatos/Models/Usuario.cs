using System;
using System.Collections.Generic;

namespace ApiBaseDatos.Models
{
    public partial class Usuario
    {
        public Guid Id { get; set; }
        public string NombreUsuario { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateOnly FechaAlta { get; set; }
        public bool Activo { get; set; }
        public Guid IDroll { get; set; }

        public virtual Role IDrollNavigation { get; set; }
    }
}
