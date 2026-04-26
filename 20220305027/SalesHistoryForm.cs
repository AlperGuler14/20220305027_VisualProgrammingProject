using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace _20220305027
{
    public partial class SalesHistoryForm : Form
    {
        AppDbContext _context = new AppDbContext();

        public SalesHistoryForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void SalesHistoryForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _context.Sales.OrderByDescending(x => x.SaleDate).ToList();

            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["Id"].HeaderText = "Transaction ID";
                dataGridView1.Columns["Category"].HeaderText = "Category";
                dataGridView1.Columns["ProductName"].HeaderText = "Product Name";
                dataGridView1.Columns["Quantity"].HeaderText = "Quantity Sold";
                dataGridView1.Columns["TotalPrice"].HeaderText = "Total Amount";
                dataGridView1.Columns["TotalProfit"].HeaderText = "Net Profit";
                dataGridView1.Columns["SaleDate"].HeaderText = "Transaction Date";

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                ApplyModernGridTheme();
            }
        }

        private void ApplyModernGridTheme()
        {
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dataGridView1.RowHeadersVisible = false;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersHeight = 45;

            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridView1.RowTemplate.Height = 40;

            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 235, 255);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
        }
    }
}