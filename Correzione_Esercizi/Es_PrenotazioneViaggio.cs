using System;

public class PrenotazioneViaggio
{
    // Campo privato: non accessibile direttamente dall'esterno
    private int postiPrenotati = 0;
    private const int maxPosti = 20;

    // Proprietà pubblica per la destinazione
    public string Destinazione { get; set; }

    // Proprietà di sola lettura per i posti prenotati
    public int PostiPrenotati
    {
        get { return postiPrenotati; }
    }

    // Proprietà calcolata: quanti posti sono ancora disponibili
    public int PostiDisponibili
    {
        get { return maxPosti - postiPrenotati; }
    }

    // Metodo per prenotare posti, solo se disponibili
    public void PrenotaPosti(int numero)
    {
        if (numero <= 0)
        {
            Console.WriteLine("Numero non valido.");
        }
        else if (numero <= PostiDisponibili)
        {
            postiPrenotati += numero;
            Console.WriteLine($"{numero} posti prenotati con successo.");
        }
        else
        {
            Console.WriteLine("Posti insufficienti disponibili.");
        }
    }

    // Metodo per annullare una parte della prenotazione
    public void AnnullaPrenotazione(int numero)
    {
        if (numero <= 0)
        {
            Console.WriteLine("Numero non valido.");
        }
        else if (numero <= postiPrenotati)
        {
            postiPrenotati -= numero;
            Console.WriteLine($"{numero} posti annullati con successo.");
        }
        else
        {
            Console.WriteLine("Non puoi annullare più posti di quelli prenotati.");
        }
    }

    // Metodo per stampare le info aggiornate
    public void StampaDettagli()
    {
        Console.WriteLine($"\nDestinazione: {Destinazione}");
        Console.WriteLine($"Posti prenotati: {PostiPrenotati}");
        Console.WriteLine($"Posti disponibili: {PostiDisponibili}\n");
    }
}

public class Program
{
    public static void Main()
    {
        // Creazione della prenotazione
        PrenotazioneViaggio viaggio = new PrenotazioneViaggio();

        Console.Write("Inserisci la destinazione del viaggio: ");
        viaggio.Destinazione = Console.ReadLine();

        viaggio.StampaDettagli();

        // Esempio di prenotazione
        viaggio.PrenotaPosti(5);
        viaggio.StampaDettagli();

        viaggio.PrenotaPosti(10);
        viaggio.StampaDettagli();

        viaggio.AnnullaPrenotazione(3);
        viaggio.StampaDettagli();

        viaggio.PrenotaPosti(100); // Esempio negativo
        viaggio.AnnullaPrenotazione(50); // Altro esempio negativo
    }
}
