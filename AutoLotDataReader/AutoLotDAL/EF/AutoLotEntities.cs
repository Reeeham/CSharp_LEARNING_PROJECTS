namespace AutoLotDAL.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using AutoLotDAL.Models;
    using System.Data.Entity.Infrastructure.Interception;
    using AutoLotDAL.Interception;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;

    public partial class AutoLotEntities : DbContext
    {
        static readonly DatabaseLogger DatabaseLogger = new DatabaseLogger("sqllog.txt", true);
        public AutoLotEntities()
            : base("name=AutoLotConnection")
        {
            //DbInterception.Add(new ConsoleWriterInterceptor());
            DatabaseLogger.StartLogging();
            DbInterception.Add(DatabaseLogger);
            //Interceptor code
            var context = (this as IObjectContextAdapter).ObjectContext;
            context.ObjectMaterialized += OnObjectMaterialized;
            context.SavingChanges += OnSavingChanges;
        }
        private void OnSavingChanges(object sender, EventArgs eventArgs)
        {
            //Sender is of type ObjectContext. Can get current and original values, and
            //cancel/modify the save operation as desired.
            var context = sender as ObjectContext;
            if (context == null) return;
            foreach (ObjectStateEntry item in
            context.ObjectStateManager.GetObjectStateEntries(
            EntityState.Modified | EntityState.Added))
            {
                //Do something important here
                if ((item.Entity as Inventory) != null)
                {
                    var entity = (Inventory)item.Entity;
                    if (entity.Color == "Red")
                    {
                        item.RejectPropertyChanges(nameof(entity.Color));
                    }
                }
            }
        }
        private void OnObjectMaterialized(object sender,
        System.Data.Entity.Core.Objects.ObjectMaterializedEventArgs e)
        {
        }
        public virtual DbSet<CreditRisk> CreditRisks { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //OnModelCreating() to use FluentAPI to define the relationships between the Orders and Inventory tables.
                modelBuilder.Entity<Inventory>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Car)
                .WillCascadeOnDelete(true);
        }
        protected override void Dispose(bool disposing)
        {
            DbInterception.Remove(DatabaseLogger);
            DatabaseLogger.StopLogging();
            base.Dispose(disposing);
        }

    }
}
