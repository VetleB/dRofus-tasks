bool quit = false;

var products = VendingProducts.products;
var vendingMachine = new VendingMachine(products);
var commands = vendingMachine.GetCommands();

while (!quit) 
{
    var userInput = Console.ReadLine()?.ToLower();

    switch (userInput)
    {
        case string s when s.StartsWith(commands["listInventory"]):
            Console.WriteLine($"< {vendingMachine.ListProducts()}");
            break;
        case string s when s.StartsWith(commands["addFunds"]):
            int.TryParse(s.AsSpan(commands["addFunds"].Length), out int funds);
            vendingMachine.AddFunds(funds);
            Console.WriteLine($"Current creadit is {vendingMachine.GetFunds()}");
            break;
        case string s when s.StartsWith(commands["recallFunds"]):
            Console.WriteLine($"Giving out {vendingMachine.RecallFunds()}");
            break;
        case "q":
            quit = true;
            break;
    }
}