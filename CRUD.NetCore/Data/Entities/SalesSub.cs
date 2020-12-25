using System;
using System.Collections.Generic;

#nullable disable

namespace CRUD.NetCore.Data.Entities
{
    public partial class SalesSub
    {
        public int SalesSubId { get; set; }
        public int? SalesMainId { get; set; }
        public string ItemName { get; set; }
        public decimal ItemRate { get; set; }
        public decimal ItemQuantity { get; set; }

        public virtual SalesMain SalesMain { get; set; }
    }
}
