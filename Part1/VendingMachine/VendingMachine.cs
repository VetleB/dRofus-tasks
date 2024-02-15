public class VendingMachine
{
    private int money;
    private Dictionary<string, Product> stock = new Dictionary<string, Product>();

    public VendingMachine(List<Product> products) 
    {
        this.money = 0;
        this.StockProducts(products);
    }

    private void StockProducts(List<Product> products)
    {
        foreach (var product in products) 
        {
            this.stock.Add(product.Name, product);
        }
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
}