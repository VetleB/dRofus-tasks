bool quit = false;

while (!quit) 
{
    var products = VendingProducts.products;
    var vendingMachine = new VendingMachine(products);

    var userInput = Console.ReadLine()?.ToLower();

    switch (userInput)
    {
        case "list":
            Console.WriteLine("< " + vendingMachine.ListProducts());
            break;
        case "q":
            quit = true;
            break;
    }
}