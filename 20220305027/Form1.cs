using System;
using System.Linq;
using System.Windows.Forms;

namespace _20220305027
{
    public partial class Form1 : Form
    {
       
        AppDbContext _context = new AppDbContext();

        public Form1()
        {
            InitializeComponent();



    
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username and password cannot be empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            try
            {
              
                var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

                if (user != null)
                {
                   
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                   
                    MessageBox.Show("Invalid username or password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred connecting to the database: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
