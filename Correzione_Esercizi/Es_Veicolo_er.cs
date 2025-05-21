using System;
using System.Collections.Generic;

// Classe base
public class Veicolo
{
    public string Marca;
    public string Modello;

    public Veicolo(string marca, string modello)
    {
        Marca = marca;
        Modello = modello;
    }

    // Metodo virtuale sovrascrivibile
    public override string ToString()
    {
        return $"Veicolo: {Marca} {Modello}";
    }
}

// Classe derivata Auto
public class Auto : Veicolo
{
    public int NumeroPorte;

    public Auto(string marca, string modello, int numeroPorte)
        : base(marca, modello)
    {
        NumeroPorte = numeroPorte;
    }

    public override string ToString()
    {
        return $"Auto: {Marca} {Modello}, Porte: {NumeroPorte}";
    }
}

// Classe derivata Moto
public class Moto : Veicolo
{
    public string TipoManubrio;

    public Moto(string marca, string modello, string tipoManubrio)
        : base(marca, modello)
    {
        TipoManubrio = tipoManubrio;
    }

    public override string ToString()
    {
        return $"Moto: {Marca} {Modello}, Manubrio: {TipoManubrio}";
    }
}

public class Program
{
    public static void Main()
    {
        List<Veicolo> garage = new List<Veicolo>();
        bool continua = true;

        while (continua)
        {
            Console.WriteLine("\n--- MENU GARAGE ---");
            Console.WriteLine("1. Inserisci Auto");
            Console.WriteLine("2. Inserisci Moto");
            Console.WriteLine("3. Mostra tutti i veicoli");
            Console.WriteLine("0. Esci");
            Console.Write("Scelta: ");
            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    Console.Write("Marca: ");
                    string marcaAuto = Console.ReadLine();
                    Console.Write("Modello: ");
                    string modelloAuto = Console.ReadLine();
                    Console.Write("Numero porte: ");
                    int porte = int.Parse(Console.ReadLine());
                    garage.Add(new Auto(marcaAuto, modelloAuto, porte));
                    break;

                case "2":
                    Console.Write("Marca: ");
                    string marcaMoto = Console.ReadLine();
                    Console.Write("Modello: ");
                    string modelloMoto = Console.ReadLine();
                    Console.Write("Tipo manubrio: ");
                    string manubrio = Console.ReadLine();
                    garage.Add(new Moto(marcaMoto, modelloMoto, manubrio));
                    break;

                case "3":
                    Console.WriteLine("\n--- VEICOLI IN GARAGE ---");
                    foreach (Veicolo v in garage)
                    {
                        Console.WriteLine(v.ToString()); // Polimorfismo
                    }
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
