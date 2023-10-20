using EyeOfGods.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EyeOfGods.Models
{
    public class MyWargameContext : DbContext
    {
        public MyWargameContext()
        {
                
        }
        public MyWargameContext(DbContextOptions<MyWargameContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DefensiveAbilities>().HasData(
                new DefensiveAbilities { Id = 1, CharacteristicName = "Броня", MinValue = 3, MaxValue = 6, NoDoubleActionAt = 5, Step = 1, BlocksArmorPierce = false},
                new DefensiveAbilities { Id = 2, CharacteristicName = "Материальность", MinValue = 3, MaxValue = 6, NoDoubleActionAt = 7, Step = 1, BlocksArmorPierce = true },
                new DefensiveAbilities { Id = 3, CharacteristicName = "Шкура", MinValue = 3, MaxValue = 5, NoDoubleActionAt = 5, Step = 1, BlocksArmorPierce = false }
                );
            modelBuilder.Entity<EnduranceAbilities>().HasData(
                new EnduranceAbilities { Id = 1, CharacteristicName = "Выносливость", MinValue = 4, MaxValue = 16, Step = 2 },
                new EnduranceAbilities { Id = 2, CharacteristicName = "Целостность", MinValue = 4, MaxValue = 16, Step = 2 }
                );
            modelBuilder.Entity<MentalAbilities>().HasData(
                new MentalAbilities { Id = 1, CharacteristicName = "Отвага", MinValue = 2, MaxValue = 6, Step = 2 },
                new MentalAbilities { Id = 2, CharacteristicName = "Ярость", MinValue = 1, MaxValue = 3, Step = 1 }
                );
            modelBuilder.Entity<MeleeWeapon>().HasData(
                new MeleeWeapon { Id = 1, MWName = "Меч", WeaponType = MeleeWeaponTypes.Одноручное},
                new MeleeWeapon { Id = 2, MWName = "Пика", WeaponType = MeleeWeaponTypes.Пика },
                new MeleeWeapon { Id = 3, MWName = "Алебарда", WeaponType = MeleeWeaponTypes.Алебарда }
                );
            modelBuilder.Entity<RangeWeapon>().Navigation(r => r.RangeWeaponsType).AutoInclude();
            modelBuilder.Entity<RangeWeapon>().HasData(
                new RangeWeapon { Id = 1, RWName = "Лук", RangeOfShooting = 12/*, RangeWeaponsType = new() { RWTypeId = 1 } *//*, RangeWeaponsType = RangeWeaponsTypes.ElementAt(0)*/ },
                new RangeWeapon { Id = 2, RWName = "Аркебуза", RangeOfShooting = 18/*, RangeWeaponsType = new() { RWTypeId = 2 }*//*, RangeWeaponsType = RangeWeaponsTypes.ElementAt(1) */},
                new RangeWeapon { Id = 3, RWName = "Пухандрий", RangeOfShooting = 18/*, RangeWeaponsType = new() { RWTypeId = 3 }*//*, RangeWeaponsType = RangeWeaponsTypes.ElementAt(2)*/ }
                );
            modelBuilder.Entity<RangeWeaponsType>().HasData(
                new RangeWeaponsType{Id = 1,RWTypeName = "Легкое стрелковое вооружение",MinDistance = 8,MaxDistance = 14,DistanceStep = 2,
                    FirstRWTypeProperty = "Стреляет без лоса",SecondRWTypeProperty = ""},
                new RangeWeaponsType{Id = 2,RWTypeName = "Тяжелое стрелковое вооружение",MinDistance = 14,MaxDistance = 20,DistanceStep = 2,
                    FirstRWTypeProperty = "-2 к броне",SecondRWTypeProperty = "Только прямая стрельба"},
                new RangeWeaponsType{Id = 3,RWTypeName = "Артиллерийское вооружение",MinDistance = 24,MaxDistance = 30,DistanceStep = 2,
                    FirstRWTypeProperty = "Всегда 4+",SecondRWTypeProperty = "Каждый успех-усталость"}
                );
            modelBuilder.Entity<Shield>().HasData(
                new Shield { Id=1, ShieldName = "Баклер"}
                );
            modelBuilder.Entity<UnitType>().Navigation(uT => uT.UnitTypeOrders).AutoInclude();
            modelBuilder.Entity<UnitType>().HasData(
                new UnitType { Id = 1, UnitTypeName = "Пехота", BarricadeAssault="+2", BarricadeForcedMove="3", BarricadeGoThrough="2",
                 CliffAssault="+2", CliffForcedMove="4", CliffGoThrough="2", ForestAssault="0", ForestForcedMove="1", ForestGoThrough="0",
                 SettelmentAssault="0", SettelmentForcedMove="2", SettelmentGoThrough="0", SwampAssault="0", SwampForcedMove="1", SwampGoThrough="0",
                 WaterAssault="+2", WaterForcedMove="3", WaterGoThrough="2", MinSpeed = 4, MaxSpeed = 8/*, UnitTypeOrders = new() { new() { Id = 3  } }*//*, UnitTypeOrders = { UnitOrders.ElementAt(2) }*/ },
                new UnitType { Id = 2, UnitTypeName = "Кавалерия", BarricadeAssault="+2", BarricadeForcedMove="3", BarricadeGoThrough="2",
                 CliffAssault="Х", CliffForcedMove="6", CliffGoThrough="Х", ForestAssault="+2", ForestForcedMove="3", ForestGoThrough="2",
                 SettelmentAssault="0", SettelmentForcedMove="2", SettelmentGoThrough="0", SwampAssault="+2", SwampForcedMove="3", SwampGoThrough="2",
                 WaterAssault="+2", WaterForcedMove="3", WaterGoThrough="1", MinSpeed = 8, MaxSpeed = 14/*, UnitTypeOrders = new() { new() { Id = 1  }, new() { Id = 2 } }*//*, UnitTypeOrders = { UnitOrders.ElementAt(0), UnitOrders.ElementAt(1) }*/ }
                );
            modelBuilder.Entity<UnitOrder>().HasData(
                new UnitOrder { Id = 1, OrderName = "Прорыв", OrderType = "Атака", OrderDescrption = "Совершите обычное движение от любой точки побежденного отряда",
                    SituationBonus = "Если в эту фазу активаций отряд проводил чардж - отнимите 2 от брони противника", DoubleWeaponsBonus = "+4 к боеспособности",
                    GreatWeaponBonus = "-1 к броне противника", HalberdBonus = "-1 к броне противника", OneHandBonus = "+2 к боеспособности", PikeBonus = "0", 
                    SpearBonus = "0"},
                new UnitOrder { Id = 2, OrderName = "Наскок", OrderType = "Атака", OrderDescrption = "Отойдите на 4\" от побежденного отряда",
                    SituationBonus = "Если в эту фазу активаций отряд проводил чардж - добавьте 1 к своей броне", DoubleWeaponsBonus = "0", 
                    GreatWeaponBonus = "-1 к броне противника", HalberdBonus = "+2 к боеспособности", OneHandBonus = "0",PikeBonus = "+4 к боеспособности",
                    SpearBonus = "+2 к боеспособности"
                },
                new UnitOrder { Id = 3, OrderName = "Отступление", OrderType = "Оборона", OrderDescrption = "+2 брони каждому отряду, после этого отступающий отступает на свое движение. Противник может преследовать",
                    SituationBonus = "Если ваша скорость выше, чем у противника - добавьте 1 к своей броне", DoubleWeaponsBonus = "0", GreatWeaponBonus = "-1 к броне противника",
                    HalberdBonus = "0", OneHandBonus = "0", PikeBonus = "0", SpearBonus = "0" }
                );
            modelBuilder.Entity<Unit>().Navigation(u => u.DefensiveAbilities).AutoInclude();
            modelBuilder.Entity<Unit>().Navigation(u => u.EnduranceAbilities).AutoInclude();
            modelBuilder.Entity<Unit>().Navigation(u => u.MeleeWeapons).AutoInclude();
            modelBuilder.Entity<Unit>().Navigation(u => u.MentalAbilities).AutoInclude();
            modelBuilder.Entity<Unit>().Navigation(u => u.RangeWeapon).AutoInclude();
            modelBuilder.Entity<Unit>().Navigation(u => u.Shield).AutoInclude();
            modelBuilder.Entity<Unit>().Navigation(u => u.UnitType).AutoInclude();
            //modelBuilder.Entity<Unit>().HasData(
            //    new Unit
            //    {
            //        Id = 1,
            //        DefensiveAbilities = DefensiveAbilities.ElementAt(0),
            //        EnduranceAbilities = EnduranceAbilities.ElementAt(0),
            //        MentalAbilities = MentalAbilities.ElementAt(1),
            //        MeleeWeapons = { MeleeWeapons.ElementAt(2) },
            //        UnitType = UnitTypes.ElementAt(0),
            //        UnitName = "Test_Halberdier_NoShield_NoRange_NoFuture",
            //        Speed = 8,
            //        Defense = 4,
            //        Endurance = 8,
            //        Mental = 2
            //    }
            //);
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
    }
}
