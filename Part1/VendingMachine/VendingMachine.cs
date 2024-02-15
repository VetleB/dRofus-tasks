public class VendingMachine
{
    private int money;
    private Dictionary<string, Product> stock = new Dictionary<string, Product>();
    private readonly Dictionary<string, string> commands = new Dictionary<string, string>
    {
        { "listInventory", "list" },
        { "addFunds", "insert" },
        { "recallFunds", "recall" },
        { "orderProduct", "order" }
    };

    public VendingMachine(List<Product> products) 
    {
        this.money = 0;
        this.StockProducts(products);
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

    public bool CheckIfProductInStock(string name) 
    {
        return this.stock.ContainsKey(name);
    }

    public int MissingFunds(string name) 
    {
        var product = this.stock[name];
        return product.Price - this.money;
    }

    public (string, int) OrderProduct(string name) 
    {
        var product = this.stock[name];

        if (this.money < product.Price)
            throw new Exception("Not enough money");
        
        var fundsReturned = this.money - product.Price;
        this.money = 0;
        return (product.Name, fundsReturned);
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
            this.stock.Add(product.Name.ToLower(), product);
        }
    }
}