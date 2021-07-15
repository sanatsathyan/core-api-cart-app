using System;

namespace DataTransferObjects
{
    public class ProductsDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public decimal Cost { get; set; }
        public int Quantity { get; set; }
    }
}
