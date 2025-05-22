using System;
using System.Collections.Generic;

// Classe base
public class Soldato
{
    private string nome;
    private string grado;
    private int anniServizio;

    public string Nome
    {
        get { return nome; }
        set { nome = value; }
    }

    public string Grado
    {
        get { return grado; }
        set { grado = value; }
    }

    public int AnniServizio
    {
        get { return anniServizio; }
        set
        {
            if (value >= 0)
                anniServizio = value;
            else
                Console.WriteLine("Anni di servizio non validi.");
        }
    }

    public virtual void Descrizione()
    {
        Console.WriteLine($"{Grado} {Nome} - {AnniServizio} anni di servizio.");
    }
}

// Classe derivata: Fante
public class Fante : Soldato
{
    private string arma;

    public string Arma
    {
        get { return arma; }
        set { arma = value; }
    }

    public override void Descrizione()
    {
        Console.WriteLine($"{Grado} {Nome} (Fante) - {AnniServizio} anni di servizio. Arma: {Arma}");
    }
}

// Classe derivata: Artigliere
public class Artigliere : Soldato
{
    private int calibro;

    public int Calibro
    {
        get { return calibro; }
        set
        {
            if (value > 0)
                calibro = value;
            else
                Console.WriteLine("Calibro non valido.");
        }
    }

    public override void Descrizione()
    {
        Console.WriteLine($"{Grado} {Nome} (Artigliere) - {AnniServizio} anni di servizio. Calibro: {Calibro}mm");
    }
}

public class Program
{
    public static void Main()
    {
        List<Soldato> reparto = new List<Soldato>();
        bool continua = true;

        while (continua)
        {
            Console.WriteLine("\n--- GESTIONE REPARTO MILITARE ---");
            Console.WriteLine("1. Aggiungi Fante");
            Console.WriteLine("2. Aggiungi Artigliere");
            Console.WriteLine("3. Visualizza Soldati");
            Console.WriteLine("0. Esci");
            Console.Write("Scelta: ");
            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    Fante f = new Fante();
                    Console.Write("Nome: "); f.Nome = Console.ReadLine();
                    Console.Write("Grado: "); f.Grado = Console.ReadLine();
                    Console.Write("Anni di servizio: "); f.AnniServizio = int.Parse(Console.ReadLine());
                    Console.Write("Arma: "); f.Arma = Console.ReadLine();
                    reparto.Add(f);
                    break;

                case "2":
                    Artigliere a = new Artigliere();
                    Console.Write("Nome: "); a.Nome = Console.ReadLine();
                    Console.Write("Grado: "); a.Grado = Console.ReadLine();
                    Console.Write("Anni di servizio: "); a.AnniServizio = int.Parse(Console.ReadLine());
                    Console.Write("Calibro: "); a.Calibro = int.Parse(Console.ReadLine());
                    reparto.Add(a);
                    break;

                case "3":
                    Console.WriteLine("\n--- SOLDATI NEL REPARTO ---");
                    foreach (Soldato s in reparto)
                    {
                        s.Descrizione();
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
