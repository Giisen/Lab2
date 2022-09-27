using System.Xml;

namespace Lab2;

public class Cart

{
    public string Namn;
    public decimal Pris;
    public int Antal;
    public static List<Cart> CList { get; set; }  // Är tvungen att göra den static av någon anledning

    public static decimal Kassa()  // Är tvungen att göra den static av någon anledning
    {
        decimal totalPris = 0;

        foreach (var prod in Cart.CList)
        {
            totalPris += prod.Pris;
        }

        //CartList.Clear();// Tömmer listan
        return totalPris;
    }

    

   public Cart(string namn, decimal pris, int antal)
   {
        Namn=namn;
        Pris = pris;
        Antal = antal;
    }

   
}