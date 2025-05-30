using System;

// Interfaccia base del piatto
public interface IPiatto
{
    string Descrizione();
    string Prepara();
}

// Interfaccia strategia di preparazione
public interface IPreparazioneStrategia
{
    string Prepara(string descrizione);
}

// Strategie di preparazione
public class Fritto : IPreparazioneStrategia
{
    public string Prepara(string descrizione) => $"{descrizione} sarà fritto";
}

public class AlForno : IPreparazioneStrategia
{
    public string Prepara(string descrizione) => $"{descrizione} sarà cotto al forno";
}

public class AllaGriglia : IPreparazioneStrategia
{
    public string Prepara(string descrizione) => $"{descrizione} sarà grigliato";
}

// Classe Chef (context per Strategy)
public class Chef
{
    private IPreparazioneStrategia strategia;

    public void ImpostaStrategia(IPreparazioneStrategia nuovaStrategia)
    {
        strategia = nuovaStrategia;
    }

    public string PreparaPiatto(IPiatto piatto)
    {
        return strategia?.Prepara(piatto.Descrizione()) ?? "Nessuna strategia di preparazione impostata";
    }
}

// Piatto base: Pizza
public class Pizza : IPiatto
{
    public virtual string Descrizione() => "Pizza";
    public virtual string Prepara() => "Base Pizza";
}

public class Hamburger : IPiatto
{
    public virtual string Descrizione() => "Hamburger";
    public virtual string Prepara() => "Base Hamburger";
}

public class Insalata : IPiatto
{
    public virtual string Descrizione() => "Insalata";
    public virtual string Prepara() => "Base Insalata";
}

// Decoratore astratto
public abstract class IngredienteExtra : IPiatto
{
    protected IPiatto basePiatto;

    public IngredienteExtra(IPiatto piatto)
    {
        basePiatto = piatto;
    }

    public abstract string Descrizione();
    public string Prepara() => basePiatto.Prepara();
}

// Decoratori concreti
public class ConFormaggio : IngredienteExtra
{
    public ConFormaggio(IPiatto piatto) : base(piatto) { }
    public override string Descrizione() => basePiatto.Descrizione() + " + formaggio";
}

public class ConBacon : IngredienteExtra
{
    public ConBacon(IPiatto piatto) : base(piatto) { }
    public override string Descrizione() => basePiatto.Descrizione() + " + bacon";
}

public class ConSalsa : IngredienteExtra
{
    public ConSalsa(IPiatto piatto) : base(piatto) { }
    public override string Descrizione() => basePiatto.Descrizione() + " + salsa";
}

// Factory
public static class PiattoFactory
{
    public static IPiatto Crea(string tipo)
    {
        switch (tipo.ToLower())
        {
            case "pizza": return new Pizza();
            case "hamburger": return new Hamburger();
            case "insalata": return new Insalata();
            default:
                Console.WriteLine("Tipo di piatto non riconosciuto");
                return null;
        }
    }
}

public class Program
{
    public static void Main()
    {
        Console.Write("Scegli il tipo di piatto (pizza, hamburger, insalata): ");
        string tipo = Console.ReadLine();
        IPiatto piatto = PiattoFactory.Crea(tipo);
        if (piatto == null) return;

        bool aggiungi = true;
        while (aggiungi)
        {
            Console.WriteLine("\nVuoi aggiungere un ingrediente?");
            Console.WriteLine("1. Formaggio\n2. Bacon\n3. Salsa\n0. Fine");
            string scelta = Console.ReadLine();
            switch (scelta)
            {
                case "1":
                    piatto = new ConFormaggio(piatto);
                    break;
                case "2":
                    piatto = new ConBacon(piatto);
                    break;
                case "3":
                    piatto = new ConSalsa(piatto);
                    break;
                case "0":
                    aggiungi = false;
                    break;
                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }

        Console.WriteLine("\nScegli metodo di cottura:");
        Console.WriteLine("1. Fritto\n2. Al forno\n3. Alla griglia");
        string metodo = Console.ReadLine();

        Chef chef = new Chef();
        switch (metodo)
        {
            case "1": chef.ImpostaStrategia(new Fritto()); break;
            case "2": chef.ImpostaStrategia(new AlForno()); break;
            case "3": chef.ImpostaStrategia(new AllaGriglia()); break;
            default:
                Console.WriteLine("Metodo non valido");
                return;
        }

        Console.WriteLine("\nOrdine completo:");
        Console.WriteLine("Piatto: " + piatto.Descrizione());
        Console.WriteLine("Preparazione: " + chef.PreparaPiatto(piatto));
    }
}
