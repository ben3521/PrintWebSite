using System;
using System.Collections.Generic;
using System.Text;

namespace PrintWebSite.Entities
{
    public class BaseEntity
    {
        public int ID { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
