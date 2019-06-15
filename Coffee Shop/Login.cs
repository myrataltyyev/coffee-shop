using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static Coffee_Shop.Admin;

namespace Coffee_Shop
{
    public partial class LoginForm : Form
    {
        Data data = null;
        private string username;
        private string password;
        private string filePath = @"C:\Users\Myrat\source\repos\Coffee Shop\Coffee Shop\login.json";
        private string strJSON = null;

        public LoginForm(Data data)
        {
            InitializeComponent();
            this.data = data;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            validateInput();

            // Read JSON file and retrieve data
            if (File.Exists(filePath))
            {
                strJSON = File.ReadAllText(filePath);
            }
            else
            {
                MessageBox.Show("File doesn't exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Create credentials object using JSON object
            JObject objJSON = JObject.Parse(strJSON);
            Credentials credentials = new Credentials();
            credentials.username = objJSON["username"].ToString();
            credentials.password = objJSON["password"].ToString();

            // Get values from textboxes
            this.username = txtUsername.Text;
            this.password = txtPassword.Text;

            if (username.Equals(credentials.username) && password.Equals(credentials.password))
            {
                AdminForm adminForm = new AdminForm(data);
                adminForm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect username or password", "Wrong credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void validateInput()
        {
            username = txtUsername.Text.ToString();
            password = txtPassword.Text.ToString();

            if (username.Equals(""))
            {
                errorProvider.SetError(txtUsername, "Enter username");
                return;
            }
            else if (password.Equals(""))
            {
                errorProvider.SetError(txtPassword, "Enter password");
                return;
            }
        }

        private void TxtUsername_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
