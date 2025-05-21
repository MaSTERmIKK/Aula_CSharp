using System;
using System.Collections.Generic;

public class Film
{
    public string Titolo;
    public string Regista;
    public int Anno;
    public string Genere;

    // Costruttore per inizializzare un film
    public Film(string titolo, string regista, int anno, string genere)
    {
        Titolo = titolo;
        Regista = regista;
        Anno = anno;
        Genere = genere;
    }

    // Metodo per stampare le informazioni del film
    public void StampaInfo()
    {
        Console.WriteLine($"{Titolo} ({Anno}) - Regia: {Regista}, Genere: {Genere}");
    }
}

public class Program
{
    public static void Main()
    {
        List<Film> videoteca = new List<Film>();

        // Inserimento di 3 film
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"\nInserisci i dati del film #{i + 1}");

            Console.Write("Titolo: ");
            string titolo = Console.ReadLine();

            Console.Write("Regista: ");
            string regista = Console.ReadLine();

            Console.Write("Anno: ");
            int anno = int.Parse(Console.ReadLine());

            Console.Write("Genere: ");
            string genere = Console.ReadLine();

            Film film = new Film(titolo, regista, anno, genere);
            videoteca.Add(film); // Aggiunge il film alla lista
        }

        // Stampa di tutti i film
        Console.WriteLine("\n--- TUTTI I FILM INSERITI ---");
        foreach (Film f in videoteca)
        {
            f.StampaInfo();
        }

        // Ricerca per genere
        Console.Write("\nInserisci un genere per cercare film: ");
        string ricercaGenere = Console.ReadLine();

        Console.WriteLine($"\n--- FILM TROVATI NEL GENERE '{ricercaGenere}' ---");
        foreach (Film f in videoteca)
        {
            if (f.Genere.ToLower() == ricercaGenere.ToLower())
            {
                f.StampaInfo();
            }
        }
    }
}
