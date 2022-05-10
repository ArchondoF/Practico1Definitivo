namespace Practico1Definitivo.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Alquileres
    {
        public long Id { get; set; }

        public long IdCopia { get; set; }

        public long IdCliente { get; set; }

        public DateTime FechaAlquiler { get; set; }

        public DateTime FechaTope { get; set; }

        public DateTime? FechaEntregada { get; set; }

        public virtual Clientes Clientes { get; set; }

        public virtual Copias Copias { get; set; }
    }
}
