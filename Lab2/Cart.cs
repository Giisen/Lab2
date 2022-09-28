using System.Xml;

namespace Lab2;

public class Cart

{
    public string Namn;
    public decimal Pris;
    public int Antal;
    decimal TotalPris = 0;
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

    

   public Cart(string namn, decimal pris, int antal,int totalpris)
   {
        Namn=namn;
        Pris = pris;
        Antal = antal;
        TotalPris = totalpris;

   }

   
}