namespace Lab2;

public class Products
{
    private string _Namn;

    public string ProduktNamn
    {
        get { return _Namn; }
        set { _Namn = value; }
    }

    private double _Pris;

    public double Pris
    {
        get { return _Pris; }
        set { _Pris = Math.Round(value,2); }
    }


    private int _Antal;

    public int Antal
    {
        get { return _Antal; }
        set { _Antal = value; }
    }


    private static string _valutatext;

    public static string ValutaText
    {
        get { return _valutatext; }
        set { _valutatext = value; }
    }

    private static double _valuta;

    public static double Valuta
    {
        get { return _valuta; }
        set { _valuta = value; }
    }



    public Products(string name, double price, int antal)
    {
        _Namn = name;
        _Pris = Math.Round(price,2);
        Antal = antal;
    }

   


    // Skapar en lista med produkter
    public  static List<Products> ProdList = new List<Products>();

   public  static void CreateList(double valuta, string valutatext)
   {
       _valutatext = valutatext;
       _valuta=valuta;
       ProdList.Add(new Products("Midrange", 169, 1));
       ProdList.Add(new Products("Väska   ", 999, 1));
       ProdList.Add(new Products("Korg    ", 1999, 1));
   }
    



}
