bool quit = false;

var products = VendingProducts.products;
var vendingMachine = new VendingMachine(products);
var commands = vendingMachine.GetCommands();

while (!quit) 
{
    var userInput = Console.ReadLine()?.ToLower();

    switch (userInput)
    {
        case "list":
            Console.WriteLine($"< {vendingMachine.ListProducts()}");
            break;
        case string s when s.StartsWith(commands["addFunds"]):
            int.TryParse(s.Substring(commands["addFunds"].Length), out int funds);
            vendingMachine.AddFunds(funds);
            Console.WriteLine($"Current creadit is {vendingMachine.GetFunds()}");
            break;
        case "q":
            quit = true;
            break;
    }
}