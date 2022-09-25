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
        
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Ditt namn: {CustomerName} Ditt lösenord är: {CustomerPassword} Din kunvagn består just nu av: ...Kunvagn.....");
        //return $"Ditt namn: {CustomerName} Ditt lösenord är: {CustomerPassword} Din kunvagn består just nu av: ...Kunvagn.....";
    }
}

