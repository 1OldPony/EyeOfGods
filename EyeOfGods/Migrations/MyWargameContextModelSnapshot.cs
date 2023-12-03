﻿// <auto-generated />
using System;
using EyeOfGods.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EyeOfGods.Migrations
{
    [DbContext(typeof(MyWargameContext))]
    partial class MyWargameContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EyeOfGods.Models.DefensiveAbilities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("BlocksArmorPierce")
                        .HasColumnType("bit");

                    b.Property<string>("CharacteristicName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DefenseAddProperty")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxValue")
                        .HasColumnType("int");

                    b.Property<int>("MinValue")
                        .HasColumnType("int");

                    b.Property<int>("NoDoubleActionAt")
                        .HasColumnType("int");

                    b.Property<int>("Step")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DefensiveAbilities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BlocksArmorPierce = false,
                            CharacteristicName = "Броня",
                            DefenseAddProperty = "Дополнительное свойство",
                            MaxValue = 6,
                            MinValue = 3,
                            NoDoubleActionAt = 5,
                            Step = 1
                        },
                        new
                        {
                            Id = 2,
                            BlocksArmorPierce = true,
                            CharacteristicName = "Материальность",
                            DefenseAddProperty = "Дополнительное свойство",
                            MaxValue = 6,
                            MinValue = 3,
                            NoDoubleActionAt = 7,
                            Step = 1
                        },
                        new
                        {
                            Id = 3,
                            BlocksArmorPierce = false,
                            CharacteristicName = "Шкура",
                            DefenseAddProperty = "Дополнительное свойство",
                            MaxValue = 5,
                            MinValue = 3,
                            NoDoubleActionAt = 5,
                            Step = 1
                        });
                });

            modelBuilder.Entity("EyeOfGods.Models.EnduranceAbilities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CharacteristicName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DurabilityAddProperty")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxValue")
                        .HasColumnType("int");

                    b.Property<int>("MinValue")
                        .HasColumnType("int");

                    b.Property<int>("Step")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("EnduranceAbilities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CharacteristicName = "Выносливость",
                            DurabilityAddProperty = "Дополнительное свойство",
                            MaxValue = 16,
                            MinValue = 4,
                            Step = 2
                        },
                        new
                        {
                            Id = 2,
                            CharacteristicName = "Целостность",
                            DurabilityAddProperty = "Дополнительное свойство",
                            MaxValue = 16,
                            MinValue = 4,
                            Step = 2
                        });
                });

            modelBuilder.Entity("EyeOfGods.Models.MapModels.God", b =>
                {
                    b.Property<string>("GodName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FighterAbilityDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MageAbilityDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UltimateAbilityDesc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GodName");

                    b.ToTable("Gods");

                    b.HasData(
                        new
                        {
                            GodName = "Доблесть"
                        },
                        new
                        {
                            GodName = "Время"
                        },
                        new
                        {
                            GodName = "Знания"
                        },
                        new
                        {
                            GodName = "Справедливость"
                        },
                        new
                        {
                            GodName = "Шутник"
                        });
                });

            modelBuilder.Entity("EyeOfGods.Models.MapModels.InterestPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MapId")
                        .HasColumnType("int");

                    b.Property<int?>("PareWhithPoint")
                        .HasColumnType("int");

                    b.Property<int>("PointHeight")
                        .HasColumnType("int");

                    b.Property<int>("PointNumber")
                        .HasColumnType("int");

                    b.Property<int>("PointWidth")
                        .HasColumnType("int");

                    b.Property<int?>("QuestId")
                        .HasColumnType("int");

                    b.Property<int?>("ReferenceTo")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("XCoordinate")
                        .HasColumnType("int");

                    b.Property<int>("YCoordinate")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MapId");

                    b.HasIndex("QuestId");

                    b.ToTable("InterestPoint");
                });

            modelBuilder.Entity("EyeOfGods.Models.MapModels.Map", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("SchemeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SchemeId");

                    b.ToTable("Map");
                });

            modelBuilder.Entity("EyeOfGods.Models.MapModels.MapScheme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GodPresense")
                        .HasColumnType("int");

                    b.Property<int>("MapHeight")
                        .HasColumnType("int");

                    b.Property<int>("MapWidth")
                        .HasColumnType("int");

                    b.Property<int>("MaxDensityAvail")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumbOfCities")
                        .HasColumnType("int");

                    b.Property<int>("NumbOfResources")
                        .HasColumnType("int");

                    b.Property<int>("NumbOfTreasuries")
                        .HasColumnType("int");

                    b.Property<int>("QuestLevel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MapSchemes");
                });

            modelBuilder.Entity("EyeOfGods.Models.MapModels.Quest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConsDraw")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConsLoose")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConsWin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Quests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConsDraw = "Ничего не нашлось",
                            ConsLoose = "Ничего не нашлось, получите 1 усталость",
                            ConsWin = "Получите артефакт Х",
                            Description = "Найден старый склеп. Получите >2 успехов выносливости чтоб порыться в нем.",
                            Level = 0,
                            Name = "Low quest"
                        });
                });

            modelBuilder.Entity("EyeOfGods.Models.MapModels.Terrain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("GodFrendly")
                        .HasColumnType("bit");

                    b.Property<bool>("HasGodToken")
                        .HasColumnType("bit");

                    b.Property<int?>("MapId")
                        .HasColumnType("int");

                    b.Property<int?>("PareWhithPoint")
                        .HasColumnType("int");

                    b.Property<int>("PointHeight")
                        .HasColumnType("int");

                    b.Property<int>("PointNumber")
                        .HasColumnType("int");

                    b.Property<int>("PointWidth")
                        .HasColumnType("int");

                    b.Property<int?>("ReferenceTo")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("XCoordinate")
                        .HasColumnType("int");

                    b.Property<int>("YCoordinate")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MapId");

                    b.ToTable("Terrain");
                });

            modelBuilder.Entity("EyeOfGods.Models.MeleeWeapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("MWName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WeaponType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MeleeWeapons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MWName = "Меч",
                            WeaponType = 2
                        },
                        new
                        {
                            Id = 2,
                            MWName = "Пика",
                            WeaponType = 1
                        },
                        new
                        {
                            Id = 3,
                            MWName = "Алебарда",
                            WeaponType = 5
                        });
                });

            modelBuilder.Entity("EyeOfGods.Models.MentalAbilities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CharacteristicName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxValue")
                        .HasColumnType("int");

                    b.Property<int>("MinValue")
                        .HasColumnType("int");

                    b.Property<string>("SpiritAddProperty")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Step")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MentalAbilities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CharacteristicName = "Отвага",
                            MaxValue = 6,
                            MinValue = 2,
                            SpiritAddProperty = "Дополнительное свойство",
                            Step = 2
                        },
                        new
                        {
                            Id = 2,
                            CharacteristicName = "Ярость",
                            MaxValue = 3,
                            MinValue = 1,
                            SpiritAddProperty = "Дополнительное свойство",
                            Step = 1
                        });
                });

            modelBuilder.Entity("EyeOfGods.Models.RangeWeapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RWName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RangeOfShooting")
                        .HasColumnType("int");

                    b.Property<int?>("RangeWeaponsTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RangeWeaponsTypeId");

                    b.ToTable("RangeWeapons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RWName = "Лук",
                            RangeOfShooting = 12
                        },
                        new
                        {
                            Id = 2,
                            RWName = "Аркебуза",
                            RangeOfShooting = 18
                        },
                        new
                        {
                            Id = 3,
                            RWName = "Пухандрий",
                            RangeOfShooting = 18
                        });
                });

            modelBuilder.Entity("EyeOfGods.Models.RangeWeaponsType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DistanceStep")
                        .HasColumnType("int");

                    b.Property<string>("FirstRWTypeProperty")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxDistance")
                        .HasColumnType("int");

                    b.Property<int>("MinDistance")
                        .HasColumnType("int");

                    b.Property<string>("RWTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondRWTypeProperty")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RangeWeaponsTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DistanceStep = 2,
                            FirstRWTypeProperty = "Стреляет без лоса",
                            MaxDistance = 14,
                            MinDistance = 8,
                            RWTypeName = "Легкое стрелковое вооружение",
                            SecondRWTypeProperty = ""
                        },
                        new
                        {
                            Id = 2,
                            DistanceStep = 2,
                            FirstRWTypeProperty = "-2 к броне",
                            MaxDistance = 20,
                            MinDistance = 14,
                            RWTypeName = "Тяжелое стрелковое вооружение",
                            SecondRWTypeProperty = "Только прямая стрельба"
                        },
                        new
                        {
                            Id = 3,
                            DistanceStep = 2,
                            FirstRWTypeProperty = "Всегда 4+",
                            MaxDistance = 30,
                            MinDistance = 24,
                            RWTypeName = "Артиллерийское вооружение",
                            SecondRWTypeProperty = "Каждый успех-усталость"
                        });
                });

            modelBuilder.Entity("EyeOfGods.Models.Shield", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ShieldName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Shields");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ShieldName = "Баклер"
                        });
                });

            modelBuilder.Entity("EyeOfGods.Models.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Defense")
                        .HasColumnType("int");

                    b.Property<int?>("DefensiveAbilitiesId")
                        .HasColumnType("int");

                    b.Property<int>("Endurance")
                        .HasColumnType("int");

                    b.Property<int?>("EnduranceAbilitiesId")
                        .HasColumnType("int");

                    b.Property<int>("Mental")
                        .HasColumnType("int");

                    b.Property<int?>("MentalAbilitiesId")
                        .HasColumnType("int");

                    b.Property<int?>("RangeWeaponId")
                        .HasColumnType("int");

                    b.Property<int?>("ShieldId")
                        .HasColumnType("int");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.Property<string>("UnitName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UnitTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DefensiveAbilitiesId");

                    b.HasIndex("EnduranceAbilitiesId");

                    b.HasIndex("MentalAbilitiesId");

                    b.HasIndex("RangeWeaponId");

                    b.HasIndex("ShieldId");

                    b.HasIndex("UnitTypeId");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("EyeOfGods.Models.UnitOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DoubleWeaponsBonus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GreatWeaponBonus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HalberdBonus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OneHandBonus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderDescrption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PikeBonus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SituationBonus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpearBonus")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UnitOrders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DoubleWeaponsBonus = "+4 к боеспособности",
                            GreatWeaponBonus = "-1 к броне противника",
                            HalberdBonus = "-1 к броне противника",
                            OneHandBonus = "+2 к боеспособности",
                            OrderDescrption = "Совершите обычное движение от любой точки побежденного отряда",
                            OrderName = "Прорыв",
                            OrderType = "Атака",
                            PikeBonus = "0",
                            SituationBonus = "Если в эту фазу активаций отряд проводил чардж - отнимите 2 от брони противника",
                            SpearBonus = "0"
                        },
                        new
                        {
                            Id = 2,
                            DoubleWeaponsBonus = "0",
                            GreatWeaponBonus = "-1 к броне противника",
                            HalberdBonus = "+2 к боеспособности",
                            OneHandBonus = "0",
                            OrderDescrption = "Отойдите на 4\" от побежденного отряда",
                            OrderName = "Наскок",
                            OrderType = "Атака",
                            PikeBonus = "+4 к боеспособности",
                            SituationBonus = "Если в эту фазу активаций отряд проводил чардж - добавьте 1 к своей броне",
                            SpearBonus = "+2 к боеспособности"
                        },
                        new
                        {
                            Id = 3,
                            DoubleWeaponsBonus = "0",
                            GreatWeaponBonus = "-1 к броне противника",
                            HalberdBonus = "0",
                            OneHandBonus = "0",
                            OrderDescrption = "+2 брони каждому отряду, после этого отступающий отступает на свое движение. Противник может преследовать",
                            OrderName = "Отступление",
                            OrderType = "Оборона",
                            PikeBonus = "0",
                            SituationBonus = "Если ваша скорость выше, чем у противника - добавьте 1 к своей броне",
                            SpearBonus = "0"
                        });
                });

            modelBuilder.Entity("EyeOfGods.Models.UnitType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BarricadeAssault")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BarricadeForcedMove")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BarricadeGoThrough")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CliffAssault")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CliffForcedMove")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CliffGoThrough")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ForestAssault")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ForestForcedMove")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ForestGoThrough")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxSpeed")
                        .HasColumnType("int");

                    b.Property<int>("MinSpeed")
                        .HasColumnType("int");

                    b.Property<string>("SettelmentAssault")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SettelmentForcedMove")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SettelmentGoThrough")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SwampAssault")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SwampForcedMove")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SwampGoThrough")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnitTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WaterAssault")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WaterForcedMove")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WaterGoThrough")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UnitTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BarricadeAssault = "+2",
                            BarricadeForcedMove = "3",
                            BarricadeGoThrough = "2",
                            CliffAssault = "+2",
                            CliffForcedMove = "4",
                            CliffGoThrough = "2",
                            ForestAssault = "0",
                            ForestForcedMove = "1",
                            ForestGoThrough = "0",
                            MaxSpeed = 8,
                            MinSpeed = 4,
                            SettelmentAssault = "0",
                            SettelmentForcedMove = "2",
                            SettelmentGoThrough = "0",
                            SwampAssault = "0",
                            SwampForcedMove = "1",
                            SwampGoThrough = "0",
                            UnitTypeName = "Пехота",
                            WaterAssault = "+2",
                            WaterForcedMove = "3",
                            WaterGoThrough = "2"
                        },
                        new
                        {
                            Id = 2,
                            BarricadeAssault = "+2",
                            BarricadeForcedMove = "3",
                            BarricadeGoThrough = "2",
                            CliffAssault = "Х",
                            CliffForcedMove = "6",
                            CliffGoThrough = "Х",
                            ForestAssault = "+2",
                            ForestForcedMove = "3",
                            ForestGoThrough = "2",
                            MaxSpeed = 14,
                            MinSpeed = 8,
                            SettelmentAssault = "0",
                            SettelmentForcedMove = "2",
                            SettelmentGoThrough = "0",
                            SwampAssault = "+2",
                            SwampForcedMove = "3",
                            SwampGoThrough = "2",
                            UnitTypeName = "Кавалерия",
                            WaterAssault = "+2",
                            WaterForcedMove = "3",
                            WaterGoThrough = "1"
                        });
                });

            modelBuilder.Entity("MeleeWeaponUnit", b =>
                {
                    b.Property<int>("MeleeWeaponsId")
                        .HasColumnType("int");

                    b.Property<int>("UnitsId")
                        .HasColumnType("int");

                    b.HasKey("MeleeWeaponsId", "UnitsId");

                    b.HasIndex("UnitsId");

                    b.ToTable("MeleeWeaponUnit");
                });

            modelBuilder.Entity("UnitOrderUnitType", b =>
                {
                    b.Property<int>("UnitTypeOrdersId")
                        .HasColumnType("int");

                    b.Property<int>("UnitTypesId")
                        .HasColumnType("int");

                    b.HasKey("UnitTypeOrdersId", "UnitTypesId");

                    b.HasIndex("UnitTypesId");

                    b.ToTable("UnitOrderUnitType");
                });

            modelBuilder.Entity("EyeOfGods.Models.MapModels.InterestPoint", b =>
                {
                    b.HasOne("EyeOfGods.Models.MapModels.Map", null)
                        .WithMany("InterestPoints")
                        .HasForeignKey("MapId");

                    b.HasOne("EyeOfGods.Models.MapModels.Quest", "Quest")
                        .WithMany()
                        .HasForeignKey("QuestId");

                    b.Navigation("Quest");
                });

            modelBuilder.Entity("EyeOfGods.Models.MapModels.Map", b =>
                {
                    b.HasOne("EyeOfGods.Models.MapModels.MapScheme", "Scheme")
                        .WithMany("Maps")
                        .HasForeignKey("SchemeId");

                    b.Navigation("Scheme");
                });

            modelBuilder.Entity("EyeOfGods.Models.MapModels.MapScheme", b =>
                {
                    b.OwnsMany("EyeOfGods.Models.MapModels.MapSchemePoint", "Points", b1 =>
                        {
                            b1.Property<int>("MapSchemeId")
                                .HasColumnType("int");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<int?>("PareWhithPoint")
                                .HasColumnType("int");

                            b1.Property<int>("PointHeight")
                                .HasColumnType("int");

                            b1.Property<int>("PointNumber")
                                .HasColumnType("int");

                            b1.Property<int>("PointWidth")
                                .HasColumnType("int");

                            b1.Property<int?>("ReferenceTo")
                                .HasColumnType("int");

                            b1.Property<int>("XCoordinate")
                                .HasColumnType("int");

                            b1.Property<int>("YCoordinate")
                                .HasColumnType("int");

                            b1.HasKey("MapSchemeId", "Id");

                            b1.ToTable("MapSchemePoint");

                            b1.WithOwner()
                                .HasForeignKey("MapSchemeId");
                        });

                    b.Navigation("Points");
                });

            modelBuilder.Entity("EyeOfGods.Models.MapModels.Terrain", b =>
                {
                    b.HasOne("EyeOfGods.Models.MapModels.Map", null)
                        .WithMany("Terrains")
                        .HasForeignKey("MapId");
                });

            modelBuilder.Entity("EyeOfGods.Models.RangeWeapon", b =>
                {
                    b.HasOne("EyeOfGods.Models.RangeWeaponsType", "RangeWeaponsType")
                        .WithMany("RangeWeapons")
                        .HasForeignKey("RangeWeaponsTypeId");

                    b.Navigation("RangeWeaponsType");
                });

            modelBuilder.Entity("EyeOfGods.Models.Unit", b =>
                {
                    b.HasOne("EyeOfGods.Models.DefensiveAbilities", "DefensiveAbilities")
                        .WithMany()
                        .HasForeignKey("DefensiveAbilitiesId");

                    b.HasOne("EyeOfGods.Models.EnduranceAbilities", "EnduranceAbilities")
                        .WithMany()
                        .HasForeignKey("EnduranceAbilitiesId");

                    b.HasOne("EyeOfGods.Models.MentalAbilities", "MentalAbilities")
                        .WithMany()
                        .HasForeignKey("MentalAbilitiesId");

                    b.HasOne("EyeOfGods.Models.RangeWeapon", "RangeWeapon")
                        .WithMany()
                        .HasForeignKey("RangeWeaponId");

                    b.HasOne("EyeOfGods.Models.Shield", "Shield")
                        .WithMany()
                        .HasForeignKey("ShieldId");

                    b.HasOne("EyeOfGods.Models.UnitType", "UnitType")
                        .WithMany()
                        .HasForeignKey("UnitTypeId");

                    b.Navigation("DefensiveAbilities");

                    b.Navigation("EnduranceAbilities");

                    b.Navigation("MentalAbilities");

                    b.Navigation("RangeWeapon");

                    b.Navigation("Shield");

                    b.Navigation("UnitType");
                });

            modelBuilder.Entity("MeleeWeaponUnit", b =>
                {
                    b.HasOne("EyeOfGods.Models.MeleeWeapon", null)
                        .WithMany()
                        .HasForeignKey("MeleeWeaponsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EyeOfGods.Models.Unit", null)
                        .WithMany()
                        .HasForeignKey("UnitsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UnitOrderUnitType", b =>
                {
                    b.HasOne("EyeOfGods.Models.UnitOrder", null)
                        .WithMany()
                        .HasForeignKey("UnitTypeOrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EyeOfGods.Models.UnitType", null)
                        .WithMany()
                        .HasForeignKey("UnitTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EyeOfGods.Models.MapModels.Map", b =>
                {
                    b.Navigation("InterestPoints");

                    b.Navigation("Terrains");
                });

            modelBuilder.Entity("EyeOfGods.Models.MapModels.MapScheme", b =>
                {
                    b.Navigation("Maps");
                });

            modelBuilder.Entity("EyeOfGods.Models.RangeWeaponsType", b =>
                {
                    b.Navigation("RangeWeapons");
                });
#pragma warning restore 612, 618
        }
    }
}
