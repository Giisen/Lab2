

using System.Diagnostics;
using System.Xml.Linq;

namespace Lab2;

public class Cart : Products

{
    
    public int Antal;
    public decimal TotPrisEnhet = 0;
    public decimal TotPrisKundvagn = 0;
    
    

    // Gör denna något?
    //private List<Cart> _CartList;

    //public List<Cart> CartList
    //{
    //    get { return _CartList; }
    //}

    //public override string ToString()
    //{
    //    return "Kundvagn:" + CartList;
    //}


    //public Cart() : base()
    //{
    //    List<Cart> CartList = new List<Cart>();
    //}


    
    public Cart(string namn, decimal pris, int antal) : base(namn, pris)
    {
        ProduktNamn = namn;
        Pris = pris;
        Antal = antal;
        TotPrisEnhet = (int)(pris * antal);
        TotPrisKundvagn+=TotalPrisEnhet;


    }


}