public class Product
{
    private readonly string name;
    private readonly int price;

    public Product(string name, int price) 
    {
        this.name = name;
        this.price = price;
    }

    public string Name => this.name;

    public int Price => this.price;
}