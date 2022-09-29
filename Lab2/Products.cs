namespace Lab2;

public class Products
{
    private string _Namn;
    public string ProduktNamn
    {
        get { return _Namn; }
        set { _Namn = value; }
    }

    private decimal _Pris;
    public decimal Pris
    {
        get { return _Pris; }
        set { _Pris = value; }
    }

    // Känns konstigt att tilldela antal när man skapar en ny produkt
    //private int _Antal;
    //public int Antal
    //{
    //    get { return _Antal; }
    //    set { _Antal = value; }
    //}

    public int TotalPrisEnhet;


    public Products(string name, decimal price)
    {
        ProduktNamn = name;
        Pris = price;
        //Antal=antal;
        //totalprisenhet = (int)(price * antal);
        //TotalPrisEnhet = totalprisenhet;


    }

    protected Products() //Denna fattar jag inte
    {
        //throw new NotImplementedException();
    }

    public virtual string ToString()
    {
        throw new NotImplementedException();
    }
}