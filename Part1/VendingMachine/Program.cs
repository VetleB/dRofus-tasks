bool quit = false;

while (!quit) 
{
    var vendingMachine = new VendingMachine();

    var userInput = Console.ReadLine()?.ToLower();
    
    switch (userInput)
    {
        case "q":
            quit = true;
            break;
    }
}