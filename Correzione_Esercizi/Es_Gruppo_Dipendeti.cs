using System;
using System.Collections.Generic;

// Classe base
public class Dipendente
{
    private string nome;
    private int eta;

    public string Nome
    {
        get { return nome; }
        set { nome = value; }
    }

    public int Eta
    {
        get { return eta; }
        set
        {
            if (value >= 18)
                eta = value;
            else
                Console.WriteLine("Errore: l'età deve essere >= 18.");
        }
    }

    public Dipendente(string nome, int eta)
    {
        Nome = nome;
        Eta = eta;
    }

    public virtual void EseguiCompito()
    {
        Console.WriteLine("Compito generico del dipendente.");
    }
}

public class Autista : Dipendente
{
    public string Patente { get; set; }

    public Autista(string nome, int eta, string patente) : base(nome, eta)
    {
        Patente = patente;
    }

    public override void EseguiCompito()
    {
        Console.WriteLine($"Guida il veicolo con patente {Patente}.");
    }
}

public class Meccanico : Dipendente
{
    public string Specializzazione { get; set; }

    public Meccanico(string nome, int eta, string specializzazione) : base(nome, eta)
    {
        Specializzazione = specializzazione;
    }

    public override void EseguiCompito()
    {
        Console.WriteLine($"Ripara mezzi specializzati in: {Specializzazione}.");
    }
}

public class OperatoreCentrale : Dipendente
{
    public string Turno { get; set; }

    public OperatoreCentrale(string nome, int eta, string turno) : base(nome, eta)
    {
        Turno = turno;
    }

    public override void EseguiCompito()
    {
        Console.WriteLine($"Gestisce le comunicazioni in turno: {Turno}.");
    }
}

class Program
{
    static List<Dipendente> dipendenti = new List<Dipendente>();

    static void Main()
    {
        bool esci = false;
        while (!esci)
        {
            Console.WriteLine("\nMenu:\n1. Aggiungi Dipendente\n2. Visualizza Dipendenti\n3. Esegui Compiti\n4. Esci");
            Console.Write("Scelta: ");
            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    AggiungiDipendente();
                    break;
                case "2":
                    VisualizzaDipendenti();
                    break;
                case "3":
                    foreach (var d in dipendenti) d.EseguiCompito();
                    break;
                case "4":
                    esci = true;
                    break;
                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }
    }

    static void AggiungiDipendente()
    {
        Console.WriteLine("Tipo (autista/meccanico/operatore): ");
        string tipo = Console.ReadLine().ToLower();

        Console.Write("Nome: ");
        string nome = Console.ReadLine();
        Console.Write("Età: ");
        int eta = int.Parse(Console.ReadLine());

        switch (tipo)
        {
            case "autista":
                Console.Write("Patente: ");
                string patente = Console.ReadLine();
                dipendenti.Add(new Autista(nome, eta, patente));
                break;
            case "meccanico":
                Console.Write("Specializzazione: ");
                string spec = Console.ReadLine();
                dipendenti.Add(new Meccanico(nome, eta, spec));
                break;
            case "operatore":
                Console.Write("Turno (giorno/notte): ");
                string turno = Console.ReadLine();
                dipendenti.Add(new OperatoreCentrale(nome, eta, turno));
                break;
            default:
                Console.WriteLine("Tipo non valido.");
                break;
        }
    }

    static void VisualizzaDipendenti()
    {
        foreach (var d in dipendenti)
        {
            Console.WriteLine($"{d.GetType().Name} - Nome: {d.Nome}, Età: {d.Eta}");
        }
    }
}
