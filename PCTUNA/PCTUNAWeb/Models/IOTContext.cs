namespace PCTUNAWeb.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class IOTContext : DbContext
    {
        public IOTContext()
            : base("name=IOTContext")
        {
        }

        public virtual DbSet<Carrier> Carriers { get; set; }
        public virtual DbSet<CarrierRFID> CarrierRFIDs { get; set; }
        public virtual DbSet<CarrierType> CarrierTypes { get; set; }
        public virtual DbSet<ControlValue> ControlValues { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmpRFID> EmpRFIDs { get; set; }
        public virtual DbSet<Lot> Lots { get; set; }
        public virtual DbSet<Operation> Operations { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Process> Processes { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<RFID> RFIDs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<WorkFlow> WorkFlows { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carrier>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<CarrierRFID>()
                .Property(e => e.RFID)
                .IsUnicode(false);

            modelBuilder.Entity<CarrierType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.No)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<EmpRFID>()
                .Property(e => e.RFID)
                .IsUnicode(false);

            modelBuilder.Entity<Operation>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Position>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Process>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Recipe>()
                .HasMany(e => e.WorkFlows)
                .WithOptional(e => e.Recipe)
                .HasForeignKey(e => e.RecipeID);

            modelBuilder.Entity<Recipe>()
                .HasMany(e => e.WorkFlows1)
                .WithOptional(e => e.Recipe1)
                .HasForeignKey(e => e.NextRecipeID);

            modelBuilder.Entity<RFID>()
                .Property(e => e.RFID1)
                .IsUnicode(false);

            modelBuilder.Entity<RFID>()
                .Property(e => e.Type)
                .IsUnicode(false);
        }
    }
}
