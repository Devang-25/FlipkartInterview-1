using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakeMeFat
{
    class UserDashBoard
    {
        private readonly ILogger<UserDashBoard> _logger;
        private Menu _menu;

        public UserDashBoard(ILogger<UserDashBoard> logger,Menu menu)
        {
            _logger = logger;
            _menu = menu;
        }

       internal void DoWork()
        {
            bool falg= true;
            while (falg)
            {
                Console.WriteLine(Environment.NewLine);
                var input = TakeUserInput();
                _logger.LogInformation($"User Selected : {input}");

                if (Helper.ValidateInput(input))
                {
                    switch (input)
                    {
                        case "a":
                        case "A":
                            Console.WriteLine("EnterId,Name ,Price, Calories Count");
                            var itemInput = Console.ReadLine();
                            if (Helper.ValidateItem(itemInput))
                            {
                                if (_menu.CraeteMenu(itemInput))
                                {
                                    Console.WriteLine("Success");
                                }
                            }
                            break;
                        case "b":
                        case "B":
                            _menu.UpdatePrice();
                            break;
                        case "c":
                        case "C":
                            var serverCustomer= Program.servicesProvider.GetRequiredService<ServeMaxCallories>();
                            serverCustomer.ServerCustomer(_menu);
                            break;
                        case "d":
                        case "D":
                            _menu.PrintMenu();
                            break;
                        default:
                        case "e":
                        case "E":
                            falg = false;
                            Console.WriteLine(" PLease give your feedback");

                            break;

                    }
                }
                else
                {
                    _logger.LogError($"User Selected wrong input : {input}");
                }
            }
        }

        static void DisplayInput()
        {
            Console.WriteLine("What would you like to  do :");
            Console.WriteLine(" a: Create menu item");
            Console.WriteLine(" b: Update priceof menu");
            Console.WriteLine(" c: Serve CUstomer");
            Console.WriteLine(" d:Print Menu");
        }

        static string TakeUserInput()
        {
            DisplayInput();
            string customerInput = "Your input : ";
            Console.WriteLine(customerInput);
            var input = Console.ReadLine();
            return input.Trim();
        }

    }
}
