namespace Lab2;

public class Products
{
    private string _Namn;

    public string ProduktNamn
    {
        get { return _Namn; }
        set { _Namn = value; }
    }

    private int _Pris;

    public int Pris
    {
        get { return _Pris; }
        set { _Pris = value; }
    }


    private int _Antal;

    public int Antal
    {
        get { return _Antal; }
        set { _Antal = value; }
    }


    public Products(string name, int price, int antal)
    {
        ProduktNamn = name;
        Pris = price;
        Antal = antal;
    }
}
