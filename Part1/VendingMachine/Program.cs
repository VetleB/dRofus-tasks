bool quit = false;

var products = VendingProducts.products;
var vendingMachine = new VendingMachine(products);
var commands = vendingMachine.GetCommands();

while (!quit) 
{
    Console.Write("> ");
    
    var userInput = Console.ReadLine()?.ToLower();
    switch (userInput)
    {
        case string s when s.StartsWith(commands["listInventory"]):
            Console.WriteLine($"< {vendingMachine.GetListOfProducts()}");
            break;

        case string s when s.StartsWith(commands["addFunds"]):
            _ = int.TryParse(s.AsSpan(commands["addFunds"].Length + 1), out int funds);
            vendingMachine.AddFunds(funds);
            Console.WriteLine($"< Current credit is {vendingMachine.GetFunds()}");
            break;
            
        case string s when s.StartsWith(commands["recallFunds"]):
            Console.WriteLine($"< Giving out {vendingMachine.RecallFunds()}");
            break;

        case string s when s.StartsWith(commands["orderProduct"]):
            var productName = s.AsSpan(commands["orderProduct"].Length + 1).ToString().ToLower();

            if (!vendingMachine.CheckIfProductInStock(productName))
                break;

            var missingFunds = vendingMachine.MissingFunds(productName);
            if (missingFunds > 0)
            {
                Console.WriteLine($"< Not enough credit, need {missingFunds} more");
                break;
            }

            var (product, fundsReturned) = vendingMachine.OrderProduct(productName);
            Console.WriteLine($"< Giving out {product}. Giving back change of {fundsReturned}");

            break;

        case "q":
            quit = true;
            break;
            
        default:
            Console.WriteLine("< Unknown Command");
            break;
    }
}
