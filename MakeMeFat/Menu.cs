
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MakeMeFat
{
    class Menu
    {
        public Dictionary<int, Item> Items { get; set; }
        public Dictionary<int, decimal> ItemsListCalories { get; set; }

        public int MyProperty { get; set; }

        private readonly ILogger<Menu> _logger;
        public Menu(ILogger<Menu> logger)
        {
            _logger = logger;
            Items = new Dictionary<int, Item>();
            ItemsListCalories = new Dictionary<int, decimal>();
        }

        internal bool CraeteMenu(string input)
        {
            
            var entires = input.Split(",");
            int id = 0;
            if (!Int32.TryParse(entires[0], out id))
            {
                return false;
            }
            if (Items.ContainsKey(id))
            {
                Console.WriteLine(" Item already exist . Do you want to update Price ?");
                var response = Console.ReadLine();
                if (response == "Yes")
                {
                    UpdatePrice();
                    return true;
                }
                else
                    return false;  
            }
            Item item = new Item();
            item.ID = id;
            item.Name = entires[1];
            var price =0;
            if(Int32.TryParse(entires[2], out price))
            {
                item.Price = price;
            }
            else
            {
                return false;
            }
            var calories = 0;
            if (Int32.TryParse(entires[3], out calories))
            {
                item.Calories = calories;
            }
            else
            {
                return false;
            }
            var CaloriesPerRupies = (decimal)item.Calories / item.Price;
            Items.Add(id, item);
            ItemsListCalories.Add(id, CaloriesPerRupies);
            return true;
        }

       internal void PrintMenu()
        {
            foreach (var entry in Items)
            {
                var item = entry.Value;
                Console.WriteLine($"{item.Name} for {item.Price} bucks contains {item.Calories} Calories");
            }
        }


        internal void UpdatePrice()
        {
            Console.WriteLine("EnterId,Price");
            var input = Console.ReadLine();
            var entires = input.Split(",");
            int id = Int32.Parse(entires[0]);
            var item = Items[id];
            item.Price = Int32.Parse(entires[1]);
        }
        
    }
}
