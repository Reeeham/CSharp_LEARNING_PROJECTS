namespace AutoLotDAL.Models
{
    using AutoLotDAL.Models.Base;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Inventory")]
    public partial class Inventory: EntityBase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Inventory()
        {
            Orders = new HashSet<Order>();
        }

        
        public int CarId { get; set; }

        [StringLength(50, ErrorMessage = "Please enter a value less than 50 characters long.")]
        public string Make { get; set; }

        [StringLength(50)]
        public string Color { get; set; }

        [StringLength(50)]
        public string PetName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        //This doesn’t change anything in how the code works; it just takes advantage of new C# features to clean up the code.
    }
}
