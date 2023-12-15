using EyeOfGods.Models;

namespace EyeOfGods.SupportClasses
{
    public interface ILittleHelper
    {
        bool BoolRandom(double percent);
        bool UnitEquipRandomAssigment(Unit unit, string equipType, double percent);
    }
}