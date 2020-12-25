using System;
using System.Collections.Generic;

#nullable disable

namespace CRUD.NetCore.Data.Entities
{
    public partial class SalesMain
    {
        public SalesMain()
        {
            SalesSubs = new HashSet<SalesSub>();
        }

        public int SalesMainId { get; set; }
        public DateTime? SalesDate { get; set; }
        public decimal TotalAmount { get; set; }

        public virtual ICollection<SalesSub> SalesSubs { get; set; }
    }
}
