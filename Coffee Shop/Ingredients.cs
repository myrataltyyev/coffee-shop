using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee_Shop
{
    public partial class IngredientsForm : Form
    {
        private string name, ingredients;

        public IngredientsForm(string name, string ingredients)
        {
            InitializeComponent();
            this.name = name;
            this.ingredients = ingredients;
        }

        private void IngredientsForm_Load(object sender, EventArgs e)
        {
            lblName.Text = this.name;
            txtIngredients.Text = this.ingredients;
        }
    }
}
