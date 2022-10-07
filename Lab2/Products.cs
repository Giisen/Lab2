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


    private static string _valutatext;

    public static string ValutaText
    {
        get { return _valutatext; }
        set { _valutatext = value; }
    }



    public Products(string name, int price, int antal)
    {
        ProduktNamn = name;
        Pris = price;
        Antal = antal;
    }

   


    // Skapar en lista med produkter
    public static List<Products> ProdList = new List<Products>();

   public static void CreateList(int valuta, string valutatext)
   {
       _valutatext = valutatext;
       ProdList.Add(new Products("Midrange", 169*valuta, 1));
       ProdList.Add(new Products("Väska   ", 999*valuta, 1));
       ProdList.Add(new Products("Korg    ", 1999*valuta, 1));
   }
    



}
