namespace Practico1Definitivo.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Peliculas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Peliculas()
        {
            Copias = new HashSet<Copias>();
        }

        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Titulo { get; set; }

        public int Anio { get; set; }

        public int Calificacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Copias> Copias { get; set; }
    }
}
