namespace Lab2;

public abstract class Shop
{
    
    public static List<string> valutaLista = new List<string>() { "SEK", "USD", "Kramar" };
    
   

    public static void Valuta()
    {
        int prodIndex = 1;
        Console.Clear();
        Console.WriteLine("Vilken valuta vill du använda?\n");

        foreach (string val in valutaLista)
        {
            Console.WriteLine($"{prodIndex}. {val}");
            prodIndex++;
        }

        
    }





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
        Console.Clear();
        
        Console.WriteLine("Vi har dessa kanonprukter!\n");
        int prodIndex = 1;
        foreach (var prod in Products.ProdList)
        {
            Console.WriteLine($"{prodIndex}. {prod.ProduktNamn}\t{prod.Pris} {Products.ValutaText}");
            prodIndex++;
        }
        Console.WriteLine("\nVilken produkt vill du köpa?");



        //Console.WriteLine("\nVilken produkt vill du köpa?\n" +
        //                  "1. Midrange\n" +
        //                  "2. Väska   \n" +
        //                  "3. Korg\n");

    }
}


