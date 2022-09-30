namespace Lab2;

public class Shop
{

    public List<Products> ProductsList { get; set; }
    
    

    public static void VisaButik()
    {
        Console.Clear();
        //Console.WriteLine("Välkommen in!\n");
        Console.WriteLine("Vad vill du göra?\n" +
                          "1. Handla i shopen\n" +
                          "2. Visa din kundvagn\n" +
                          "3. Gå till kassan");
    }

    public static void Handla()
    {

        Console.WriteLine("\nVilken produkt vill du köpa?\n" +
                          "1. Midrange\n" +
                          "2. Väska\n" +
                          "3. Korg\n");
                          
    }
}


