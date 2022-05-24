using System;
using System.Collections.Generic;

namespace ApiBaseDatos.Models
{
    public partial class Sexo
    {
        public Sexo()
        {
            Personas = new HashSet<Persona>();
        }

        public Guid Id { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Persona> Personas { get; set; }
    }
}
