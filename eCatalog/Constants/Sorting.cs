using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCatalog.Constants
{
    public class Sorting
    {
        public int SortValue { get; set; }
        public string SortName { get; set; }
        public List<Sorting> SortList;

        public Sorting()
        {
            SortList = new List<Sorting>() {
                SortValue: 0,
                SortName: "All",
            };
        }
        public const int NoSorting = 0;
        public const int MostSeen = 1;
        public const int LowestPrice = 2;
        public const int HighestPrice = 3;
    }
}