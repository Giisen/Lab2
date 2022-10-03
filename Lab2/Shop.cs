namespace Lab2;

public abstract class  Shop
{

    //public List<Products> ProdList { get; set; } // Denna tror jag inte används


    //// Skapar en lista med produkter
    //List<Products> ProdList = new List<Products>();
    //ProdList.Add(new Products("Midrange", 169, 1));
    //ProdList.Add(new Products("Väska", 999, 1));
    //ProdList.Add(new Products("korg", 1999, 1));





    public static void VisaButik()
    {
        Console.Clear();
        
        Console.WriteLine("Vad vill du göra?\n" +
                          "1. Handla i shopen\n" +
                          "2. Visa din kundvagn\n" +
                          "3. Gå till kassan\n"+
                          "4. Logga ut");
    }

    public static void Handla()
    {

        Console.WriteLine("\nVilken produkt vill du köpa?\n" +
                          "1. Midrange\n" +
                          "2. Väska   \n" +
                          "3. Korg\n");
                          
    }
}


