using System;
using System.Collections.Generic;

// Singleton: Logger con lista di messaggi
public class Logger
{
    private static Logger istanza;
    private List<string> logInterno;

    // Costruttore privato
    private Logger()
    {
        logInterno = new List<string>();
    }

    // Accesso statico all'unica istanza
    public static Logger Instance
    {
        get
        {
            if (istanza == null)
                istanza = new Logger();
            return istanza;
        }
    }

    // Metodo per aggiungere un messaggio alla lista
    public void Log(string messaggio)
    {
        logInterno.Add($"[{DateTime.Now}] {messaggio}");
    }

    // Metodo per stampare tutti i log
    public void StampaLog()
    {
        Console.WriteLine("--- LOG REGISTRATI ---");
        foreach (string voce in logInterno)
        {
            Console.WriteLine(voce);
        }
    }
}

public class Program
{
    public static void Main()
    {
        // Due riferimenti allo stesso singleton
        Logger log1 = Logger.Instance;
        Logger log2 = Logger.Instance;

        // Due chiamate da due "istanze" diverse
        log1.Log("Inizio sessione di lavoro.");
        log2.Log("Operazione completata.");

        // Verifica che entrambi abbiano scritto nello stesso oggetto
        log1.StampaLog();

        Console.WriteLine("Le due istanze sono uguali? " + (log1 == log2));
        Console.WriteLine("Programma terminato.");
    }
}
