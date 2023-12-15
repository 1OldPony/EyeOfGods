using EyeOfGods.Models.MapModels;
using EyeOfGods.SupportClasses.MapGenFactory.IntPoint.Products;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EyeOfGods.SupportClasses.MapGenFactory.IntPoint.Creators
{
    public class TreasuryCreator : IntPointCreator
    {
        //private List<Quest> _quests;
        //private QuestLevel _level;

        public TreasuryCreator(MapSchemePoint point/*, List<Quest> quests, QuestLevel level*/): base(point)
        {
            //_quests = quests;
            //_level = level;
        }

        public override InterestPoint Create()
        {
            //Random rnd = new();

            //if (_level == QuestLevel.случайный)
            //    _quests = _quests.ToList();
            //else
            //    _quests = _quests.Where(q => q.Level == _level).ToList();

            return new Treasury(_point/*, _quests.ElementAt(rnd.Next(0,_quests.Count))*/);
        }
    }
}
