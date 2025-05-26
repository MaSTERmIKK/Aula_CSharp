using System;
using System.Collections.Generic;

// Interfaccia comune
public interface IPagamento
{
    void EseguiPagamento(decimal importo);
    void MostraMetodo();
}

public class PagamentoCarta : IPagamento
{
    public string Circuito { get; set; }

    public PagamentoCarta(string circuito)
    {
        Circuito = circuito;
    }

    public void EseguiPagamento(decimal importo)
    {
        Console.WriteLine($"Pagamento di {importo} euro con carta (Circuito: {Circuito})");
    }

    public void MostraMetodo()
    {
        Console.WriteLine("Metodo: Carta di credito");
    }
}

public class PagamentoContanti : IPagamento
{
    public void EseguiPagamento(decimal importo)
    {
        Console.WriteLine($"Pagamento di {importo} euro in contanti");
    }

    public void MostraMetodo()
    {
        Console.WriteLine("Metodo: Contanti");
    }
}

public class PagamentoPayPal : IPagamento
{
    public string EmailUtente { get; set; }

    public PagamentoPayPal(string email)
    {
        EmailUtente = email;
    }

    public void EseguiPagamento(decimal importo)
    {
        Console.WriteLine($"Pagamento di {importo} euro tramite PayPal da: {EmailUtente}");
    }

    public void MostraMetodo()
    {
        Console.WriteLine("Metodo: PayPal");
    }
}

public class Program
{
    public static void Main()
    {
        List<IPagamento> pagamenti = new List<IPagamento>();
        pagamenti.Add(new PagamentoCarta("Visa"));
        pagamenti.Add(new PagamentoContanti());
        pagamenti.Add(new PagamentoPayPal("utente@example.com"));

        foreach (IPagamento p in pagamenti)
        {
            p.MostraMetodo();
            p.EseguiPagamento(100);
            Console.WriteLine();
        }

        Console.WriteLine("Programma terminato.");
    }
}
