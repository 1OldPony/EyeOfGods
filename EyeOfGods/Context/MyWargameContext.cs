using EyeOfGods.Context;
using EyeOfGods.Models.MapModels;
using Microsoft.EntityFrameworkCore;

namespace EyeOfGods.Models
{
    public class MyWargameContext : DbContext
    {
        SeedData seedData = new();
        public MyWargameContext()
        {
                
        }
        public MyWargameContext(DbContextOptions<MyWargameContext> options)
            : base(options)
        {
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DefensiveAbilities>().HasData(seedData.defensiveAbilities[0], seedData.defensiveAbilities[1], seedData.defensiveAbilities[2]);

            modelBuilder.Entity<EnduranceAbilities>().HasData(seedData.enduranceAbilities[0], seedData.enduranceAbilities[1]);

            modelBuilder.Entity<MentalAbilities>().HasData(seedData.mentalAbilities[0], seedData.mentalAbilities[1]);

            modelBuilder.Entity<MeleeWeapon>().HasData(seedData.meleeWeapon[0], seedData.meleeWeapon[1], seedData.meleeWeapon[2]);

            modelBuilder.Entity<RangeWeapon>().Navigation(r => r.RangeWeaponsType).AutoInclude();
            modelBuilder.Entity<RangeWeapon>().HasData(seedData.rangeWeapon[0], seedData.rangeWeapon[1], seedData.rangeWeapon[2]);

            modelBuilder.Entity<RangeWeaponsType>().HasData(seedData.rangeWeaponsType[0], seedData.rangeWeaponsType[1], seedData.rangeWeaponsType[2]);

            modelBuilder.Entity<Shield>().HasData(seedData.shield[0]);

            modelBuilder.Entity<UnitType>().Navigation(u => u.UnitTypeOrders).AutoInclude();
            modelBuilder.Entity<UnitType>().HasData(seedData.unitType[0], seedData.unitType[1]);

            modelBuilder.Entity<UnitOrder>().HasData(seedData.unitOrder[0], seedData.unitOrder[1], seedData.unitOrder[2]);

            modelBuilder.Entity<Unit>().Navigation(u => u.DefensiveAbilities).AutoInclude();
            modelBuilder.Entity<Unit>().Navigation(u => u.EnduranceAbilities).AutoInclude();
            modelBuilder.Entity<Unit>().Navigation(u => u.MeleeWeapons).AutoInclude();
            modelBuilder.Entity<Unit>().Navigation(u => u.MentalAbilities).AutoInclude();
            modelBuilder.Entity<Unit>().Navigation(u => u.RangeWeapon).AutoInclude();
            modelBuilder.Entity<Unit>().Navigation(u => u.Shield).AutoInclude();
            modelBuilder.Entity<Unit>().Navigation(u => u.UnitType).AutoInclude();




            modelBuilder.Entity<MapScheme>().OwnsMany(m => m.Points);
            
            modelBuilder.Entity<Quest>().HasData(seedData.quests[0]);

            modelBuilder.Entity<God>().HasData(seedData.gods[0], seedData.gods[1], seedData.gods[2], seedData.gods[3], seedData.gods[4]);
        }


        //public DbSet<AdditionalProperty> AdditionalProperties { get; set; }
        public virtual DbSet<DefensiveAbilities> DefensiveAbilities { get; set; }
        public virtual DbSet<EnduranceAbilities> EnduranceAbilities { get; set; }
        public virtual DbSet<MentalAbilities> MentalAbilities { get; set; }
        public virtual DbSet<MeleeWeapon> MeleeWeapons { get; set; }
        //public DbSet<Price> Prices { get; set; }
        public virtual DbSet<RangeWeapon> RangeWeapons { get; set; }
        public virtual DbSet<RangeWeaponsType> RangeWeaponsTypes { get; set; }
        public virtual DbSet<Shield> Shields { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<UnitOrder> UnitOrders { get; set; }
        public virtual DbSet<UnitType> UnitTypes { get; set; }


        public virtual DbSet<MapScheme> MapSchemes { get; set; }
        public virtual DbSet<Quest> Quests { get; set; }
        public virtual DbSet<God> Gods { get; set; }
    }
}
