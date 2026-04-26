using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace _20220305027
{
    public partial class AnalysisForm : Form
    {
        AppDbContext _context = new AppDbContext();
        InventoryManager _inventoryManager = new InventoryManager();
        Chart chart1;
        Chart chart2;

        public AnalysisForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void AnalysisForm_Load(object sender, EventArgs e)
        {
            ApplyModernTheme();
            InitializeChart();
            LoadData();
            DrawChart();
        }

        private void ApplyModernTheme()
        {
            this.BackColor = Color.FromArgb(245, 246, 250);
            this.Font = new Font("Segoe UI", 10);

            listBox1.BorderStyle = BorderStyle.None;
            listBox1.BackColor = Color.White;
            listBox1.ForeColor = Color.FromArgb(44, 62, 80);
            listBox1.Font = new Font("Segoe UI", 10, FontStyle.Regular);

            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.BackColor = Color.FromArgb(52, 152, 219);
            button1.ForeColor = Color.White;
            button1.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            button1.Cursor = Cursors.Hand;
        }

        private void InitializeChart()
        {
            if (chart1 == null)
            {
                TableLayoutPanel chartPanel = new TableLayoutPanel();
                chartPanel.RowCount = 1;
                chartPanel.ColumnCount = 2;
                chartPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                chartPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

                chartPanel.Dock = DockStyle.Bottom;
                chartPanel.Height = 350;
                chartPanel.Parent = this;

                chart1 = new Chart();
                chart1.Dock = DockStyle.Fill;
                chart1.BackColor = Color.White;

                ChartArea area1 = new ChartArea("Area1");
                area1.BackColor = Color.White;
                area1.AxisX.MajorGrid.LineWidth = 0;
                area1.AxisY.MajorGrid.LineColor = Color.FromArgb(220, 220, 220);
                area1.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
                area1.AxisX.LabelStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                area1.AxisY.LabelStyle.Font = new Font("Segoe UI", 9);
                chart1.ChartAreas.Add(area1);

                chart2 = new Chart();
                chart2.Dock = DockStyle.Fill;
                chart2.BackColor = Color.White;

                ChartArea area2 = new ChartArea("Area2");
                area2.BackColor = Color.White;
                chart2.ChartAreas.Add(area2);

                Legend legend1 = new Legend("Default");
                legend1.Font = new Font("Segoe UI", 9);
                chart1.Legends.Add(legend1);

                Legend legend2 = new Legend("Default");
                legend2.Font = new Font("Segoe UI", 9);
                chart2.Legends.Add(legend2);

                chartPanel.Controls.Add(chart1, 0, 0);
                chartPanel.Controls.Add(chart2, 1, 0);
            }
        }

        private void LoadData()
        {
            listBox1.Items.Clear();

            listBox1.Items.Add("=== SYSTEM SMART ANALYSIS WARNINGS ===");
            var recommendations = _inventoryManager.GenerateSmartRecommendations();

            if (recommendations != null && recommendations.Count > 0)
            {
                foreach (var message in recommendations)
                {
                    listBox1.Items.Add("⚠ " + message);
                }
            }
            else
            {
                listBox1.Items.Add("✅ No critical situation detected at the moment.");
            }

            listBox1.Items.Add("------------------------------------------");
            listBox1.Items.Add("");

            listBox1.Items.Add("📊 GENERAL FINANCIAL STATUS");
            var financialSummary = _inventoryManager.GenerateFinancialSummary();
            foreach (var line in financialSummary)
            {
                listBox1.Items.Add(line);
            }

            decimal totalCost = _context.Products
                .AsEnumerable()
                .Sum(p => (decimal)p.Unit * p.Cost);

            listBox1.Items.Add($"💰 Total Value of Goods in Stock: {totalCost:C2}");
            listBox1.Items.Add("");

            listBox1.Items.Add("🏆 TOP 3 BEST-SELLING PRODUCTS");
            var topSellers = _context.Products
                .AsEnumerable()
                .OrderByDescending(p => p.TotalSold)
                .Take(3)
                .ToList();

            foreach (var product in topSellers)
            {
                listBox1.Items.Add($"⭐ {product.Name}: {product.TotalSold} Units Sold");
            }
        }

        private void DrawChart()
        {
            chart1.Series.Clear();
            chart1.Titles.Clear();
            chart2.Series.Clear();
            chart2.Titles.Clear();

            Title title1 = new Title("Product-Based Sales");
            title1.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            title1.ForeColor = Color.FromArgb(44, 62, 80);
            chart1.Titles.Add(title1);

            Series series1 = new Series("Sales");
            series1.ChartType = SeriesChartType.Column;
            series1.Color = Color.FromArgb(46, 204, 113);
            series1.IsValueShownAsLabel = true;
            series1.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            var products = _context.Products.ToList();
            foreach (var product in products)
            {
                series1.Points.AddXY(product.Name, product.TotalSold);
            }
            chart1.Series.Add(series1);

            Title title2 = new Title("Category Market Share");
            title2.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            title2.ForeColor = Color.FromArgb(44, 62, 80);
            chart2.Titles.Add(title2);

            Series series2 = new Series("Categories");
            series2.ChartType = SeriesChartType.Doughnut;
            series2.IsValueShownAsLabel = true;
            series2.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            series2.LabelForeColor = Color.White;

            var categorySales = _context.Products
                .AsEnumerable()
                .GroupBy(p => p.Category)
                .Select(g => new { Category = g.Key, TotalSold = g.Sum(p => p.TotalSold) })
                .Where(c => c.TotalSold > 0)
                .ToList();

            foreach (var cat in categorySales)
            {
                series2.Points.AddXY(cat.Category, cat.TotalSold);
            }
            chart2.Series.Add(series2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
            DrawChart();
        }
    }
}