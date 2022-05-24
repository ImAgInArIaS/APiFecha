using System;
using System.Collections.Generic;

namespace ApiBaseDatos.Models
{
    public partial class TipoDeporte
    {
        public TipoDeporte()
        {
            Deportes = new HashSet<Deporte>();
        }

        public Guid Id { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Deporte> Deportes { get; set; }
    }
}
