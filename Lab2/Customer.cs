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

    

    public Customer(string name, string password)
    {
        _CustomerName = name;
        CustomerPassword = password;
        //List<Customer> CustomerList = new List<Customer>();
        //CustomerList.Add(new Customer("{_CustomerName}", "{CustomerPassword}"));
    }


    List<Customer> CustomerList = new List<Customer>();

    //Skapar en metod som lägger till Knatte, Fnatte och Tjatte
    public void PreCustomer()
    {
        //List<Customer> CustomerList = new List<Customer>();
        CustomerList.Add(new Customer("Knatte", "123"));
        CustomerList.Add(new Customer("Fnatte", "321"));
        CustomerList.Add(new Customer("Tjatte", "213"));
    }


    


    //Skapa en metod med ToString() som gör en sträng av namn och lösenord
    //metoden ska också skicka resultatet av ToString() till en textfil på datorn.
    // Detta löser inloggningen och ersätter troligen mina listor mm.






    //Skapar en metod som lägger till nya kunder i listan
    //public NewCustomer(string _CustomerName, string CustomerPassword)
    //{
    //    //List<Customer> CustomerList = new List<Customer>();
    //    return CustomerList.Add(new Customer("{_CustomerName}", "{CustomerPassword}"));
    //}


    public void PrintInfo()
    {
        Console.WriteLine($"Ditt namn: {CustomerName} Ditt lösenord är: {CustomerPassword} Din kunvagn består just nu av: ...Kundvagn.....");
        //return $"Ditt namn: {CustomerName} Ditt lösenord är: {CustomerPassword} Din kunvagn består just nu av: ...Kunvagn.....";
    }
}

