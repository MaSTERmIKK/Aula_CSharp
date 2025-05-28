using System;
using System.Collections.Generic;

// Interfaccia comune
public interface IVeicolo
{
    void Avvia();
    void MostraTipo();
}

// Implementazioni dei veicoli
public class Auto : IVeicolo
{
    public void Avvia()
    {
        Console.WriteLine("Avvio dell'auto");
    }

    public void MostraTipo()
    {
        Console.WriteLine("Tipo: Auto");
    }
}

public class Moto : IVeicolo
{
    public void Avvia()
    {
        Console.WriteLine("Avvio della moto");
    }

    public void MostraTipo()
    {
        Console.WriteLine("Tipo: Moto");
    }
}

public class Camion : IVeicolo
{
    public void Avvia()
    {
        Console.WriteLine("Avvio del camion");
    }

    public void MostraTipo()
    {
        Console.WriteLine("Tipo: Camion");
    }
}

// Classe factory
public class VeicoloFactory
{
    public static IVeicolo CreaVeicolo(string tipo)
    {
        switch (tipo.ToLower())
        {
            case "auto": return new Auto();
            case "moto": return new Moto();
            case "camion": return new Camion();
            default:
                Console.WriteLine("Tipo di veicolo non riconosciuto.");
                return null;
        }
    }
}

public class Program
{
    public static void Main()
    {
        Console.Write("Inserisci il tipo di veicolo da creare (auto, moto, camion): ");
        string input = Console.ReadLine();

        IVeicolo veicolo = VeicoloFactory.CreaVeicolo(input);

        if (veicolo != null)
        {
            veicolo.Avvia();
            veicolo.MostraTipo();
        }

        Console.WriteLine("Programma terminato.");
    }
}
