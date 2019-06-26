using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MakeMeFat
{
    internal class ServeMaxCallories : IServerCustomer
    {
        private readonly ILogger<ServeMaxCallories> _logger;

        public ServeMaxCallories(ILogger<ServeMaxCallories> logger)
        {
            _logger = logger;
        }

        //internal new void ServerCustomer(Menu menu)
        //{
        //    Console.WriteLine("How much money Does Customer Have");
        //    var money = Console.ReadLine().Trim();
        //    if (string.IsNullOrEmpty(money)) return;
        //    Int32.TryParse(money, out int currencey);
        //    _logger.LogInformation($"Customer have {money} Rupes");
        //    if (currencey < 0) return;
        //    var itemsSorted = menu.ItemsListCalories.OrderByDescending(x => x.Value).ToList();
        //    for (int i = 0; i < itemsSorted.Count; i++)
        //    {
        //        Item item = null;
        //        menu.Items.TryGetValue(itemsSorted[i].Key, out item);
        //        if (currencey <= item.Price) continue;
        //        int count = currencey / item.Price;
        //        currencey = currencey % item.Price;
        //        Console.Write($"we will serve them {item.Name} X {count} ");
        //        Console.WriteLine(Environment.NewLine);
        //    }
        //}
    }

    class x : ICloneable, IServerCustomer
    {
        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}