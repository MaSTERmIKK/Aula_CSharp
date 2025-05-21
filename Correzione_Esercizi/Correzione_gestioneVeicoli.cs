using System;
using System.Collections.Generic;

// Classe base
public class Corso
{
    public string NomeCorso;
    public int DurataOre;
    public string Docente;
    public List<string> Studenti = new List<string>();

    public Corso(string nome, int ore, string docente)
    {
        NomeCorso = nome;
        DurataOre = ore;
        Docente = docente;
    }

    public void AggiungiStudente(string nomeStudente)
    {
        Studenti.Add(nomeStudente);
    }

    public virtual void MetodoSpeciale()
    {
        Console.WriteLine("Metodo speciale del corso base.");
    }

    public override string ToString()
    {
        return $"Corso: {NomeCorso} - Durata: {DurataOre}h - Docente: {Docente} - Iscritti: {Studenti.Count}";
    }
}

public class CorsoMusica : Corso
{
    public string Strumento;

    public CorsoMusica(string nome, int ore, string docente, string strumento)
        : base(nome, ore, docente)
    {
        Strumento = strumento;
    }

    public override void MetodoSpeciale()
    {
        Console.WriteLine($"Si tiene una prova pratica dello strumento: {Strumento}.");
    }

    public override string ToString()
    {
        return base.ToString() + $" - Tipo: Musica - Strumento: {Strumento}";
    }
}

public class CorsoPittura : Corso
{
    public string Tecnica;

    public CorsoPittura(string nome, int ore, string docente, string tecnica)
        : base(nome, ore, docente)
    {
        Tecnica = tecnica;
    }

    public override void MetodoSpeciale()
    {
        Console.WriteLine($"Si lavora su una tela con tecnica: {Tecnica}.");
    }

    public override string ToString()
    {
        return base.ToString() + $" - Tipo: Pittura - Tecnica: {Tecnica}";
    }
}

public class CorsoDanza : Corso
{
    public string Stile;

    public CorsoDanza(string nome, int ore, string docente, string stile)
        : base(nome, ore, docente)
    {
        Stile = stile;
    }

    public override void MetodoSpeciale()
    {
        Console.WriteLine($"Esecuzione coreografia nello stile: {Stile}.");
    }

    public override string ToString()
    {
        return base.ToString() + $" - Tipo: Danza - Stile: {Stile}";
    }
}

public class Program
{
    public static void Main()
    {
        List<Corso> corsi = new List<Corso>();
        bool continua = true;

        while (continua)
        {
            Console.WriteLine("\n--- MENU SCUOLA ARTISTICA ---");
            Console.WriteLine("1. Aggiungi corso di Musica");
            Console.WriteLine("2. Aggiungi corso di Pittura");
            Console.WriteLine("3. Aggiungi corso di Danza");
            Console.WriteLine("4. Aggiungi studente a un corso");
            Console.WriteLine("5. Visualizza tutti i corsi");
            Console.WriteLine("6. Cerca corsi per docente");
            Console.WriteLine("7. Esegui metodo speciale di un corso");
            Console.WriteLine("0. Esci");
            Console.Write("Scelta: ");
            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    Console.Write("Nome corso: "); string nome1 = Console.ReadLine();
                    Console.Write("Durata (ore): "); int ore1 = int.Parse(Console.ReadLine());
                    Console.Write("Docente: "); string docente1 = Console.ReadLine();
                    Console.Write("Strumento: "); string strumento = Console.ReadLine();
                    corsi.Add(new CorsoMusica(nome1, ore1, docente1, strumento));
                    break;

                case "2":
                    Console.Write("Nome corso: "); string nome2 = Console.ReadLine();
                    Console.Write("Durata (ore): "); int ore2 = int.Parse(Console.ReadLine());
                    Console.Write("Docente: "); string docente2 = Console.ReadLine();
                    Console.Write("Tecnica: "); string tecnica = Console.ReadLine();
                    corsi.Add(new CorsoPittura(nome2, ore2, docente2, tecnica));
                    break;

                case "3":
                    Console.Write("Nome corso: "); string nome3 = Console.ReadLine();
                    Console.Write("Durata (ore): "); int ore3 = int.Parse(Console.ReadLine());
                    Console.Write("Docente: "); string docente3 = Console.ReadLine();
                    Console.Write("Stile: "); string stile = Console.ReadLine();
                    corsi.Add(new CorsoDanza(nome3, ore3, docente3, stile));
                    break;

                case "4":
                    for (int i = 0; i < corsi.Count; i++)
                        Console.WriteLine($"{i}: {corsi[i].NomeCorso}");
                    Console.Write("Seleziona corso per indice: ");
                    int indiceStudente = int.Parse(Console.ReadLine());
                    Console.Write("Nome studente: ");
                    string studente = Console.ReadLine();
                    corsi[indiceStudente].AggiungiStudente(studente);
                    break;

                case "5":
                    Console.WriteLine("\n--- CORSI DISPONIBILI ---");
                    foreach (Corso c in corsi)
                        Console.WriteLine(c);
                    break;

                case "6":
                    Console.Write("Nome docente: ");
                    string nomeDoc = Console.ReadLine();
                    foreach (Corso c in corsi)
                    {
                        if (c.Docente.ToLower() == nomeDoc.ToLower())
                            Console.WriteLine(c);
                    }
                    break;

                case "7":
                    for (int i = 0; i < corsi.Count; i++)
                        Console.WriteLine($"{i}: {corsi[i].NomeCorso}");
                    Console.Write("Seleziona corso per indice: ");
                    int indiceMetodo = int.Parse(Console.ReadLine());
                    corsi[indiceMetodo].MetodoSpeciale();
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
