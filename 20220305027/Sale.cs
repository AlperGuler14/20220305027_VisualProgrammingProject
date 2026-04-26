using System;

namespace _20220305027
{
    public class Sale
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalProfit { get; set; }
        public DateTime SaleDate { get; set; }
    }
}