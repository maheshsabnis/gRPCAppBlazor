using System;
using System.Collections.Generic;

#nullable disable

namespace grpc_db_ops.Models
{
    public partial class Product
    {
        public int ProductRowId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string Manufacturer { get; set; }
        public int Price { get; set; }
    }
}
