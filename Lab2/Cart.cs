

using System.Diagnostics;
using System.Xml.Linq;

namespace Lab2;

public class Cart : Products

{
    
    public int Antal;
    public decimal TotPrisEnhet = 0;
    public decimal TotPrisKundvagn = 0;
    
    //private int _Antal;
    //public int Antal
    //{
    //    get { return _Antal; }
    //    set { _Antal = value; }
    //}


    //public  List<Cart> CList { get; set; }  // Är tvungen att göra den static av någon anledning

    //public  decimal Kassa()  // Är tvungen att göra den static av någon anledning
    //{


    //    foreach (var prod in CList) // Denna funkar inte behöver lägga till currentCart eller currentUser
    //    {
    //        TotalPris += prod.Pris;
    //    }

    //    //CartList.Clear();// Tömmer listan
    //    return TotalPris;
    //}

    // Gör denna något?
    private List<Cart> _CartList;

    public List<Cart> CartList
    {
        get { return _CartList; }
    }

    public void ToString()
    {
        //string printinfo;
        //printinfo = string.Join(" ",CartList);
        Console.WriteLine("Varför funkar inte denna");
    }


    public Cart() : base()
    {
        List<Cart> CartList = new List<Cart>();
    }


    
    public Cart(string namn, decimal pris, int antal) : base(namn, pris)
    {
        ProduktNamn = namn;
        Pris = pris;
        Antal = antal;
        TotPrisEnhet = (int)(pris * antal);
        TotPrisKundvagn+=TotalPrisEnhet;


    }


}