namespace Lab2;

public class Products : Shop
{
    private string _Name;
    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }

    private string _ID;
    public string ID
    {
        get { return _ID; }
        set { _ID = value; }
    }


    private double _Price;
    public double Price
    {
        get { return _Price; }
        set { _Price = value; }
    }

    public Products(string name, double price,int id)
    {
        Name = name;
        Price = price;
        ID = ID;
    }

}