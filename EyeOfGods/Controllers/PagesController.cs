using EyeOfGods.Models;
using EyeOfGods.Models.ViewModels;
using EyeOfGods.SupportClasses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EyeOfGods.Controllers
{
    public class PagesController : Controller
    {
        private readonly MyWargameContext _context;

        public PagesController(MyWargameContext context) {
            _context = context;
        }




        //public IActionResult DbCheck ()
        public void DbCheck()
        {
            /////////////////////////////////////////////////////////////
            ///ТУТ НУЖНЫ ИМЕННО ГЕНЕРАТОРЫ СТРЕЛКОВОГО И ЮНИТОВ
            /////////////////////////////////////////////////////////////

            List<UnitType> allTypes = _context.UnitTypes.ToList();
            List<UnitOrder> allOrders = _context.UnitOrders.ToList();
            List<RangeWeapon> allRangeWeapons = _context.RangeWeapons.ToList();
            List<MeleeWeapon> allMeleeWeapons = _context.MeleeWeapons.ToList();
            List<Shield> allShields = _context.Shields.ToList();
            List<RangeWeaponsType> allRangeWeaponTypes = _context.RangeWeaponsTypes.ToList();
            List<Unit> allUnits = _context.Units.ToList();
            List<MentalAbilities> allMental = _context.MentalAbilities.ToList();
            List<DefensiveAbilities> allDefense = _context.DefensiveAbilities.ToList();
            List<EnduranceAbilities> allEndurance = _context.EnduranceAbilities.ToList();

            Random randomNumber = new();


            foreach (var unitType in allTypes)
            {
                if (unitType.UnitTypeOrders == null)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        unitType.UnitTypeOrders.Add(allOrders.ElementAt(randomNumber.Next(0, allOrders.Count - 1)));
                    };
                    _context.UnitTypes.Update(unitType);
                }
            };

            foreach (var rangeWeapon in allRangeWeapons)
            {
                if (rangeWeapon.RangeWeaponsType == null)
                {
                    rangeWeapon.RangeWeaponsType = allRangeWeaponTypes.ElementAt(randomNumber.Next(0, allRangeWeaponTypes.Count - 1));
                    rangeWeapon.RWName = rangeWeapon.RangeWeaponsType.RWTypeName;
                }

                if (rangeWeapon.RangeOfShooting == 0)
                {
                    while (rangeWeapon.RangeOfShooting % rangeWeapon.RangeWeaponsType.DistanceStep !=0)
                    {
                        rangeWeapon.RangeOfShooting = randomNumber.Next(rangeWeapon.RangeWeaponsType.MinDistance, rangeWeapon.RangeWeaponsType.MaxDistance);
                    }
                }
                _context.RangeWeapons.Update(rangeWeapon);
            };


            if (allUnits.Count == 0)
            {
                //int speed = 0;
                //int defense = 0;
                //int endurance = 0;
                //int mental = 0;
                for (int i = 0; i < 5; i++)
                {
                    Unit unit = new ();

                    unit.MentalAbilities = allMental.ElementAt(randomNumber.Next(0, allMental.Count));
                    unit.DefensiveAbilities = allDefense.ElementAt(randomNumber.Next(0, allDefense.Count));
                    unit.EnduranceAbilities = allEndurance.ElementAt(randomNumber.Next(0, allEndurance.Count));
                    unit.MeleeWeapons.Add(allMeleeWeapons.ElementAt(randomNumber.Next(0, allMeleeWeapons.Count)));
                    unit.RangeWeapon = allRangeWeapons.ElementAt(randomNumber.Next(0, allRangeWeapons.Count));
                    unit.Shield = allShields.ElementAt(randomNumber.Next(0, allShields.Count));
                    unit.UnitType = allTypes.ElementAt(randomNumber.Next(0, allTypes.Count));


                    while (unit.Speed % 2 != 0 && unit.Speed != 0)
                    {
                        unit.Speed = randomNumber.Next(unit.UnitType.MinSpeed, unit.UnitType.MaxSpeed);
                    }
                    //unit.Speed = speed;

                    while (unit.Defense % unit.DefensiveAbilities.Step !=0 && unit.Defense != 0)
                    {
                        unit.Defense = randomNumber.Next(unit.DefensiveAbilities.MinValue, unit.DefensiveAbilities.MaxValue);
                    }
                    //unit.Defense = defense;

                    while (unit.Endurance % unit.EnduranceAbilities.Step != 0 && unit.Endurance != 0)
                    {
                        unit.Endurance = randomNumber.Next(unit.EnduranceAbilities.MinValue, unit.EnduranceAbilities.MaxValue);
                    }
                    //unit.Endurance = endurance;

                    while (unit.Mental % unit.MentalAbilities.Step != 0 && unit.Mental != 0)
                    {
                        unit.Mental = randomNumber.Next(unit.MentalAbilities.MinValue, unit.MentalAbilities.MaxValue);
                    }
                    //unit.Mental = mental;


                    /////////ГЕНЕРАТОР НАЗВАНИЯ ОТРЯДА
                    if (unit.Defense < unit.DefensiveAbilities.NoDoubleActionAt)
                        unit.UnitName = "Легк.";
                    else
                        unit.UnitName = "Тяж.";

                    unit.UnitName = string.Concat(unit.UnitName, " ", unit.UnitType.UnitTypeName);

                    int unitMeleeWeapon = 1;
                    foreach (var item in unit.MeleeWeapons)
                    {
                        if (unitMeleeWeapon == 1)
                            unit.UnitName = string.Concat(unit.UnitName, " c ", item.MWName);
                        else
                            unit.UnitName = string.Concat(unit.UnitName, " и ", item.MWName);
                    }

                    allUnits.Add(unit);
                }
                foreach (var item in allUnits)
                {
                    _context.Units.Add(item);
                }
            }
            else
            {
                foreach (var unit in allUnits)
                {
                    if (unit.MeleeWeapons.Count == 0)
                    {
                        unit.MeleeWeapons.Add(allMeleeWeapons.ElementAt(randomNumber.Next(0, allMeleeWeapons.Count - 1)));
                    }

                    if (unit.RangeWeapon == null)
                    {
                        if (LittleHelper.UnitEquipRandomAssigment(unit, "RangeWeapon", 30.0))
                        {
                            unit.RangeWeapon = allRangeWeapons.ElementAt(randomNumber.Next(0, allRangeWeapons.Count - 1));
                        }
                    }

                    if (unit.MentalAbilities == null)
                    {
                        unit.MentalAbilities = allMental.ElementAt(randomNumber.Next(0, allMental.Count - 1));
                    }

                    if (unit.DefensiveAbilities == null)
                    {
                        unit.DefensiveAbilities = allDefense.ElementAt(randomNumber.Next(0, allDefense.Count - 1));
                    }

                    if (unit.EnduranceAbilities == null)
                    {
                        unit.EnduranceAbilities = allEndurance.ElementAt(randomNumber.Next(0, allEndurance.Count - 1));
                    }

                    if (unit.Shield == null)
                    {
                        if (LittleHelper.UnitEquipRandomAssigment(unit, "Shield", 50.0))
                        {
                            unit.Shield = allShields.ElementAt(randomNumber.Next(0, allShields.Count - 1));
                        }
                    }

                    if (unit.UnitType == null)
                    {
                        unit.UnitType = allTypes.ElementAt(randomNumber.Next(0, allTypes.Count - 1));
                    }

                    _context.Units.Update(unit);
                }
            }
            _context.SaveChanges();

            //return RedirectToAction("Start", allUnits);
            Start(allUnits);
        }


        public IActionResult Start(List<Unit> units)
        {


            ///////////////Пробуем перевязать модели/////////////////
            //var db = _context;
            //////////////////////////////////////////
            ///ВЕСЬ КОНТЕКСТ ВЫЗЫВАТЬ КОНЕЧНО НЕ НАДО!
            ///
            /// 
            /// ВЫЗЫВАЕМ ЮНИТОВ, РОДА ВОЙСК И СТРЕЛКОВОЕ ОРУЖИЕ - ХВАТИТ ОДНИХ ЮНИТОВ!!!! Я ЖЕ ЧЕРЕЗ НИХ КУДА УГОДНО МОГУ ВЫЙТИ
            /// ЭТО ТОЛЬКО ЕСЛИ ВСЕ ТИПЫ ОРУЖИЯ НАПРИМЕР ЕСТЬ В БАЗЕ
            /// 
            /// ВЫЗОВ ПРИКАЗОВ И ТИПОВ СТРЕЛКОВОГО ПРЯЧЕМ ПОД IF, С ПРОВЕРКОЙ ЕСТЬ ЛИ ПОЛЯ С NULL
            /// 
            /// ТО ЖЕ САМОЕ ДЛЯ ВСЕХ НАВИГАЦИОННЫХ СВОЙСТВ ЮНИТОВ - ПРОВЕРКА НА NULL - ВЫЗОВ СПИСКА СВЯЗАННЫХ СУЩНОСТЕЙ ИЗ БАЗЫ
            /// 
            /// 
            /// А ВООБЩЕ!!! РАССМОТРЕТЬ ВОЗМОЖНОСТЬ В КОНСТРУКТОРЕ ИНИЦИАЛИЗИРОВАТЬ
            /////////////////////////////////////////




            //ВОТ ЭТО ЛУЧШИЙ ВАР
            /////////////////////////////////////////
            ///ЕСЛИ НЕ В КОНСТРУКТОРЕ - ОТДЕЛЬНЫЙ МЕТОД, МОЖЕТ БЫТЬ API, 
            ///КОТОРЫЙ БУДЕТ ВЫЗЫВАТЬСЯ ПОСЛЕ ГЕНЕРАЦИИ НОВЫХ ЮНИТОВ КНОПКОЙ
            ///И ПРИ ЗАПУСКЕ СТРАНИЦЫ СТАТИСТИКИ(ТОГДА В НЕГО БУДЕТ ПЕРЕДАВАТЬСЯ КОНТЕКСТ)
            ///
            ///ВОЗМОЖНО ПЕРЕГРУЖЕННЫЙ МЕТОД, С КОНТЕКСТОМ И БЕЗ - ДЛЯ СТАТИСТИКИ И ПРИ ГЕНЕРАЦИИ
            ///ДЛЯ ПРОСТО ЗАХОДА НА СТРАНИЦУ СТАТИСТИКИ(С ПЕРЕДАННЫМ КОНТЕКСТОМ - ОН МОЖЕТ РЕДИРЕКТИТЬ НА НЕЕ)
            ///Т.Е. НА СТАТИСТИКУ МЫ МОЖЕМ ПОПАСТЬ ТОЛЬКО ЧЕРЕЗ ЭТОТ МЕТОД - НА НЕГО ССЫЛКИ 
            /////////////////////////////////////////
            /////////////////////////////////////////
            /////////////////////////////////////////
            ///НАДО ОСТАВИТЬ ИНИЦИАЛИЗАЦИЮ БАЗЫ ДАННЫХ ТОЛЬКО ДЛЯ ТАБЛИЦ С ФИКСИРОВАННЫМИ ПАРАМЕТРАМИ И БЕЗ ВНЕШНИХ КЛЮЧЕЙ
            ///ЮНИТЫ ТОЧНО ТОЛЬКО ГЕРЕРИРОВАННЫЕ
            ///В ТАКОМ ВИДЕ - МОЙ "ФИКС ИНИЦИАЛИЗАЦИИ" - ЭТО И ЕСТЬ ИЗНАЧАЛЬНАЯ ГЕНЕРАЦИЯ ДАННЫХ


            ////СОБИРАЕМ СТАТИСТИКУ
            //List<Unit> allUnits = _context.Units.ToList();



            List<UnitType> allTypes = _context.UnitTypes.ToList();
            List<UnitOrder> allOrders = _context.UnitOrders.ToList();
            List<RangeWeapon> allRangeWeapons = _context.RangeWeapons.ToList();
            List<MeleeWeapon> allMeleeWeapons = _context.MeleeWeapons.ToList();
            List<Shield> allShields = _context.Shields.ToList();
            List<RangeWeaponsType> allRangeWeaponTypes = _context.RangeWeaponsTypes.ToList();
            List<Unit> allUnits = _context.Units.ToList();
            List<MentalAbilities> allMental = _context.MentalAbilities.ToList();
            List<DefensiveAbilities> allDefense = _context.DefensiveAbilities.ToList();
            List<EnduranceAbilities> allEndurance = _context.EnduranceAbilities.ToList();





            //var allUnits = _context.Units;




            StatisticsViewModel statistics = new();

            foreach (var unit in allUnits)
            {
                statistics.UnitsCount++;

                switch (unit.UnitType.UnitTypeName)
                {
                    case "Пехота":
                        statistics.InfantryCount++;
                        break;
                    case "Кавалерия":
                        statistics.CavaleryCount++;
                        break;
                    case "Монстры":
                        statistics.MonsterCount++;
                        break;
                    case "Гиганты":
                        statistics.GiantsCount++;
                        break;
                    case "Артиллерия":
                        statistics.ArtilleryCount++;
                        break;
                    case "Техника":
                        statistics.VenicleCount++;
                        break;
                    case "Авиация":
                        statistics.AviationCount++;
                        break;
                    default:
                        break;
                }

                ////////////////////////////////////////////
                ///ПОМЕНЯТЬ ЛИСТЫ КЛАССОВ В МОДЕЛИ НА СЛОВАРИ???
                ////////////////////////////////////////////



                //учитываем защитные характеристики
                if (!statistics.DefenceChars.Any(x => x.CharacteristicName == unit.DefensiveAbilities.CharacteristicName ))
                {
                    statistics.DefenceChars.Add(new DefenceChars() { CharacteristicName = unit.DefensiveAbilities.CharacteristicName, UsageCount = 1 });
                }
                else
                {
                    statistics.DefenceChars.First(x => x.CharacteristicName == unit.DefensiveAbilities.CharacteristicName).UsageCount++;
                }

                //учитываем характеристики выносливости
                if (!statistics.EnduranceChars.Any(x => x.CharacteristicName == unit.DefensiveAbilities.CharacteristicName))
                {
                    statistics.EnduranceChars.Add(new EnduranceChars() { CharacteristicName = unit.EnduranceAbilities.CharacteristicName, UsageCount = 1 });
                }
                else
                {
                    statistics.EnduranceChars.First(x => x.CharacteristicName == unit.EnduranceAbilities.CharacteristicName).UsageCount++;
                }

                //учитываем ментальные характеристики
                if (!statistics.MentalChars.Any(x => x.CharacteristicName == unit.MentalAbilities.CharacteristicName))
                {
                    statistics.MentalChars.Add(new MentalChars() { CharacteristicName = unit.MentalAbilities.CharacteristicName, UsageCount = 1 });
                }
                else
                {
                    statistics.MentalChars.First(x => x.CharacteristicName == unit.MentalAbilities.CharacteristicName).UsageCount++;
                }

                //учитываем оружие ближнего боя
                if (unit.MeleeWeapons != null)
                {
                    foreach (var weapon in unit.MeleeWeapons)
                    {
                        statistics.MeleeWeaponsCount++;

                        if (!statistics.MeleeWeaponsTypes.Any(x => x.WeaponStatName == weapon.WeaponType.ToString()))
                        {
                            statistics.MeleeWeaponsTypes.Add(new MeleeWeaponsStat() { WeaponStatName = weapon.WeaponType.ToString(), UsageCount = 1 });
                        }
                        else
                        {
                            statistics.MeleeWeaponsTypes.First(x => x.WeaponStatName == weapon.WeaponType.ToString()).UsageCount++;
                        }
                    }
                }

                //учитываем оружие дальнего боя
                if (unit.RangeWeapon!= null)
                {
                    statistics.RangeWeaponsCount++;

                    if (!statistics.RangeWeaponsTypes.Any(x => x.WeaponStatName == unit.RangeWeapon.RangeWeaponsType.RWTypeName))
                    {
                        statistics.RangeWeaponsTypes.Add(new RangeWeaponsStat() { WeaponStatName = unit.RangeWeapon.RangeWeaponsType.RWTypeName, UsageCount = 1 });
                    }
                    else
                    {
                        statistics.RangeWeaponsTypes.First(x => x.WeaponStatName == unit.RangeWeapon.RangeWeaponsType.RWTypeName).UsageCount++;
                    }
                }

                //учитываем щиты
                if (unit.Shield!=null)
                {
                    statistics.ShieldsCount++;
                }

            }

            return View(statistics);
        }

        public IActionResult MapGenerator()
        {
            return View();
        }

        public IActionResult Balance()
        {
            return View();
        }
        public IActionResult UserProfile()
        {
            return View();
        }

    }
}
