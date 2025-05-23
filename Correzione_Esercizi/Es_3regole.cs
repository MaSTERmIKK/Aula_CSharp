using System;
using System.Collections.Generic;

// Classe base: Operatore
public class Operatore
{
    private string nome;
    private string turno;

    public string Nome
    {
        get { return nome; }
        set { nome = value; }
    }

    public string Turno
    {
        get { return turno; }
        set
        {
            if (value.ToLower() == "giorno" || value.ToLower() == "notte")
                turno = value;
            else
                Console.WriteLine("Turno non valido. Inserire 'giorno' o 'notte'.");
        }
    }

    public virtual void EseguiCompito()
    {
        Console.WriteLine($"Operatore {Nome} in turno {Turno}: Compito generico eseguito.");
    }
}

public class OperatoreEmergenza : Operatore
{
    private int livelloUrgenza;

    public int LivelloUrgenza
    {
        get { return livelloUrgenza; }
        set
        {
            if (value >= 1 && value <= 5)
                livelloUrgenza = value;
            else
                Console.WriteLine("Livello urgenza non valido. Deve essere tra 1 e 5.");
        }
    }

    public override void EseguiCompito()
    {
        Console.WriteLine($"{Nome} (Emergenza) - Gestione emergenza di livello {LivelloUrgenza}.");
    }
}

public class OperatoreSicurezza : Operatore
{
    public string AreaSorvegliata { get; set; }

    public override void EseguiCompito()
    {
        Console.WriteLine($"{Nome} (Sicurezza) - Sorveglianza dell'area: {AreaSorvegliata}.");
    }
}

public class OperatoreLogistica : Operatore
{
    private int numeroConsegne;

    public int NumeroConsegne
    {
        get { return numeroConsegne; }
        set
        {
            if (value >= 0)
                numeroConsegne = value;
            else
                Console.WriteLine("Numero consegne non valido.");
        }
    }

    public override void EseguiCompito()
    {
        Console.WriteLine($"{Nome} (Logistica) - Coordinamento di {NumeroConsegne} consegne.");
    }
}

public class Program
{
    public static void Main()
    {
        List<Operatore> centrale = new List<Operatore>();
        bool continua = true;

        while (continua)
        {
            Console.WriteLine("\n--- CENTRALE OPERATIVA ---");
            Console.WriteLine("1. Aggiungi Operatore Emergenza");
            Console.WriteLine("2. Aggiungi Operatore Sicurezza");
            Console.WriteLine("3. Aggiungi Operatore Logistica");
            Console.WriteLine("4. Visualizza Operatori");
            Console.WriteLine("5. Esegui Compiti");
            Console.WriteLine("0. Esci");
            Console.Write("Scelta: ");
            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    OperatoreEmergenza oe = new OperatoreEmergenza();
                    Console.Write("Nome: "); oe.Nome = Console.ReadLine();
                    Console.Write("Turno (giorno/notte): "); oe.Turno = Console.ReadLine();
                    Console.Write("Livello urgenza (1-5): "); oe.LivelloUrgenza = int.Parse(Console.ReadLine());
                    centrale.Add(oe);
                    break;

                case "2":
                    OperatoreSicurezza os = new OperatoreSicurezza();
                    Console.Write("Nome: "); os.Nome = Console.ReadLine();
                    Console.Write("Turno (giorno/notte): "); os.Turno = Console.ReadLine();
                    Console.Write("Area sorvegliata: "); os.AreaSorvegliata = Console.ReadLine();
                    centrale.Add(os);
                    break;

                case "3":
                    OperatoreLogistica ol = new OperatoreLogistica();
                    Console.Write("Nome: "); ol.Nome = Console.ReadLine();
                    Console.Write("Turno (giorno/notte): "); ol.Turno = Console.ReadLine();
                    Console.Write("Numero consegne: "); ol.NumeroConsegne = int.Parse(Console.ReadLine());
                    centrale.Add(ol);
                    break;

                case "4":
                    Console.WriteLine("\n--- OPERATORI REGISTRATI ---");
                    foreach (Operatore op in centrale)
                    {
                        Console.WriteLine($"Nome: {op.Nome}, Turno: {op.Turno}, Tipo: {op.GetType().Name}");
                    }
                    break;

                case "5":
                    Console.WriteLine("\n--- COMPITI IN ESECUZIONE ---");
                    foreach (Operatore op in centrale)
                    {
                        op.EseguiCompito();
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

        Console.WriteLine("Chiusura programma.");
    }
}
