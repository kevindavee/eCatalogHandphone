using eCatalog.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCatalog.Core.HandphoneClass
{
    public class Handphone: Parent
    {
        public string Name { get; set; } = "";
        [DataType(DataType.MultilineText)]
        public string ProductDescription { get; set; } = "";

        [DisplayFormat(DataFormatString = "{0:#,##0.##}")]
        public int SellPrice { get; set; } = 0;

        [DisplayFormat(DataFormatString = "{0:#,##0.##}")]
        public int? BuyPrice { get; set; } = null;

        public int Seen { get; set; } = 0;
        public bool isDeleted { get; set; } = false;
        public string ImageUrl { get; set; } = "";

        public long BrandId { get; set; }

        //Relationship
        public virtual Brand Brand { get; set; }
    }
}
