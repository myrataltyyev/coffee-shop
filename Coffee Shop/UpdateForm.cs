using Newtonsoft.Json;
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

namespace Coffee_Shop
{
    public partial class UpdateForm : Form
    {
        Data data = null;
        string id = "";
        string name = "";
        string category = "";
        string price = "";
        string ingredients = "";
        public UpdateForm(Data data, string id)
        {
            InitializeComponent();
            this.data = data;
            this.id = id;
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            // Get menu item
            foreach (Menu item in data.menu)
            {
                if (item.id.Equals(this.id))
                {
                    this.name = item.name;
                    this.category = item.category;
                    this.price = item.price;
                    this.ingredients = item.ingredients;
                    break;
                }
            }

            // Set values to components
            txtName.Text = this.name;
            comboCategory.SelectedItem = this.category;
            txtPrice.Text = this.price.Split()[0];
            txtIngredients.Text = this.ingredients;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            // Get value from name textbox
            if (txtName.Text.Equals(""))
            {
                errorProvider.SetError(txtName, "Please write name");
                return;
            }
            else
                name = txtName.Text;

            // Get value from price textbox
            if (txtPrice.Text.Equals(""))
            {
                errorProvider.SetError(txtPrice, "Please write name");
                return;
            }
            else
            {
                try
                {
                    double dPrice = double.Parse(txtPrice.Text);
                    price = dPrice + " TL";
                }
                catch (Exception exc)
                {
                    Console.WriteLine("Couldn't convert to double");
                    MessageBox.Show("Please type valid price!", "Wrong input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Get value from ingredients textbox
            if (txtIngredients.Text.Equals(""))
            {
                errorProvider.SetError(txtIngredients, "Please write name");
                return;
            }
            else
                ingredients = txtIngredients.Text;

            // Get value from category combobox
            category = comboCategory.SelectedItem.ToString();

            foreach (Menu item in data.menu)
            {
                if (item.id.Equals(this.id))
                {
                    item.name = this.name;
                    item.category = this.category;
                    item.price = this.price;
                    item.ingredients = this.ingredients;
                }
            }

            string updatedData = JsonConvert.SerializeObject(data, Formatting.Indented);
            Console.WriteLine(updatedData);

            using (StreamWriter sw = File.CreateText(FormMain.filePath))
            {
                sw.WriteLine(updatedData);
            }

            this.Close();
        }

        private void TxtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void TxtName_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void TxtPrice_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void TxtIngredients_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }
    }
}
