using System;
using System.Collections.Generic;

// Interfaccia Observer
public interface INewsSubscriber
{
    void Update(string news);
}

// Subject (singleton)
public class NewsAgency
{
    // Singleton instance
    private static NewsAgency _instance = null;
    public static NewsAgency Instance
    {
        get
        {
            if (_instance == null)
                _instance = new NewsAgency();
            return _instance;
        }
    }

    private INewsSubscriber subscriber; // Limitiamo a uno solo!

    private string news;
    public string News
    {
        get { return news; }
        set
        {
            news = value;
            Notify(); // Ogni volta che cambia la news, notifichiamo
        }
    }

    // Metodo per registrare il subscriber (uno solo)
    public void Register(INewsSubscriber newSubscriber)
    {
        subscriber = newSubscriber; // Sovrascrive il precedente se già c'era
    }

    // Metodo per notificare il subscriber
    private void Notify()
    {
        if (subscriber != null)
            subscriber.Update(news);
    }
}

// Subscriber 1
public class MobileApp : INewsSubscriber
{
    public void Update(string news)
    {
        Console.WriteLine($"Notification on mobile: {news}");
    }
}

// Subscriber 2
public class EmailClient : INewsSubscriber
{
    public void Update(string news)
    {
        Console.WriteLine($"Email sent: {news}");
    }
}

// Main per testare
class Program
{
    static void Main(string[] args)
    {
        var agency = NewsAgency.Instance;

        // Registriamo MobileApp
        INewsSubscriber mobile = new MobileApp();
        agency.Register(mobile);

        agency.News = "Breaking: Observer Pattern Rocks!";
        // Output: Notification on mobile: Breaking: Observer Pattern Rocks!

        // Cambiamo subscriber a EmailClient
        INewsSubscriber email = new EmailClient();
        agency.Register(email);

        agency.News = "Update: Singleton in action!";
        // Output: Email sent: Update: Singleton in action!
    }
}
