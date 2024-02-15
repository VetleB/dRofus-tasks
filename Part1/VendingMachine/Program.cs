bool quit = false;

while (!quit) 
{
    var userInput = Console.ReadLine()?.ToLower();
    if (userInput == "q") 
    {
        quit = true;
    }
}