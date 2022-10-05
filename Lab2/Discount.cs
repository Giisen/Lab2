using System.ComponentModel.Design;
using System.Net.Http.Headers;
using System.Xml;
using System.Xml.Linq;

namespace Lab2;

//public class Discount : Customer
//{

//    private  string _Nivå;
//    public  string Nivå
//    {
//        get { return _Nivå; }
//        set
//        {
//            _Nivå = value;
//            if (KundvagnTotal() > 2000)
//            {
//                value = "Bronze";
//            }
//            else if (KundvagnTotal() > 3000)
//            {
//                value = "Silver";
//            }

//            else if (KundvagnTotal() > 5000)
//            {
//                value = "Gold";
//            }
//            else
//            {
//                value = string.Empty;
//            };
//        }
//    }


//    private  double _Rabatt;
//    public  double Rabatt
//    {
//        get { return _Rabatt; }
//        set { _Rabatt = value; }
//    }

    //public Discount()
    //{
    //    _Nivå = "Gold";
    //    _Rabatt = -0.10;
    //}


    //public double Discount()
    //{
        
    //    if (KundvagnTotal() > 2000)
    //    {
    //        _Rabatt = -0.05;
    //    }
    //    else if (KundvagnTotal() > 3000)
    //    {
    //        _Rabatt = -0.10;
    //    }

    //    else if (KundvagnTotal() > 5000)
    //    {
    //        _Rabatt = -0.15;
    //    }
    //    else
    //    {
    //        _Rabatt = 0;
    //    }

    //    return Rabatt;
    //}

    //public override void Discounts()
    //{
    //    Console.WriteLine(Nivå);
    //    Console.WriteLine(Rabatt);
    //}





        //    private double discount = 0;
        //    public override void Discounts()

    //{
    //    if (KundvagnTotal() > 2000)
    //    {
    //        discount = KundvagnTotal() * 0.05;
    //    }
    //    else if (KundvagnTotal() > 3000)
    //    {
    //        discount = KundvagnTotal() * 0.10;
    //    }

    //    else if (KundvagnTotal() > 5000)
    //    {
    //        discount = KundvagnTotal() * 0.15;
    //    }
    //    else
    //    {
    //        discount = 0;
    //    }

    //    Console.WriteLine(discount);

    //}


    //public Discount(string name, string password) : base(name, password)
    //{
    //}


    
//}