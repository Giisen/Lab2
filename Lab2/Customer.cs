namespace Lab2;

public class Customer
{
    private string _CustomerName;
    public string CustomerName
    {
        get { return _CustomerName; }
        set { _CustomerName = value; }
    }

    private string _CustomerPassword;
    public string CustomerPassword
    {
        get { return _CustomerPassword; }
        set { _CustomerPassword = value; }
    }

    public Customer(string name, string password)
    {
        CustomerName = name;
        CustomerPassword = password;
        
    }

    public void ToString()
    {
        Console.WriteLine($"Ditt namn : {CustomerName}");
        Console.WriteLine($"Ditt lösenord är: {CustomerPassword}");
        Console.WriteLine($"Din kunvagn består just nu av: ...Kunvagn.....");
    }
}

