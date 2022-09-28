

namespace Lab2;

public class Cart:Products

{
    //public string Namn;
    //public decimal Pris;
    public int Antal;
    public decimal TotalPris = 0;
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


    private List<Products> _CartList;

    public List<Products> CartList
    {
        get { return _CartList; }
    }



    public Cart(string namn, decimal pris, int antal, int totalpris) : base()
   {
        ProductName = namn;
        Price = pris;
        Antal = antal;
        totalpris = (int)(pris * antal);
        TotalPris = totalpris;
        

   }

   
}