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




        public IActionResult DbCheck ()
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
                    _context.RangeWeapons.Update(rangeWeapon);
                }
            };



            foreach (var unit in allUnits)
            {
                if (unit.MeleeWeapons == null)
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


            _context.SaveChanges();






            //LittleHelper.DbInitialisationFix(allUnits, allRangeWeaponTypes, allRangeWeapons, allOrders, allTypes);


            return RedirectToAction("Start");
        }


        public IActionResult Start()
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





            //List<UnitType> allTypes = _context.UnitTypes.ToList();
            //List<UnitOrder> allOrders = _context.UnitOrders.ToList();
            //List<RangeWeapon> allRangeWeapons = _context.RangeWeapons.ToList();
            //List<RangeWeaponsType> allRangeWeaponTypes = _context.RangeWeaponsTypes.ToList();
            //Random randomNumber = new();

            //foreach (var unitType in db.UnitTypes.ToList())
            //{
            //    if (unitType.UnitTypeOrders == null)
            //    {
            //        for (int i = 0; i < 2; i++)
            //        {
            //            unitType.UnitTypeOrders.Add(allOrders.ElementAt(randomNumber.Next(0, allOrders.Count() - 1)));
            //        };
            //        _context.UnitTypes.Update(unitType);
            //    }
            //};


            //foreach (var rangeWeapon in db.RangeWeapons.ToList())
            //{
            //    if (rangeWeapon.RangeWeaponsType == null)
            //    {
            //        rangeWeapon.RangeWeaponsType = allRangeWeaponTypes.ElementAt(randomNumber.Next(0, allRangeWeaponTypes.Count() - 1));
            //        _context.RangeWeapons.Update(rangeWeapon);
            //    }
            //};










            //List<UnitType> allTypes = _context.UnitTypes.ToList();
            //List<UnitOrder> allOrders = _context.UnitOrders.ToList();
            //List<RangeWeapon> allRangeWeapons = _context.RangeWeapons.ToList();
            //List<RangeWeaponsType> allRangeWeaponTypes = _context.RangeWeaponsTypes.ToList();
            //Random randomNumber = new();
            
            //foreach (var unitType in allTypes)
            //{
            //    if (unitType.UnitTypeOrders == null)
            //    {
            //        for (int i = 0; i < 2; i++)
            //        {
            //            unitType.UnitTypeOrders.Add(allOrders.ElementAt(randomNumber.Next(0, allOrders.Count() -1)));
            //        };
            //        _context.UnitTypes.Update(unitType);
            //    }
            //};


            //foreach (var rangeWeapon in allRangeWeapons)
            //{
            //    if (rangeWeapon.RangeWeaponsType == null)
            //    {
            //        rangeWeapon.RangeWeaponsType = allRangeWeaponTypes.ElementAt(randomNumber.Next(0, allRangeWeaponTypes.Count() -1));
            //        _context.RangeWeapons.Update(rangeWeapon);
            //    }
            //};








            //_context.SaveChanges();



            ////СОБИРАЕМ СТАТИСТИКУ
            List<Unit> allUnits = _context.Units.ToList();

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
