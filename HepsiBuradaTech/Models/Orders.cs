using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HepsiBuradaTech.Models
{
    public class Orders : BaseEntity
    {
        public string ProductCode { get; set; }
        public int Quantity { get; set; }

    }
}
