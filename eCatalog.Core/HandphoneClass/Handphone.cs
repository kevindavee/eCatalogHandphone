using eCatalog.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCatalog.Core.HandphoneClass
{
    public class Handphone: Parent
    {
        public string Name { get; set; } = "";
        public string ProductDescription { get; set; } = "";
        public int SellPrice { get; set; } = 0;
        public int? BuyPrice { get; set; } = null;
        public int Seen { get; set; } = 0;
        public bool isDeleted { get; set; } = false;
        public string ImageUrl { get; set; } = "";

        public long BrandId { get; set; }

        //Relationship
        public virtual Brand Brand { get; set; }
    }
}
