using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace _20220305027
{
    public partial class MainForm : Form
    {
        AppDbContext _context = new AppDbContext();

        public MainForm()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
           
            LoadData();
            ApplyModernTheme();
            SetupTechStoreConcept();
        }

        private void SetupTechStoreConcept()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(new string[] {
                "Laptops",
                "Phones",
                "PC Components",
                "Peripherals",
                "Monitors",
                "Accessories"
            });

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["Id"].Visible = false;
                dataGridView1.Columns["Category"].HeaderText = "Category";
                dataGridView1.Columns["Name"].HeaderText = "Product Name";
                dataGridView1.Columns["Unit"].HeaderText = "Stock";
                dataGridView1.Columns["Cost"].HeaderText = "Cost ($)";
                dataGridView1.Columns["Price"].HeaderText = "Price ($)";
                dataGridView1.Columns["MinStockLevel"].HeaderText = "Min Stock";
                dataGridView1.Columns["TotalSold"].HeaderText = "Total Sold";
            }
        }

        private void LoadData()
        {
            dataGridView1.DataSource = _context.Products.ToList();
        }

        private void ApplyModernTheme()
        {
            dataGridView1.ReadOnly = true;
            this.BackColor = Color.FromArgb(245, 246, 250);
            this.Font = new Font("Segoe UI", 10);

            StyleButton(button1, Color.FromArgb(46, 204, 113));
            StyleButton(button2, Color.FromArgb(230, 126, 34));
            StyleButton(button3, Color.FromArgb(52, 152, 219));
            StyleButton(button4, Color.FromArgb(155, 89, 182));
            StyleButton(button5, Color.FromArgb(231, 76, 60));

            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersHeight = 45;

            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.RowTemplate.Height = 35;

            groupBox1.ForeColor = Color.FromArgb(44, 62, 80);
            groupBox1.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            groupBox2.ForeColor = Color.FromArgb(44, 62, 80);
            groupBox2.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        }

        private void StyleButton(Button btn, Color Background)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Background;
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please make sure to fill in the product name and category!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Product newProduct = new Product
                {
                    Category = comboBox1.Text,
                    Name = textBox1.Text,
                    Unit = Convert.ToInt32(textBox2.Text),
                    Cost = Convert.ToDecimal(textBox5.Text),
                    Price = Convert.ToDecimal(textBox3.Text),
                    MinStockLevel = Convert.ToInt32(textBox4.Text),
                    TotalSold = 0
                };

                if (newProduct.Price < newProduct.Cost)
                {
                    MessageBox.Show("Selling price cannot be lower than the cost! Cannot sell at a loss.", "Logical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _context.Products.Add(newProduct);
                _context.SaveChanges();

                LoadData();
                MessageBox.Show("Product successfully added to the system!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                textBox1.Clear(); textBox2.Clear(); textBox3.Clear();
                textBox4.Clear(); textBox5.Clear(); comboBox1.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter only numerical values in the boxes!\nDetails: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select a product to sell.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedProductId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
            var selectedProduct = _context.Products.Find(selectedProductId);

            int quantityToSell = (int)numericUpDown1.Value;

            if (quantityToSell <= 0)
            {
                MessageBox.Show("Enter an amount greater than 0 for the sale.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedProduct != null && selectedProduct.Unit >= quantityToSell)
            {
                selectedProduct.Unit -= quantityToSell;
                selectedProduct.TotalSold += quantityToSell;

                Sale newSale = new Sale
                {
                    Category = selectedProduct.Category,
                    ProductName = selectedProduct.Name,
                    Quantity = quantityToSell,
                    TotalPrice = selectedProduct.Price * quantityToSell,
                    TotalProfit = (selectedProduct.Price - selectedProduct.Cost) * quantityToSell,
                    SaleDate = DateTime.Now
                };

                _context.Sales.Add(newSale);
                _context.SaveChanges();

                numericUpDown1.Value = 0;
                LoadData();

                MessageBox.Show($"{quantityToSell} units of '{selectedProduct.Name}' sold!\nNet Profit: {newSale.TotalProfit:C2}", "Sale Confirmed");
            }
            else
            {
                MessageBox.Show("Insufficient stock!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AnalysisForm analysisForm = new AnalysisForm();
            analysisForm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SalesHistoryForm historyForm = new SalesHistoryForm();
            historyForm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.IsNewRow)
                {
                    MessageBox.Show("Please select the product you want to delete from the table.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult confirmation = MessageBox.Show("Are you sure you want to delete this product? This action cannot be undone!", "Deletion Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmation == DialogResult.Yes)
                {
                    int productId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                    var product = _context.Products.Find(productId);

                    if (product != null)
                    {
                        _context.Products.Remove(product);
                        _context.SaveChanges();

                        LoadData();
                        MessageBox.Show("Product successfully deleted.", "Information");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during deletion: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchKeyword = txtSearch.Text.ToLower();

            var filteredList = _context.Products
                .Where(p => p.Name.ToLower().Contains(searchKeyword) ||
                            p.Category.ToLower().Contains(searchKeyword))
                .ToList();

            dataGridView1.DataSource = filteredList;
        }
    }
}