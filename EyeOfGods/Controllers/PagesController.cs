using EyeOfGods.Context;
using EyeOfGods.Migrations;
using EyeOfGods.Models;
using EyeOfGods.Models.MapModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EyeOfGods.Controllers
{
    public class PagesController : Controller
    {
        private readonly MyWargameContext _context;
        private readonly ILogger<PagesController> _logger;

        public PagesController(MyWargameContext context, ILogger<PagesController> logger) {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Seed()
        {

            List<UnitType> allTypes = await _context.UnitTypes.ToListAsync();
            List<UnitOrder> allOrders = await _context.UnitOrders.ToListAsync();
            List<RangeWeapon> allRangeWeapons = await _context.RangeWeapons.ToListAsync();
            List<RangeWeaponsType> allRangeWeaponTypes = await _context.RangeWeaponsTypes.ToListAsync();
            List<MapScheme> allMapSchemes = await _context.MapSchemes.ToListAsync();

            Random rnd = new();

            
            foreach (var unitType in allTypes)
            {
                if (unitType.UnitTypeOrders == null)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        unitType.UnitTypeOrders.Add(allOrders.ElementAt(rnd.Next(0, allOrders.Count)));
                    };
                    _context.UnitTypes.Update(unitType);
                }
            };

            foreach (var rangeWeapon in allRangeWeapons)
            {
                if (rangeWeapon.RangeWeaponsType == null)
                {
                    rangeWeapon.RangeWeaponsType = allRangeWeaponTypes.ElementAt(rnd.Next(0, allRangeWeaponTypes.Count));
                }
                _context.RangeWeapons.Update(rangeWeapon);
            };

            foreach (var scheme in allMapSchemes)
            {
                SeedData seedData = new();
                scheme.Points = seedData.mapSchemePoints;

                _context.MapSchemes.Update(scheme);
            }


            //if (allMapSchemes.Count == 0)
            //{
            //    SeedData seedData = new();
            //    MapScheme scheme = seedData.mapSchemes[0];
            //    scheme.Points = seedData.mapSchemePoints;

            //    _context.MapSchemes.Add(scheme);
            //}


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Не удалось сохранить даннные в seed");
            }

            return RedirectToAction("Statistics");
        }

        public IActionResult Statistics()
        {
            return View();
        }
        public async Task<IActionResult> Map()
        {
            ////////////////////////////
            // Если использовать dropDownList
            ////////////////////////////
            //var schemes = _context.MapSchemes.GroupBy(m => m.Name);
            //var groups = new List<SelectListGroup>();
            //var items = new List<SelectListItem>();
            //foreach (var group in schemes)
            //{
            //    groups.Add(new SelectListGroup() { Name = group.Key});
            //    foreach (var scheme in group)
            //    {
            //        items.Add(new SelectListItem() { Value = scheme.Name, Text = scheme.Name,
            //            Group = groups.First(g=>g.Name == scheme.Name) });
            //    }
            //}
            //ViewBag.Schemes = items;




            /////!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            /// ИЗНАЧАЛЬНЫЕ МАКС/МИН В РАЗМЕРЫ ВЫБИРАТЬ В КОНТРОЛЛЕРЕ!!!!!!!!!
            /// Выбирать все схемы, находить все размеры, забивать их в селект листы, по убыванию
            /// По соотношению максимальных высот-ширин выбирать схему для генерации при загрузке страницы?
            /// 
            /// Можно при загрузке и не генерить, но выборку схем по размерам сделать надо
            var schemesMaxWidth = await _context.MapSchemes.OrderByDescending(s => s.MapWidth).ToListAsync();
            string value;
            string text;

            List<SelectListItem> sizes = new();
            foreach (var scheme in schemesMaxWidth)
            {
                value = scheme.MapWidth.ToString() + "x" + scheme.MapHeight.ToString();
                text = (scheme.MapWidth * 4).ToString() + "\"" + "x" + (scheme.MapHeight * 4).ToString() + "\"";

                if (!sizes.Any(s => s.Value == value))
                {
                    sizes.Add(new() { Value = value, Text = text });
                }
            }
            ViewBag.MapSizes = sizes;

            //List<SelectListItem> heights = new();
            //var schemesMaxHeight = schemesMaxWidth.OrderByDescending(s=>s.MapHeight);
            //foreach (var item in schemesMaxHeight)
            //{
            //    value = item.MapHeight.ToString();
            //    text = (item.MapHeight * 4).ToString() + "\"";
            //    if (!heights.Any(s => s.Value == value))
            //    {
            //        heights.Add(new() { Value = value, Text = text });
            //    }
            //}
            //ViewBag.Heights = heights;





            ///////////////////
            /// Кароче надо после выбора высоты/ширины стола выбирать схемы с такими размерами и размещать их сверху селекта
            /// Остальные становятся disabled и размещаются снизу - напрашивается разделение на 2 группы "доступные" и "недоступные"
            /// ЕСЛИ ЭТО ДЕЛАТЬ НА СЕРВЕРЕ - напрашивается свойство "allowed" или что-то такое. 
            /// Но наверно лучше делать через js
            ///
            /// ПАДАЖЖИ! 2 группы... Получается, что в имени схемы мы размер не указываем -> надо каждый раз выборку делать,
            /// не плодить же одинаковые названия в селекте...
            /// ЗНАЧИТ НАДО ТАКИ ГРУППИРОВАТЬ СХЕМЫ ПО ИМЕНИ, а потом группы прочесывать в поиске нужных ширин/высот
            /// Нашел - запихал ID в Value, имя в текст, не нашел - запихал ключ группы(название) в группу "недоступные размеру"
            /// Группы "доступные" не надо, пусть просто названия схем сначала идут - они же будут в 1 экземпляре
            ///
            /// Еще момент - доп модификаторы "Большой город"/"Мегаполис" доступные схемам с 1 городом и увеличивающие его размер
            /// Под них надо еще одну таблицу в схему, "IntPointOptions" в каждой строчке - название опции, описание
            /// В каждой схеме лист доступных модификаторов
            /// А в генераторе метод в большим-большим свичем в цикле по листу
            /// 
            /// Надо намутить кнопку "далее/зазад" для пролистывания схем без перекликивания выпадающего списка
            /// 
            /// Для квадратов поля - брать 80% ВЫСОТЫ окна, делить на кол-во координат(получается высота квадрата),
            /// потом равнять ширину квадрата с его высотой 






            //////////////////////////// ЧТО ДАЛЬШЕ?
            /// Дальше надо раскрыть название схемы:
            /// Сколько точек и какие они, чтоб люди не в название вчитывались
            /// Доступные модификаторы точек - это пока не надо
            /// Уровень квестов - выпадающим списком(Схемы сохраняться не будут!)
            /// Максимальный ГодПрезенс?? - он от плотности террейна больше зависит
            /// ВООБЩЕ тут надо еще минимальный выставить - кол-во точек минус 2
            /// А вот максимальный привязать к плотности террейна в блоке террейна... А вдруг там одна вода будет выставлена??
            /// Считать потенциальное количество пригодого террейна и выставлять значение чуть ниже?
            /// Формула - кол-во точек минус 2, умножить на значение плотности террейна, умножить на суммарный процент
            /// пригодного террейна??? кстати неплохо...
            /// 
            /// ЕЩЕ НАДО возможность выбрать карту из сохраненных!
            /// 
            /// Потом раскрывать террейнОптионс...
            /// 
            /// Потом кнопки "перегенерить точки" и "перегенерить террейн" + "перегенерить жетоны"
            /// Ну и "Генерить карту", разумеется
            /// И механизм просмотра нагенеренных, но не сохраненных из этого сеанса
            /// 
            /// Потом сохранение карты, возможность загрузить карту.. 
            /// ВОТ КСТАТИ! при загрузке может выдавать уже готовую карту?
            /// В ЛЮБОМ случае надо еще поле с выбором уже существующих карт!



            return View();
        }
    }
}

