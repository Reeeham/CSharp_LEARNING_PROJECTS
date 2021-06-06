using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using AutoLotDAL_Core2.Models;

namespace AutoLotDAL_Core2.EF
{
    public class AutoLotContext : DbContext
    {
        public DbSet<CreditRisk> CreditRisks { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Inventory> Cars { get; set; }
        public DbSet<Order> Orders { get; set; }

        public AutoLotContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var ConnectionString = @"Server=.;database = AutoLotCore2; Integrated Security = true;
                                          MultipleActiveResultSets=true;App=EntityFramework";
                //Enabling connection resiliency sets EF to automatically retry database operations if certain transient errors occur.
                //These retry attempts happen a certain amount of times, with a set delay between each retry
                optionsBuilder.UseSqlServer(ConnectionString, options => options.EnableRetryOnFailure())
                        .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));
                // the best you can do is throw an exceeption when mixed-mode evaluation occurs.
                //example Guid g = Guid.Parse(guid);
                //return Table.FirstOrDefault(x=> x.Guid == g) a7wlha l awal w b3d keda compare because linq statment into
                //sql statment doesn't understand TheGuid.ToString()
                //stay away from mixed-mode evaluation unless you've a strong need to it

            }
        }

        // public paramteless  constructor prevents using DbContext pooling so you need to add a class that implements
        //IDesignTimeDbContextFactory<TContext> this interface has one method Create DbConetxt() 
        // if the ef migrations engine finds an instance of this interface in the same assemmbly as the context being used
        //it will use the createdbcontext() method to create the context and not the public constructor 
            internal AutoLotContext()
            {

            }

        /* using the Fluent APi is another way to shape the models and the resulting database tables and columns
         * there's less support for data annotations in ef core than ef6 you must use the fluent api to create multicolumn indices 
         */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //create the multi column unique index
            modelBuilder.Entity<CreditRisk>(entity =>
            {
                entity.HasIndex(e => new { e.FirstName, e.LastName }).IsUnique();
            });
            //creates the onetomany relationship be the order and inventory table
            // and then set the cascade option to no action( the default)
            modelBuilder.Entity<Order>()
            .HasOne(e => e.Car)
            .WithMany(e => e.orders)
            .OnDelete(DeleteBehavior.ClientSetNull);
        }
        //this will return the sql server table name for dbset<T> this is needed because the class and
        //table names don't have to match, youill need the sql server table name in the data intiialization code
        public string GetTableName(Type type)
        {
            return Model.FindEntityType(type).SqlServer().TableName;
        }

        /*Creating the database with migrations ef6 migratons creates a hash of the db definition
         * and stored that in the migration table in the db, if two developers made changes
         * there wasn't any way to consolidate the changes since hashes are one way ,Ef core removed
         * the hash from the process all that's stored in the db is the name of the migration and the ef version number
         * the db definition is stored in a c# file named <Contextname>ModelSnapshot.cs 
         * then the developer can use a standard diff tool to workout any conflicting changes ,
         * migrations can be run using (add-migration,update-database,etc) or using the .net cli
         * the .net core ci can be run from any commandline not package manager console
         * you need to be in the same dir as the project file that defines the .net core cli command options 
         * open cmd and nav to that dir that contains the project file you can run it also from package manager console 
         * dotnet ef migrations -h , yo add the migrations to create the your db make sure to save all the files
         * dotnet ef migrations add Initial --context AutoLot_Core2.EF.AutoLotContext -o EF/Migrations
         * the migration will be named initial using th qualified autolotcontext and will place the resulting
         * migrations in the EF/Migrations directory similar to EF6 migr. that are used to update the db and creates the
         * AutoLotContextModelSnapshot.cs file which stores the complete db model 
         * to apply this migration simply dotnet ef database update
         */
    }
    }

    

