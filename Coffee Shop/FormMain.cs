using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Coffee_Shop
{
    public partial class FormMain : Form
    {
        public static string filePath = @"C:\Users\Myrat\source\repos\Coffee Shop\Coffee Shop\data.json";
        private double price = 0;
        private Data data = null;
        public static int autoID = 0;
        string strJSON = "";

        public FormMain()
        {
            InitializeComponent();
            // Disable labels
            lblName.Text = "";
            lblCategory.Text = "";
            lblPrice.Text = "";

            // Set titles for columns
            listViewMenu.Columns.Add("ID", 30, HorizontalAlignment.Center);
            listViewMenu.Columns.Add("Name", 160, HorizontalAlignment.Center);
            listViewMenu.Columns.Add("Category", 190, HorizontalAlignment.Center);
            listViewMenu.Columns.Add("Price", 100, HorizontalAlignment.Center);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            

            // Read JSON file and retrieve data
            if (File.Exists(filePath))
            {
                strJSON = File.ReadAllText(filePath);
            }
            else
            {
                MessageBox.Show("File doesn't exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            JObject objJSON = JObject.Parse(strJSON);
            JArray menuArrayJSON = (JArray) objJSON["menu"];

            // Create data object
            data = new Data
            {
                menu = new List<Menu>()
            };

            // Populate menu list
            for (int i = 0; i < menuArrayJSON.Count; i++)
            {
                data.menu.Add(
                    new Menu(
                        (string)menuArrayJSON[i]["id"],
                        (string)menuArrayJSON[i]["name"],
                        (string)menuArrayJSON[i]["category"],
                        (string)menuArrayJSON[i]["price"],
                        (string)menuArrayJSON[i]["ingredients"],
                        (string)menuArrayJSON[i]["image"]
                    )
                );
            }

            // Add menu list into listview
            foreach (Menu item in data.menu)
            {
                ListViewItem id = new ListViewItem(item.id);
                ListViewItem.ListViewSubItem name = new ListViewItem.ListViewSubItem(id, item.name);
                ListViewItem.ListViewSubItem category = new ListViewItem.ListViewSubItem(id, item.category);
                ListViewItem.ListViewSubItem price = new ListViewItem.ListViewSubItem(id, item.price);
                id.SubItems.Add(name);
                id.SubItems.Add(category);
                id.SubItems.Add(price);
                listViewMenu.Items.Add(id);
            }

            autoID = data.menu.Count + 1;
        }

        private void ListViewMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblName.Text = listViewMenu.FocusedItem.SubItems[1].Text;
            lblCategory.Text = listViewMenu.FocusedItem.SubItems[2].Text;

            calculatePrice();

            int selectedId = int.Parse(listViewMenu.FocusedItem.SubItems[0].Text);
            try
            {
                if (data.menu[selectedId - 1].image != null)
                    pictureCoffee.Image = new Bitmap(data.menu[selectedId - 1].image);
                else
                    pictureCoffee.Image = new Bitmap("");
            }
            catch (Exception exc)
            {
                Console.WriteLine("Couldn't read image file");
            }
        }

        private void RadioBtnSmall_CheckedChanged(object sender, EventArgs e)
        {
            calculatePrice();
        }

        private void RadioBtnMedium_CheckedChanged(object sender, EventArgs e)
        {
            calculatePrice();
        }

        private void RadioBtnLarge_CheckedChanged(object sender, EventArgs e)
        {
            calculatePrice();
        }

        public void calculatePrice()
        {
            try
            {
                price = double.Parse(listViewMenu.FocusedItem.SubItems[3].Text.Split()[0]);
            }
            catch (Exception exc)
            {
                Console.WriteLine("Couldn't convert string into double");
            }

            if (radioBtnSmall.Checked == true)
                price = price - price * 0.1;
            else if (radioBtnLarge.Checked == true)
                price = price + price * 0.1;

            lblPrice.Text = price.ToString();
        }

        private void BtnIngredients_Click(object sender, EventArgs e)
        {
            int index = int.Parse(listViewMenu.FocusedItem.SubItems[0].Text);
            string name = data.menu[index - 1].name;
            string ingredients = data.menu[index - 1].ingredients;

            IngredientsForm ingredientsForm = new IngredientsForm(name, ingredients);
            ingredientsForm.Show();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm(data);
            addForm.Show();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            string id = listViewMenu.FocusedItem.SubItems[0].Text;

            UpdateForm updateForm = new UpdateForm(data, id);
            updateForm.Show();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(listViewMenu.FocusedItem.SubItems[0].Text);
            data.menu.RemoveAt(id - 1);
            autoID--;

            string deletedData = JsonConvert.SerializeObject(data, Formatting.Indented);
            Console.WriteLine(deletedData);

            using (StreamWriter sw = File.CreateText(FormMain.filePath))
            {
                sw.WriteLine(deletedData);
            }

            lblName.Text = "";
            lblCategory.Text = "";
            lblPrice.Text = "";

            listViewMenu.Items.Clear();
            FormMain_Load(sender, e);
        }

        private void FormMain_Activated(object sender, EventArgs e)
        {
            listViewMenu.Items.Clear();
            FormMain_Load(sender, e);
        }

        private void BtnUpload_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm(data);
            loginForm.Show();
        }
    }
}
