namespace Practico1Definitivo.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Copias
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Copias()
        {
            Alquileres = new HashSet<Alquileres>();
        }

        public long Id { get; set; }

        public long IdPelicula { get; set; }

        public bool Deteriorada { get; set; }

        [Required]
        [StringLength(15)]
        public string Formato { get; set; }

        public double PrecioAlquiler { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alquileres> Alquileres { get; set; }

        public virtual Peliculas Peliculas { get; set; }
    }
}
