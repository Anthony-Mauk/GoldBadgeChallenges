using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe
{
    public class MenuContent
    {

        public string MenuNumber { get; set; }
        public string MenuName { get; set; }
        public string MenuDescription { get; set; }
        public string MenuListOfIngredients { get; set; }
        public string MenuPrice { get; set; }

        public MenuContent() { }
        public MenuContent(string menuNumber, string menuName, string menuDescription, string menuListOfIngredients, string menuPrice)
        {
            MenuNumber = menuNumber;
            MenuName = menuName;
            MenuDescription = menuDescription;
            MenuListOfIngredients = menuListOfIngredients;
            MenuPrice = menuPrice;
        }
    }
}
