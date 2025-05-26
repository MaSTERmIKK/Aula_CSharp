using System;
using System.Collections.Generic;

// Classe astratta
public abstract class DispositivoElettronico
{
    public string Modello { get; set; }

    public DispositivoElettronico(string modello)
    {
        Modello = modello;
    }

    // Metodo astratto: obbliga le classi figlie a implementarlo
    public abstract void Accendi();
    public abstract void Spegni();

    // Metodo virtuale: può essere sovrascritto ma ha già un comportamento base
    public virtual void MostraInfo()
    {
        Console.WriteLine($"Dispositivo: {Modello}");
    }
}

// Classe concreta: Computer
public class Computer : DispositivoElettronico
{
    public Computer(string modello) : base(modello) { }

    public override void Accendi()
    {
        Console.WriteLine("Il computer si avvia...");
    }

    public override void Spegni()
    {
        Console.WriteLine("Il computer si spegne.");
    }
}

// Classe concreta: Stampante
public class Stampante : DispositivoElettronico
{
    public Stampante(string modello) : base(modello) { }

    public override void Accendi()
    {
        Console.WriteLine("La stampante si accende.");
    }

    public override void Spegni()
    {
        Console.WriteLine("La stampante va in standby.");
    }
}

public class Program
{
    public static void Main()
    {
        List<DispositivoElettronico> dispositivi = new List<DispositivoElettronico>();

        dispositivi.Add(new Computer("Dell Latitude 7420"));
        dispositivi.Add(new Stampante("HP LaserJet 1020"));

        foreach (DispositivoElettronico d in dispositivi)
        {
            d.MostraInfo();
            d.Accendi();
            d.Spegni();
            Console.WriteLine();
        }

        Console.WriteLine("Programma terminato.");
    }
}
