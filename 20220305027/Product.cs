using System;

namespace _20220305027
{
    public class Product
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public int Unit { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public int MinStockLevel { get; set; }
        public int TotalSold { get; set; }
    }
}