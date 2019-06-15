using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_Shop
{

    public class Data
    {
        public List<Menu> menu { get; set; }
    }

    public class Menu
    {
        public string id { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public string price { get; set; }
        public string ingredients { get; set; }
        public string image { get; set; }
        public Menu(string id, string name, string category, string price, string ingredients, string image)
        {
            this.id = id;
            this.name = name;
            this.category = category;
            this.price = price;
            this.ingredients = ingredients;
            this.image = image;
        }

        public Menu(string id, string name, string category, string price, string ingredients)
        {
            this.id = id;
            this.name = name;
            this.category = category;
            this.price = price;
            this.ingredients = ingredients;
            this.image = "Coffee Shop\\Images\\no.png";
        }
    }

}
