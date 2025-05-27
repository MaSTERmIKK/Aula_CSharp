using System;
using System.Collections.Generic;

// Singleton: Logger di sistema
public sealed class Logger
{
    private static Logger istanza;
    private Logger() { }

    public static Logger GetIstanza()
    {
        if (istanza == null)
        {
            istanza = new Logger();
        }
        return istanza;
    }

    public void ScriviMessaggio(string messaggio)
    {
        Console.WriteLine($"[{DateTime.Now}] {messaggio}");
    }
}

public class Program
{
    public static void Main()
    {
        Logger log1 = Logger.GetIstanza();
        Logger log2 = Logger.GetIstanza();

        log1.ScriviMessaggio("Sistema avviato.");
        log2.ScriviMessaggio("Connessione al database riuscita.");

        Console.WriteLine("Le due istanze sono uguali? " + (log1 == log2));
        Console.WriteLine("Programma terminato.");
    }
}
