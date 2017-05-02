using eCatalog.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCatalog.Core.HandphoneClass
{
    public class Brand:Parent
    {
        public string Name { get; set; }

        //Relationship
        public virtual ICollection<Handphone> Handphone { get; set; }
    }
}
