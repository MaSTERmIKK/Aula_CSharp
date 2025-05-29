using System;
using System.Collections.Generic;

// Interfaccia Observer
public interface IObserver
{
    void Aggiorna(string messaggio);
}

// Interfaccia Subject
public interface ISoggetto
{
    void Registra(IObserver osservatore);
    void Rimuovi(IObserver osservatore);
    void Notifica(string messaggio);
}

// Centro Meteo: soggetto osservato
public class CentroMeteo : ISoggetto
{
    private List<IObserver> osservatori = new List<IObserver>();

    public void Registra(IObserver osservatore)
    {
        osservatori.Add(osservatore);
    }

    public void Rimuovi(IObserver osservatore)
    {
        osservatori.Remove(osservatore);
    }

    public void Notifica(string messaggio)
    {
        foreach (var osservatore in osservatori)
        {
            osservatore.Aggiorna(messaggio);
        }
    }

    public void AggiornaMeteo(string dati)
    {
        Console.WriteLine("Aggiornamento meteo: " + dati);
        Notifica(dati);
    }
}

// Display Console
public class DisplayConsole : IObserver
{
    public void Aggiorna(string messaggio)
    {
        Console.WriteLine($"[Console] Meteo aggiornato: {messaggio}");
    }
}

// Display Mobile
public class DisplayMobile : IObserver
{
    public void Aggiorna(string messaggio)
    {
        Console.WriteLine($"[Mobile] Meteo ricevuto: {messaggio}");
    }
}

public class Program
{
    public static void Main()
    {
        CentroMeteo centro = new CentroMeteo();
        IObserver console = new DisplayConsole();
        IObserver mobile = new DisplayMobile();

        centro.Registra(console);
        centro.Registra(mobile);

        bool continua = true;
        while (continua)
        {
            Console.WriteLine("\n1. Inserisci aggiornamento meteo\n0. Esci");
            Console.Write("Scelta: ");
            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    Console.Write("Inserisci nuove condizioni meteo: ");
                    string dati = Console.ReadLine();
                    centro.AggiornaMeteo(dati);
                    break;
                case "0":
                    continua = false;
                    break;
                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }

        Console.WriteLine("Programma terminato.");
    }
}
