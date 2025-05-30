using System;

// Interfaccia base
public interface IBevanda
{
    string Descrizione();
    double Costo();
}

// Bevande concrete
public class Caffe : IBevanda
{
    public string Descrizione() => "Caffè";
    public double Costo() => 1.00;
}

public class Te : IBevanda
{
    public string Descrizione() => "Tè";
    public double Costo() => 0.80;
}

// Decoratore astratto
public abstract class DecoratoreBevanda : IBevanda
{
    protected IBevanda bevanda;

    public DecoratoreBevanda(IBevanda bevanda)
    {
        this.bevanda = bevanda;
    }

    public abstract string Descrizione();
    public abstract double Costo();
}

// Decoratori concreti
public class ConLatte : DecoratoreBevanda
{
    public ConLatte(IBevanda bevanda) : base(bevanda) {}

    public override string Descrizione() => bevanda.Descrizione() + ", con latte";
    public override double Costo() => bevanda.Costo() + 0.30;
}

public class ConCioccolato : DecoratoreBevanda
{
    public ConCioccolato(IBevanda bevanda) : base(bevanda) {}

    public override string Descrizione() => bevanda.Descrizione() + ", con cioccolato";
    public override double Costo() => bevanda.Costo() + 0.50;
}

public class ConPanna : DecoratoreBevanda
{
    public ConPanna(IBevanda bevanda) : base(bevanda) {}

    public override string Descrizione() => bevanda.Descrizione() + ", con panna";
    public override double Costo() => bevanda.Costo() + 0.40;
}

public class Program
{
    public static void Main()
    {
        IBevanda ordine = new Caffe();
        ordine = new ConLatte(ordine);
        ordine = new ConCioccolato(ordine);
        ordine = new ConPanna(ordine);

        Console.WriteLine("Ordine: " + ordine.Descrizione());
        Console.WriteLine("Costo totale: €" + ordine.Costo().ToString("0.00"));
    }
}
