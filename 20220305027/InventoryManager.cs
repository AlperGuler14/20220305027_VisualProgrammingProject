using System;
using System.Collections.Generic;
using System.Linq;

namespace _20220305027
{
    public class InventoryManager
    {
        AppDbContext _context = new AppDbContext();

        public List<string> GenerateFinancialSummary()
        {
            var sales = _context.Sales.ToList();

            decimal totalRevenue = sales.Sum(s => s.TotalPrice);
            decimal totalProfit = sales.Sum(s => s.TotalProfit);

            return new List<string>
            {
                $"💵 Total Revenue: {totalRevenue:C2}",
                $"📈 Net Profit: {totalProfit:C2}",
                "------------------------------------------"
            };
        }

        public List<string> GenerateSmartRecommendations()
        {
            List<string> recommendations = new List<string>();

            var products = _context.Products.ToList();
            var sales = _context.Sales.ToList();

            var lowStockItems = products.Where(u => u.Unit <= u.MinStockLevel).ToList();
            foreach (var item in lowStockItems)
            {
                recommendations.Add($"⚠️ URGENT RESTOCK: [{item.Category}] {item.Name} is at critical level! (Remaining: {item.Unit} Units)");
            }

            var starProducts = sales.GroupBy(s => s.ProductName)
                                    .Select(g => new { ProductName = g.Key, TotalProfit = g.Sum(x => x.TotalProfit) })
                                    .OrderByDescending(x => x.TotalProfit)
                                    .Take(3)
                                    .ToList();

            foreach (var product in starProducts)
            {
                if (product.TotalProfit > 0)
                {
                    recommendations.Add($"⭐ STAR PRODUCT: {product.ProductName} brought a total net profit of {product.TotalProfit:C2}. Focus your advertising here.");
                }
            }

            var soldProductNames = sales.Select(s => s.ProductName).Distinct().ToList();
            var deadStock = products.Where(u => !soldProductNames.Contains(u.Name) && u.Unit >= 10).ToList();

            foreach (var item in deadStock)
            {
                recommendations.Add($"📉 DEAD STOCK: {item.Name} is sitting in the warehouse. Plan an immediate 15% discount for cash flow.");
            }

            if (recommendations.Count == 0)
            {
                recommendations.Add("✅ The system is running flawlessly. No immediate action required.");
            }

            return recommendations;
        }
    }
}