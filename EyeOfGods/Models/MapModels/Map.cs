using System.Collections.Generic;

namespace EyeOfGods.Models.MapModels
{
    public class Map
    {
        public int Id { get; set; }
        public string Name { get; set; }


        /// <summary>
        /// У всех точек-террейнов карты тоже должны быть свои координаты
        /// 
        /// Парности им не надо прописывать - они уже готовы
        /// Номеров точек тоже, это нужно только генератору
        /// 
        /// А вот точно не надо номеров? если игрок хочет перегенерить какую-то точку(а она парная!) - ему удасться без номера?
        /// 
        /// Нафиг не надо ему ничего генерить - пусть сам тип ставит или генерит, а потом парную в ручную меняет
        /// </summary>


        public List<InterestPoint> InterestPoints { get; set; } = new();
        public List<Terrain> Terrains { get; set; } = new();
        public MapScheme Scheme { get; set; }
    }
}
