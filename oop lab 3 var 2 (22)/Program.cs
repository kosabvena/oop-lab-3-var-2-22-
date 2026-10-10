using System;

interface IParent
{
    string Info();
    void Metod();
}

class Child1 : IParent, IComparable
{
    public string pole1;  
    public double pole2;  
    public string Pole3;  

    public Child1(string name, string paperQuality)
    {
        pole1 = name;
        Pole3 = paperQuality;
    }

    public void Metod()
    {
        if (Pole3 == "high")
            pole2 = 200;
        else
            pole2 = 100;
    }

    public string Info()
    {
        return $"журнал бумага={Pole3} цена={pole2:F2}";
    }

    public int CompareTo(object o)
    {
        Child1 other = o as Child1;
        this.Metod();
        other.Metod();
        return pole2.CompareTo(other.pole2);
    }
}

class Child2 : IParent, IComparable
{
    public string pole1; 
    public double pole2; 
    public string Pole4;  
    public int Pole5;    

    public Child2(string name, string coverType, int pages)
    {
        pole1 = name;
        Pole4 = coverType;
        Pole5 = pages;
    }

    public void Metod()
    {
        pole2 = Pole5 * 0.2;

        if (Pole4 == "hard")
            pole2 += 15;
        else
            pole2 += 5;
    }

    public string Info()
    {
        return $"книга обложка={Pole4} страниц={Pole5} цена={pole2:F2}";
    }

    public int CompareTo(object o)
    {
        Child2 other = o as Child2;
        return Pole5.CompareTo(other.Pole5);
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8; 
        Random rnd = new Random();

        Child1[] a = new Child1[3];
        Console.WriteLine("------журнал-----");
        for (int i = 0; i < 3; i++)
        {
            string paper = rnd.Next(2) == 0 ? "high" : "low";
            a[i] = new Child1("Journal_" + i, paper);
            a[i].Metod();
            Console.WriteLine(a[i].Info());
        }

        Array.Sort(a);
        Console.WriteLine("--сортировка по цене-");
        for (int i = 0; i < 3; i++)
        {
            a[i].Metod();
            Console.WriteLine(a[i].Info());
        }

        Child2[] b = new Child2[3];
        Console.WriteLine("---книга---");
        for (int i = 0; i < 3; i++)
        {
            string cover = rnd.Next(2) == 0 ? "hard" : "soft";
            int pages = rnd.Next(50, 500);
            b[i] = new Child2("Book_" + i, cover, pages);
            b[i].Metod();
            Console.WriteLine(b[i].Info());
        }

        Array.Sort(b);
        Console.WriteLine("---сортировка по количеству страниц-");
        for (int i = 0; i < 3; i++)
        {
            b[i].Metod();
            Console.WriteLine(b[i].Info());
        }
    }
}