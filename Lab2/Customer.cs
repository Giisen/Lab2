namespace Lab2;

public class Customer
{
    private readonly string _CustomerName;
    public string CustomerName
    {
        get { return _CustomerName; }
        
    }

    private string _CustomerPassword;
    public string CustomerPassword
    {
        get { return _CustomerPassword; }
        set { _CustomerPassword = value; }
    }

    
    private bool _logInOk;
    public bool logInOk

    {
        get { return _logInOk; }
        set { _logInOk = value; }
    }
    
    public bool TestLogin(bool namn,string password)
    {

        if (namn == true && password==CustomerPassword)
        {
            logInOk = true;
            
        }
        return logInOk;
    }


    public static void CustomerMeny()
    {
        Console.Clear();
        Console.WriteLine("\nAnvändaren finns inte, vill du skapa en ny användare?\n" +
                          "1 för att skapa ny användare\n" +
                          "2 för att försöka logga in igen\n" +
                          "3 för att stänga programmet.");
    }
    
    public Customer(string name, string password)
    {
        _CustomerName = name;
        CustomerPassword = password;
        
    }
    



    //Skapa en metod med ToString() som gör en sträng av namn och lösenord
    //metoden ska också skicka resultatet av ToString() till en textfil på datorn.
    // Detta löser inloggningen och ersätter troligen mina listor mm.


    //public override string  ToString()
    //{
    //    string printInfo = Console.WriteLine($"Ditt namn: {CustomerName} Ditt lösenord är: {CustomerPassword} Din kunvagn består just nu av: ...Kundvagn.....");
    //    return printInfo;
        
    //}
}

