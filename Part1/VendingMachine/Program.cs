bool quit = false;

var products = VendingProducts.products;
var vendingMachine = new VendingMachine(products);

while (!quit) 
{
    Console.Write("> ");
    
    var userInput = Console.ReadLine()?.ToLower();
    switch (userInput)
    {
        case "list":
            Console.WriteLine($"< {vendingMachine.GetListOfProducts()}");
            break;

        case string s when s.StartsWith("insert"):
            _ = int.TryParse(s.AsSpan("insert".Length + 1), out int fundsToBeAdded);
            vendingMachine.AddFunds(fundsToBeAdded);
            Console.WriteLine($"< Current credit is {vendingMachine.GetFunds()}");
            break;
            
        case string s when s.StartsWith("recall"):
            Console.WriteLine($"< Giving out {vendingMachine.RecallFunds()}");
            break;

        case string s when s.StartsWith("order"):
            var productName = s.AsSpan("order".Length + 1).ToString().ToLower();

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
