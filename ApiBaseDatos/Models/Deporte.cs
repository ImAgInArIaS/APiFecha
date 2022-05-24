using System;
using System.Collections.Generic;

namespace ApiBaseDatos.Models
{
    public partial class Deporte
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = null!;
        public Guid IDtipoDeporte { get; set; }
        public string Descripcion { get; set; } = null!;

        public virtual TipoDeporte IDtipoDeporteNavigation { get; set; } = null!;
    }
}
