
using System;

public class Operazioni
{
    // Metodo che restituisce la somma di due numeri
    public int Somma(int a, int b)
    {
        return a + b;
    }

    // Metodo che restituisce il prodotto di due numeri
    public int Moltiplica(int a, int b)
    {
        return a * b;
    }

    // Metodo che stampa il risultato di un'operazione
    public void StampaRisultato(string operazione, int risultato)
    {
        Console.WriteLine($"Il risultato dell'operazione {operazione} è: {risultato}");
    }
}

public class Programma
{
    public static void Main()
    {
        Operazioni op = new Operazioni();

        // Chiede due numeri all'utente
        Console.Write("Inserisci il primo numero: ");
        int num1 = int.Parse(Console.ReadLine());

        Console.Write("Inserisci il secondo numero: ");
        int num2 = int.Parse(Console.ReadLine());

        // Calcola somma e prodotto
        int somma = op.Somma(num1, num2);
        int prodotto = op.Moltiplica(num1, num2);

        // Stampa i risultati
        op.StampaRisultato("Somma", somma);
        op.StampaRisultato("Moltiplicazione", prodotto);
    }
}
