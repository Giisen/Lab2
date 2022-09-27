namespace Lab2;

public class Products
{
    private string _Name;
    public string ProductName
    {
        get { return _Name; }
        set { _Name = value; }
    }

    private decimal _Price;
    public decimal Price
    {
        get { return _Price; }
        set { _Price = value; }
    }

    public Products(string name, decimal price)
    {
        ProductName = name;
        Price = price;
        
    }
    
}