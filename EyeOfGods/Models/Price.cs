using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EyeOfGods.Models
{
    public class Price
    {
        public int Id { get; set; }
        public string BalaneVersion { get; set; }
        public int InfBaseSizePrice { get;set; }
        public int CavBaseSizePrice { get; set; }
        public int MonsBaseSizePrice { get; set; }
        public int GiantBaseSizePrice { get; set; }
        public int ArtilBaseSizePrice { get; set; }
        public int TechBaseSizePrice { get; set; }
        public int AviaBaseSizePrice { get; set; }

        public int SmallSizeCoef { get; set; }
        public int BigSizeCoef { get; set; }

    }
}
