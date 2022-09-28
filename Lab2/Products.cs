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

    private int _Antal;
    public int Antal
    {
        get { return _Antal; }
        set { _Antal = value; }
    }

    public int TotalPrisEnhet;


    public Products(string name, decimal price, int antal,int totalprisenhet)
    {
        ProductName = name;
        Price = price;
        Antal=antal;
        totalprisenhet = (int)(price * antal);
        TotalPrisEnhet = totalprisenhet;


    }

}