using System;

public class Macchina
{
    public string Motore;
    public float VelocitaMac;
    public int SospensioniMax;
    public int NrModifiche;

    public void AumentaVelocita()
    {
        VelocitaMac += 10;
        NrModifiche++;
    }

    public void CambiaMotore(string nuovoMotore)
    {
        Motore = nuovoMotore;
        NrModifiche++;
    }

    public void AumentaSospensioni()
    {
        SospensioniMax += 1;
        NrModifiche++;
    }

    public void StampaCaratteristiche(string nomeUtente)
    {
        Console.WriteLine($"Utente: {nomeUtente}");
        Console.WriteLine($"Motore: {Motore}");
        Console.WriteLine($"Velocità: {VelocitaMac}");
        Console.WriteLine($"Sospensioni: {SospensioniMax}");
        Console.WriteLine($"Numero Modifiche: {NrModifiche}");
    }
}

public class Utente
{
    public string Nome;
    public int Credito;

    public Utente(string nome, int credito)
    {
        Nome = nome;
        Credito = credito;
    }

    public bool UsaCredito()
    {
        if (Credito > 0)
        {
            Credito--;
            return true;
        }
        else
        {
            Console.WriteLine("Credito terminato.");
            return false;
        }
    }
}

public class Program
{
    public static void Main()
    {
        Macchina macchina = new Macchina();
        Console.WriteLine("Inserisci il tuo nome:");
        string nome = Console.ReadLine();

        Utente utente = new Utente(nome, 5); // es. 5 crediti iniziali

        Console.WriteLine("Inserisci tipo di motore iniziale:");
        macchina.Motore = Console.ReadLine();
        macchina.VelocitaMac = 100f;
        macchina.SospensioniMax = 3;
        macchina.NrModifiche = 0;

        bool continua = true;
        while (continua && utente.Credito > 0)
        {
            Console.WriteLine("\nScegli modifica (1 = +Velocità, 2 = Cambia motore, 3 = +Sospensioni, 0 = Esci):");
            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    if (utente.UsaCredito())
                        macchina.AumentaVelocita();
                    break;

                case "2":
                    if (utente.UsaCredito())
                    {
                        Console.WriteLine("Inserisci nuovo motore:");
                        string nuovoMotore = Console.ReadLine();
                        macchina.CambiaMotore(nuovoMotore);
                    }
                    break;

                case "3":
                    if (utente.UsaCredito())
                        macchina.AumentaSospensioni();
                    break;

                case "0":
                    continua = false;
                    break;

                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }

        Console.WriteLine("\nModifiche completate:");
        macchina.StampaCaratteristiche(utente.Nome);
    }
}
