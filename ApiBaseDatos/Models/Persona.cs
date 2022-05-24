using System;
using System.Collections.Generic;

namespace ApiBaseDatos.Models
{
    public partial class Persona
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Dni { get; set; } = null!;
        public Guid IDsexo { get; set; }
        public string Calle { get; set; } = null!;
        public string Numero { get; set; } = null!;

        public virtual Sexo IDsexoNavigation { get; set; } = null!;
    }
}
