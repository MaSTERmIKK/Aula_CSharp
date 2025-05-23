using System;
using System.Collections.Generic;

// Classe base
public class Veicolo
{
    public string Targa { get; set; }

    public Veicolo(string targa)
    {
        Targa = targa;
    }

    public virtual void Ripara()
    {
        Console.WriteLine($"Veicolo con targa {Targa}: controllo generico eseguito.");
    }
}

// Classe derivata Auto
public class Auto : Veicolo
{
    public Auto(string targa) : base(targa) { }

    public override void Ripara()
    {
        Console.WriteLine($"Auto {Targa}: controllo olio, freni e motore.");
    }
}

// Classe derivata Moto
public class Moto : Veicolo
{
    public Moto(string targa) : base(targa) { }

    public override void Ripara()
    {
        Console.WriteLine($"Moto {Targa}: controllo catena, freni e gomme.");
    }
}

// Classe derivata Camion
public class Camion : Veicolo
{
    public Camion(string targa) : base(targa) { }

    public override void Ripara()
    {
        Console.WriteLine($"Camion {Targa}: controllo sospensioni, freni rinforzati e carico.");
    }
}

public class Program
{
    public static void Main()
    {
        List<Veicolo> veicoliInOfficina = new List<Veicolo>();
        bool continua = true;

        while (continua)
        {
            Console.WriteLine("\n--- MENU OFFICINA ---");
            Console.WriteLine("1. Inserisci Auto");
            Console.WriteLine("2. Inserisci Moto");
            Console.WriteLine("3. Inserisci Camion");
            Console.WriteLine("4. Esegui riparazioni");
            Console.WriteLine("0. Esci");
            Console.Write("Scelta: ");
            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    Console.Write("Inserisci targa auto: ");
                    string targaAuto = Console.ReadLine();
                    veicoliInOfficina.Add(new Auto(targaAuto));
                    break;

                case "2":
                    Console.Write("Inserisci targa moto: ");
                    string targaMoto = Console.ReadLine();
                    veicoliInOfficina.Add(new Moto(targaMoto));
                    break;

                case "3":
                    Console.Write("Inserisci targa camion: ");
                    string targaCamion = Console.ReadLine();
                    veicoliInOfficina.Add(new Camion(targaCamion));
                    break;

                case "4":
                    Console.WriteLine("\n--- RIPARAZIONI IN CORSO ---");
                    foreach (Veicolo v in veicoliInOfficina)
                    {
                        v.Ripara();
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
