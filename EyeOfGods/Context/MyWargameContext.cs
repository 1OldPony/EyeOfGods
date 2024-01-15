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
            modelBuilder.Entity<DefensiveAbilities>().HasData(seedData.defensiveAbilities);

            modelBuilder.Entity<EnduranceAbilities>().HasData(seedData.enduranceAbilities);

            modelBuilder.Entity<MentalAbilities>().HasData(seedData.mentalAbilities);

            modelBuilder.Entity<MeleeWeapon>().HasData(seedData.meleeWeapon);

            modelBuilder.Entity<RangeWeapon>().Navigation(r => r.RangeWeaponsType).AutoInclude();
            modelBuilder.Entity<RangeWeapon>().HasData(seedData.rangeWeapon);

            modelBuilder.Entity<RangeWeaponsType>().HasData(seedData.rangeWeaponsType);

            modelBuilder.Entity<Shield>().HasData(seedData.shield);

            modelBuilder.Entity<UnitType>().Navigation(u => u.UnitTypeOrders).AutoInclude();
            modelBuilder.Entity<UnitType>().HasData(seedData.unitType);

            modelBuilder.Entity<UnitOrder>().HasData(seedData.unitOrder);

            modelBuilder.Entity<Unit>().Navigation(u => u.DefensiveAbilities).AutoInclude();
            modelBuilder.Entity<Unit>().Navigation(u => u.EnduranceAbilities).AutoInclude();
            modelBuilder.Entity<Unit>().Navigation(u => u.MeleeWeapons).AutoInclude();
            modelBuilder.Entity<Unit>().Navigation(u => u.MentalAbilities).AutoInclude();
            modelBuilder.Entity<Unit>().Navigation(u => u.RangeWeapon).AutoInclude();
            modelBuilder.Entity<Unit>().Navigation(u => u.Shield).AutoInclude();
            modelBuilder.Entity<Unit>().Navigation(u => u.UnitType).AutoInclude();

            modelBuilder.Entity<MapScheme>().OwnsMany(m => m.Points);
            modelBuilder.Entity<MapScheme>().HasData(seedData.mapSchemes);

            modelBuilder.Entity<Map>().OwnsMany(m => m.Terrains);
            modelBuilder.Entity<Map>().OwnsMany(m => m.InterestPoints);
            modelBuilder.Entity<Map>().Navigation(to => to.TerrainOptions).AutoInclude();
            modelBuilder.Entity<Map>().Navigation(s => s.Scheme).AutoInclude();

            modelBuilder.Entity<Quest>().HasData(seedData.quests[0]);

            modelBuilder.Entity<God>().HasData(seedData.gods);

            modelBuilder.Entity<TerrainOptions>().HasData(seedData.terrOptions);

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
        public virtual DbSet<TerrainOptions> TerrainOptions { get; set; }
        public virtual DbSet<Map> Maps { get; set; }
    }
}
