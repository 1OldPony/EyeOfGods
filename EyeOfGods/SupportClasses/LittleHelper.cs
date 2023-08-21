using EyeOfGods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EyeOfGods.SupportClasses
{
    public class LittleHelper
    {

        public static bool UnitEquipRandomAssigment(Unit unit, string equipType, double percent)
        {
            bool basicValue = false;

            switch (equipType.ToLower())
            {
                case "rangeweapon":
                    return BoolRandom(percent);
                case "shield":
                    foreach (var item in unit.MeleeWeapons)
                    {
                        if (item.WeaponType == MeleeWeaponTypes.Копье || item.WeaponType == MeleeWeaponTypes.Одноручное)
                        {
                            return BoolRandom(percent);
                        }
                    }
                    return basicValue;
                default:
                    return basicValue;
            }
        }

        public static bool BoolRandom(double percent)
        {
            //погрешность ~2%
            Random random = new Random();

            List<bool> results = new();

            double coefficient = Math.Round(100.0 / percent, 2);

            for (int y = 0; y < 5000; y++)
            {
                if (Math.Round(random.NextDouble() * 100.0, 2) % coefficient <= 1.0)
                {
                    results.Add(true);
                }
                else
                {
                    results.Add(false);
                }
            }

            return results.ElementAt(random.Next(0, results.Count-1));
        }


        //public static bool DbInitialisationFix (List<Unit> allUnits, List<RangeWeaponsType> allRangeWeaponTypes, List<RangeWeapon> allRangeWeapons,
        //    List<UnitOrder> allOrders, List<UnitType> allTypes)
        //{
        //    Random randomNumber = new();

        //    foreach (var unitType in allTypes)
        //    {
        //        if (unitType.UnitTypeOrders == null)
        //        {
        //            for (int i = 0; i < 2; i++)
        //            {
        //                unitType.UnitTypeOrders.Add(allOrders.ElementAt(randomNumber.Next(0, allOrders.Count() - 1)));
        //            };
        //            _context.UnitTypes.Update(unitType);
        //        }
        //    };


        //    foreach (var rangeWeapon in allRangeWeapons)
        //    {
        //        if (rangeWeapon.RangeWeaponsType == null)
        //        {
        //            rangeWeapon.RangeWeaponsType = allRangeWeaponTypes.ElementAt(randomNumber.Next(0, allRangeWeaponTypes.Count() - 1));
        //            _context.RangeWeapons.Update(rangeWeapon);
        //        }
        //    };
        //    return false;
        //}

        //public static bool DbInitialisationFix(List<Unit> unitsList)
        //{
        //    Random randomNumber = new();

        //    foreach (var unit in unitsList)
        //    {
        //        if (unit.UnitType.UnitTypeOrders == null)
        //        {
        //            for (int i = 0; i < 2; i++)
        //            {
        //                unitType.UnitTypeOrders.Add(allOrders.ElementAt(randomNumber.Next(0, allOrders.Count() - 1)));
        //            };
        //            _context.UnitTypes.Update(unitType);
        //        }

        //    };


        //    foreach (var rangeWeapon in db.RangeWeapons.ToList())
        //    {
        //        if (rangeWeapon.RangeWeaponsType == null)
        //        {
        //            rangeWeapon.RangeWeaponsType = allRangeWeaponTypes.ElementAt(randomNumber.Next(0, allRangeWeaponTypes.Count() - 1));
        //            _context.RangeWeapons.Update(rangeWeapon);
        //        }
        //    };

        //    return false;
        //}
    }
}
