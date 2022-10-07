namespace Lab2;

public class Silver : Customer
{
    public Silver(string name, string password) : base(name, password)
    {
        Rabatt = (decimal)0.89;
    }
}