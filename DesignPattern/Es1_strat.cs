using System;

// Interfaccia strategia
public interface IStrategiaOperazione
{
    double Calcola(double a, double b);
}

// Strategie concrete
public class SommaStrategia : IStrategiaOperazione
{
    public double Calcola(double a, double b) => a + b;
}

public class SottrazioneStrategia : IStrategiaOperazione
{
    public double Calcola(double a, double b) => a - b;
}

public class MoltiplicazioneStrategia : IStrategiaOperazione
{
    public double Calcola(double a, double b) => a * b;
}

public class DivisioneStrategia : IStrategiaOperazione
{
    public double Calcola(double a, double b)
    {
        if (b == 0)
        {
            Console.WriteLine("Errore: divisione per zero.");
            return double.NaN;
        }
        return a / b;
    }
}

// Context
public class Calcolatrice
{
    private IStrategiaOperazione strategia;

    public void ImpostaStrategia(IStrategiaOperazione nuovaStrategia)
    {
        strategia = nuovaStrategia;
    }

    public double EseguiOperazione(double a, double b)
    {
        if (strategia == null)
        {
            Console.WriteLine("Nessuna strategia impostata.");
            return 0;
        }
        return strategia.Calcola(a, b);
    }
}

public class Program
{
    public static void Main()
    {
        Calcolatrice calc = new Calcolatrice();

        Console.Write("Inserisci il primo numero: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Inserisci il secondo numero: ");
        double b = double.Parse(Console.ReadLine());

        Console.WriteLine("Scegli operazione:");
        Console.WriteLine("1. Somma\n2. Sottrazione\n3. Moltiplicazione\n4. Divisione");
        string scelta = Console.ReadLine();

        switch (scelta)
        {
            case "1":
                calc.ImpostaStrategia(new SommaStrategia());
                break;
            case "2":
                calc.ImpostaStrategia(new SottrazioneStrategia());
                break;
            case "3":
                calc.ImpostaStrategia(new MoltiplicazioneStrategia());
                break;
            case "4":
                calc.ImpostaStrategia(new DivisioneStrategia());
                break;
            default:
                Console.WriteLine("Scelta non valida.");
                return;
        }

        double risultato = calc.EseguiOperazione(a, b);
        Console.WriteLine("Risultato: " + risultato);
    }
}
