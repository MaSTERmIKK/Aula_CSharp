using System;
using System.Collections.Generic;

// Interfaccia Observer
public interface IObserver
{
    void NotificaCreazione(string nomeUtente);
}

// Interfaccia Subject
public interface ISoggetto
{
    void Registra(IObserver o);
    void Rimuovi(IObserver o);
    void Notifica(string nomeUtente);
}

// Classe Utente
public class Utente
{
    public string Nome { get; set; }

    public Utente(string nome)
    {
        Nome = nome;
    }

    public override string ToString()
    {
        return $"Utente: {Nome}";
    }
}

// Factory per creare utenti
public static class UserFactory
{
    public static Utente Crea(string nome)
    {
        return new Utente(nome);
    }
}

// Gestore che funge da subject e utilizza la factory
public class GestoreCreazioneUtente : ISoggetto
{
    private List<IObserver> osservatori = new List<IObserver>();

    public void Registra(IObserver o)
    {
        osservatori.Add(o);
    }

    public void Rimuovi(IObserver o)
    {
        osservatori.Remove(o);
    }

    public void Notifica(string nomeUtente)
    {
        foreach (var osservatore in osservatori)
        {
            osservatore.NotificaCreazione(nomeUtente);
        }
    }

    public void CreaUtente(string nome)
    {
        Utente nuovo = UserFactory.Crea(nome);
        Console.WriteLine($"Creato: {nuovo}");
        Notifica(nuovo.Nome);
    }
}

// Osservatore Log
public class ModuloLog : IObserver
{
    public void NotificaCreazione(string nomeUtente)
    {
        Console.WriteLine($"[LOG] Utente creato: {nomeUtente}");
    }
}

// Osservatore Marketing
public class ModuloMarketing : IObserver
{
    public void NotificaCreazione(string nomeUtente)
    {
        Console.WriteLine($"[MARKETING] Invia email di benvenuto a {nomeUtente}");
    }
}

public class Program
{
    public static void Main()
    {
        GestoreCreazioneUtente gestore = new GestoreCreazioneUtente();
        gestore.Registra(new ModuloLog());
        gestore.Registra(new ModuloMarketing());

        bool attivo = true;
        while (attivo)
        {
            Console.WriteLine("\n1. Crea nuovo utente\n0. Esci");
            Console.Write("Scelta: ");
            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    Console.Write("Inserisci il nome dell'utente: ");
                    string nome = Console.ReadLine();
                    gestore.CreaUtente(nome);
                    break;
                case "0":
                    attivo = false;
                    break;
                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }

        Console.WriteLine("Programma terminato.");
    }
}
