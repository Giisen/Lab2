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


    public Products(string name, decimal price, int antal)
    {
        ProductName = name;
        Price = price;
        Antal=antal;
        

    }

    protected Products()
    {
        //throw new NotImplementedException();
    }

    //protected Products()
    //{
    //    //throw new NotImplementedException();
    //}
}