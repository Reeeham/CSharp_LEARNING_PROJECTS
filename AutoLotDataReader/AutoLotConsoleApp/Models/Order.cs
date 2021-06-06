namespace AutoLotConsoleApp.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        public int OrderId { get; set; }

        public int CustId { get; set; }

        [Column("CarId")]
        public int Foo { get; set; }

        [ForeignKey(nameof(Foo))]
        public int CarId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Car Car { get; set; }
    }
}
