public class VendingMachine
{
    private int money;
    private Dictionary<string, Product> stock = new Dictionary<string, Product>();
    private readonly Dictionary<string, string> commands = new Dictionary<string, string>
    {
        { "listInventory", "list" },
        { "addFunds", "insert" },
        { "recallFunds", "recall" }
    };

    public VendingMachine(List<Product> products) 
    {
        this.money = 0;
        this.StockProducts(products);
    }


    public void AddFunds(int fundsToAdd) 
    {
        this.money += fundsToAdd;
    }

    public int RecallFunds() 
    {
        var fundsToReturn = this.money;
        this.money = 0;
        return fundsToReturn;
    }

    public string ListProducts()
    {
        var outString = "";

        foreach (var product in stock.Values)
        {
            outString += $"{product.Name} - {product.Price}, ";
        }

        return outString.Substring(0, outString.Length - 2);
    }

    public Dictionary<string, string> GetCommands() 
    {
        return this.commands;
    }

    public int GetFunds()
    {
        return this.money;
    }

    private void StockProducts(List<Product> products)
    {
        foreach (var product in products) 
        {
            this.stock.Add(product.Name, product);
        }
    }
}