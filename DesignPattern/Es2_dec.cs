using System;

// Interfaccia base
public interface ITorta
{
    string Descrizione();
}

// Torte base
public class TortaCioccolato : ITorta
{
    public string Descrizione() => "Torta al cioccolato";
}

public class TortaVaniglia : ITorta
{
    public string Descrizione() => "Torta alla vaniglia";
}

public class TortaFrutta : ITorta
{
    public string Descrizione() => "Torta alla frutta";
}

// Decoratore astratto
public abstract class DecoratoreTorta : ITorta
{
    protected ITorta baseTorta;

    public DecoratoreTorta(ITorta torta)
    {
        baseTorta = torta;
    }

    public abstract string Descrizione();
}

// Decoratori concreti
public class ConPanna : DecoratoreTorta
{
    public ConPanna(ITorta torta) : base(torta) {}

    public override string Descrizione() => baseTorta.Descrizione() + " + panna";
}

public class ConFragole : DecoratoreTorta
{
    public ConFragole(ITorta torta) : base(torta) {}

    public override string Descrizione() => baseTorta.Descrizione() + " + fragole";
}

public class ConGlassa : DecoratoreTorta
{
    public ConGlassa(ITorta torta) : base(torta) {}

    public override string Descrizione() => baseTorta.Descrizione() + " + glassa";
}

// Factory per le torte
public static class TortaFactory
{
    public static ITorta CreaTortaBase(string tipo)
    {
        switch (tipo.ToLower())
        {
            case "cioccolato": return new TortaCioccolato();
            case "vaniglia": return new TortaVaniglia();
            case "frutta": return new TortaFrutta();
            default:
                Console.WriteLine("Tipo di torta non riconosciuto.");
                return null;
        }
    }
}

public class Program
{
    public static void Main()
    {
        Console.Write("Scegli il tipo di torta (cioccolato, vaniglia, frutta): ");
        string tipoBase = Console.ReadLine();
        ITorta torta = TortaFactory.CreaTortaBase(tipoBase);

        if (torta == null) return;

        bool aggiungi = true;
        while (aggiungi)
        {
            Console.WriteLine("\nVuoi aggiungere un ingrediente?");
            Console.WriteLine("1. Panna\n2. Fragole\n3. Glassa\n0. Nessun altro ingrediente");
            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    torta = new ConPanna(torta);
                    break;
                case "2":
                    torta = new ConFragole(torta);
                    break;
                case "3":
                    torta = new ConGlassa(torta);
                    break;
                case "0":
                    aggiungi = false;
                    break;
                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }

        Console.WriteLine("\nLa tua torta completa è: ");
        Console.WriteLine(torta.Descrizione());
    }
}
