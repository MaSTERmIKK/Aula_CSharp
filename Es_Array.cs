using System;

class Program
{
    static void Main()
    {
        // Creiamo un array di 5 elementi per contenere i voti
        int[] voti = new int[5];

        // Inserimento dei voti da tastiera
        for (int i = 0; i < voti.Length; i++)
        {
            Console.Write($"Inserisci il voto {i + 1}: ");
            voti[i] = int.Parse(Console.ReadLine());
        }

        // Calcolo della media
        int somma = 0;
        for (int i = 0; i < voti.Length; i++)
        {
            somma += voti[i];
        }

        float media = (float)somma / voti.Length;
        Console.WriteLine($"La media dei voti è: {media}");
    }
}
