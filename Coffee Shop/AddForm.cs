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

namespace Coffee_Shop
{
    public partial class AddForm : Form
    {
        string name, category, price, ingredients;
        Data data = null;
        int autoID = FormMain.autoID;
        FormMain formMain;

        public AddForm(Data data)
        {
            InitializeComponent();
            this.data = data;
        }

        private void TxtPrice_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            comboCategory.SelectedIndex = 0;
        }

        private void TxtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void TxtIngredients_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void TxtName_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
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

            // According to category create new item
            switch (comboCategory.SelectedIndex)
            {
                case 0:
                    data.menu.Add(new Menu(autoID.ToString(), name, category, price, ingredients));
                    break;
                case 1:
                    data.menu.Add(new Menu(autoID.ToString(), name, category, price, ingredients));
                    break;
                case 2:
                    data.menu.Add(new Menu(autoID.ToString(), name, category, price, ingredients));
                    break;
                case 3:
                    data.menu.Add(new Menu(autoID.ToString(), name, category, price, ingredients));
                    break;
                default:
                    Console.WriteLine("Nothing is created");
                    break;
            }

            string newData = JsonConvert.SerializeObject(data, Formatting.Indented);
            Console.WriteLine(newData);

            using (StreamWriter sw = File.CreateText(FormMain.filePath))
            {
                sw.WriteLine(newData);
            }

            FormMain.autoID = ++autoID;
            
            this.Close();
        }
    }
}
