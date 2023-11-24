using EyeOfGods.Models;
using EyeOfGods.Models.MapModels;
using EyeOfGods.SupportClasses.MapGenFactory.Products;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EyeOfGods.SupportClasses.MapGenFactory.Creators
{
    public class TreasuryCreator : Creator
    {
        private MyWargameContext _context;
        private QuestLevel _level;

        public TreasuryCreator(MapSchemePoint point, MyWargameContext context, QuestLevel level): base(point)
        {
            _context = context;
            _level = level;
        }

        public override MapSchemePoint Create()
        {
            Random rnd = new();
            List<Quest> quests = _context.Quests.Where(q => q.Level == _level).ToList();

            return new Treasury(_point, quests.ElementAt(rnd.Next(0,quests.Count)));
        }
    }
}
