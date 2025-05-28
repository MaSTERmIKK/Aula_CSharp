using System;
using System.Collections.Generic;

// Singleton: Configurazione globale del sistema
public class ConfigurazioneSistema
{
    private static ConfigurazioneSistema istanza;
    private Dictionary<string, string> configurazioni;

    private ConfigurazioneSistema()
    {
        configurazioni = new Dictionary<string, string>();
    }

    public static ConfigurazioneSistema Instance
    {
        get
        {
            if (istanza == null)
                istanza = new ConfigurazioneSistema();
            return istanza;
        }
    }

    public void Imposta(string chiave, string valore)
    {
        configurazioni[chiave] = valore;
    }

    public string Leggi(string chiave)
    {
        return configurazioni.ContainsKey(chiave) ? configurazioni[chiave] : "(chiave non trovata)";
    }

    public void StampaTutte()
    {
        Console.WriteLine("--- CONFIGURAZIONI ATTUALI ---");
        foreach (var coppia in configurazioni)
        {
            Console.WriteLine($"{coppia.Key}: {coppia.Value}");
        }
    }
}

public class ModuloA
{
    public void Configura()
    {
        var config = ConfigurazioneSistema.Instance;
        config.Imposta("lingua", "IT");
        config.Imposta("tema", "scuro");
    }
}

public class ModuloB
{
    public void Configura()
    {
        var config = ConfigurazioneSistema.Instance;
        config.Imposta("volume", "80");
        config.Imposta("notifiche", "attive");
    }
}

public class Program
{
    public static void Main()
    {
        ModuloA a = new ModuloA();
        ModuloB b = new ModuloB();

        a.Configura();
        b.Configura();

        ConfigurazioneSistema.Instance.StampaTutte();

        Console.WriteLine("Verifica accesso unificato: " +
            (Object.ReferenceEquals(ConfigurazioneSistema.Instance, ConfigurazioneSistema.Instance)));
    }
}
