using System;

public class VoloAereo
{
    // Campo privato: protegge i dati interni
    private int postiOccupati = 0;
    private const int maxPosti = 150;

    // Proprietà pubblica per identificare il volo
    public string CodiceVolo { get; set; }

    // Proprietà di sola lettura: quanti posti sono già occupati
    public int PostiOccupati
    {
        get { return postiOccupati; }
    }

    // Proprietà di sola lettura: quanti posti sono ancora disponibili
    public int PostiLiberi
    {
        get { return maxPosti - postiOccupati; }
    }

    // Metodo per prenotare posti, solo se disponibili
    public void EffettuaPrenotazione(int numeroPosti)
    {
        if (numeroPosti <= 0)
        {
            Console.WriteLine("Numero di posti non valido.");
        }
        else if (numeroPosti <= PostiLiberi)
        {
            postiOccupati += numeroPosti;
            Console.WriteLine($"{numeroPosti} posti prenotati con successo.");
        }
        else
        {
            Console.WriteLine("Posti insufficienti disponibili.");
        }
    }

    // Metodo per annullare una parte della prenotazione
    public void AnnullaPrenotazione(int numeroPosti)
    {
        if (numeroPosti <= 0)
        {
            Console.WriteLine("Numero di posti non valido.");
        }
        else if (numeroPosti <= postiOccupati)
        {
            postiOccupati -= numeroPosti;
            Console.WriteLine($"{numeroPosti} posti annullati con successo.");
        }
        else
        {
            Console.WriteLine("Non puoi annullare più posti di quelli occupati.");
        }
    }

    // Metodo per stampare le informazioni aggiornate
    public void VisualizzaStato()
    {
        Console.WriteLine($"\nCodice Volo: {CodiceVolo}");
        Console.WriteLine($"Posti occupati: {PostiOccupati}");
        Console.WriteLine($"Posti disponibili: {PostiLiberi}\n");
    }
}

public class Program
{
    public static void Main()
    {
        VoloAereo volo = new VoloAereo();

        Console.Write("Inserisci il codice del volo: ");
        volo.CodiceVolo = Console.ReadLine();

        volo.VisualizzaStato();

        // Esempi di operazioni
        volo.EffettuaPrenotazione(50);
        volo.VisualizzaStato();

        volo.EffettuaPrenotazione(80);
        volo.VisualizzaStato();

        volo.AnnullaPrenotazione(30);
        volo.VisualizzaStato();

        volo.EffettuaPrenotazione(60); // Supera i posti disponibili
        volo.AnnullaPrenotazione(200); // Annullamento errato
    }
}
