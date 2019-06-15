using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public partial class AdminForm : Form
    {
        Data data = null;
        string filePath = FormMain.filePath;
        string strJSON;

        public AdminForm(Data data)
        {
            InitializeComponent();
            this.data = data;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            // Set titles for columns
            listViewMenu.Columns.Add("ID", 30, HorizontalAlignment.Center);
            listViewMenu.Columns.Add("Name", 160, HorizontalAlignment.Center);
            listViewMenu.Columns.Add("Category", 190, HorizontalAlignment.Center);
            listViewMenu.Columns.Add("Price", 100, HorizontalAlignment.Center);

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
            JArray menuArrayJSON = (JArray)objJSON["menu"];

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
        }

        private void BtnUpload_Click(object sender, EventArgs e)
        {
            int selectedId = int.Parse(listViewMenu.FocusedItem.SubItems[0].Text);

            // Upload image
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureCoffee.Image = new Bitmap(openFileDialog.FileName);
                data.menu[selectedId - 1].image = openFileDialog.FileName;
            }

            string updatedData = JsonConvert.SerializeObject(data, Formatting.Indented);
            Console.WriteLine(updatedData);

            using (StreamWriter sw = File.CreateText(FormMain.filePath))
            {
                sw.WriteLine(updatedData);
            }
        }

        private void ListViewMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedId = int.Parse(listViewMenu.FocusedItem.SubItems[0].Text);
            try
            {
                pictureCoffee.Image = new Bitmap(data.menu[selectedId - 1].image);
            }
            catch (Exception exc)
            {
                Console.WriteLine("Couldn't read image file");
            }
        }
    }
}
