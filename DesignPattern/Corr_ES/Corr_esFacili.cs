// Soluzioni agli esercizi sui Design Pattern in C#
// File: SoluzioniEserciziDesignPattern.cs

#region Esercizio 1: Singleton Logger
// Descrizione: Implementare una classe Logger che mantenga un'unica istanza
//              e registri messaggi di log in una lista interna.

public sealed class Logger
{
    // Campo statico per l'istanza singola
    private static readonly Logger _instance = new Logger();

    // Lista dei messaggi di log
    private readonly List<string> _logs = new List<string>();

    // Costruttore privato: impedisce l'istanziazione esterna
    private Logger() { }

    // Proprietà pubblica per accedere all'istanza unica
    public static Logger Instance
    {
        get
        {
            return _instance;
        }
    }

    // Metodo per aggiungere un messaggio di log
    public void Log(string message)
    {
        _logs.Add(message);
    }

    // Metodo per stampare tutti i log
    public void PrintLogs()
    {
        Console.WriteLine("--- Logger Output ---");
        foreach (var msg in _logs)
        {
            Console.WriteLine(msg);  // Stampa ogni messaggio
        }
    }
}

// Client di prova
public class ProgramSingleton
{
    public static void Main()
    {
        // Chiamate al logger da punti diversi
        Logger.Instance.Log("Primo messaggio");
        Logger.Instance.Log("Secondo messaggio");

        // Stampa dei log: deve mostrare entrambi i messaggi
        Logger.Instance.PrintLogs();
    }
}
#endregion


#region Esercizio 2: Factory Method Shapes
// Descrizione: Creare IShape, Circle, Square e due ConcreteShapeCreator
//              che restituiscono il prodotto richiesto.

public interface IShape
{
    void Draw();  // Metodo per disegnare la forma
}

public class Circle : IShape
{
    public void Draw()
    {
        Console.WriteLine("Disegna un cerchio");
    }
}

public class Square : IShape
{
    public void Draw()
    {
        Console.WriteLine("Disegna un quadrato");
    }
}

public abstract class ShapeCreator
{
    // Factory Method: restituisce una IShape in base al tipo
    public abstract IShape CreateShape(string type);
}

public class ConcreteShapeCreator : ShapeCreator
{
    public override IShape CreateShape(string type)
    {
        // Selezione del prodotto in base al parametro
        switch (type.ToLower())
        {
            case "circle":
                return new Circle();
            case "square":
                return new Square();
            default:
                throw new ArgumentException("Tipo di forma non supportato");
        }
    }
}

public class ProgramFactory
{
    public static void Main()
    {
        var creator = new ConcreteShapeCreator();
        Console.WriteLine("Digita 'circle' o 'square':");
        string input = Console.ReadLine();

        // Creazione del prodotto via factory
        IShape shape = creator.CreateShape(input);
        shape.Draw();  // Disegna la forma richiesta
    }
}
#endregion


#region Esercizio 3: Observer NewsAgency
// Descrizione: Implementare NewsAgency (Subject) e due subscriber

public interface INewsSubscriber
{
    void Update(string news);
}

public interface INewsAgency
{
    void Attach(INewsSubscriber subscriber);
    void Detach(INewsSubscriber subscriber);
    void Notify();
}

public class NewsAgency : INewsAgency
{
    private readonly List<INewsSubscriber> _subscribers = new List<INewsSubscriber>();
    private string _news;

    // Proprietà News: quando cambia, notifica tutti i subscriber
    public string News
    {
        get => _news;
        set
        {
            _news = value;
            Notify();  // Notifica automatica al cambiamento
        }
    }

    public void Attach(INewsSubscriber subscriber)
    {
        _subscribers.Add(subscriber);
    }

    public void Detach(INewsSubscriber subscriber)
    {
        _subscribers.Remove(subscriber);
    }

    public void Notify()
    {
        foreach (var sub in _subscribers)
        {
            sub.Update(_news);  // Chiamata a Update di ogni subscriber
        }
    }
}

public class MobileApp : INewsSubscriber
{
    public void Update(string news)
    {
        Console.WriteLine($"MobileApp Notification: {news}");
    }
}

public class EmailClient : INewsSubscriber
{
    public void Update(string news)
    {
        Console.WriteLine($"EmailClient Sent: {news}");
    }
}

public class ProgramObserver
{
    public static void Main()
    {
        var agency = new NewsAgency();
        var mobile = new MobileApp();
        var email = new EmailClient();

        // Registrazione dei subscriber
        agency.Attach(mobile);
        agency.Attach(email);

        // Cambiamento delle news
        agency.News = "Ultime notizie: Design Pattern in C#!";
        agency.News = "Breaking: Observer Pattern implementato con successo.";
    }
}
#endregion


#region Esercizio 4: Decorator Text Formatting
// Descrizione: Decorare un testo con Bold e Italic dinamicamente

public interface IText
{
    void Print();  // Stampa il testo formattato
}

public class PlainText : IText
{
    private readonly string _text;
    public PlainText(string text)
    {
        _text = text;
    }

    public void Print()
    {
        Console.WriteLine(_text);  // Stampa testo base
    }
}

public abstract class TextDecorator : IText
{
    protected IText _innerText;
    public TextDecorator(IText inner)
    {
        _innerText = inner;
    }

    public virtual void Print()
    {
        _innerText.Print();  // Delegazione di default
    }
}

public class BoldDecorator : TextDecorator
{
    public BoldDecorator(IText inner) : base(inner) { }

    public override void Print()
    {
        Console.Write("**");         // Apertura grassetto
        base.Print();               // Stampa testo interno
        Console.WriteLine("**");   // Chiusura grassetto
    }
}

public class ItalicDecorator : TextDecorator
{
    public ItalicDecorator(IText inner) : base(inner) { }

    public override void Print()
    {
        Console.Write("_");          // Apertura corsivo
        base.Print();               // Stampa testo interno
        Console.WriteLine("_");    // Chiusura corsivo
    }
}

public class ProgramDecorator
{
    public static void Main()
    {
        IText text = new PlainText("Hello, Design Patterns!");

        Console.WriteLine("Testo base:");
        text.Print();  // Stampa semplice

        Console.WriteLine("
Decorato in grassetto:");
        IText bold = new BoldDecorator(text);
        bold.Print();  // Stampa con ** … **

        Console.WriteLine("
Grassetto + Corsivo (catena):");
        IText boldItalic = new ItalicDecorator(bold);
        boldItalic.Print();  // Stampa con _** … **_
    }
}
#endregion


#region Esercizio 5: Strategy Payment
// Descrizione: Scegliere strategia di pagamento a runtime

public interface IPaymentStrategy
{
    void Pay(decimal amount);  // Metodo di pagamento
}

public class CreditCardPayment : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Pagamento di {amount}€ con Credit Card.");
    }
}

public class PayPalPayment : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Pagamento di {amount}€ via PayPal.");
    }
}

public class BitcoinPayment : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Pagamento di {amount}€ in Bitcoin.");
    }
}

public class PaymentContext
{
    private IPaymentStrategy _strategy;

    // Imposta la strategia scelta
    public void SetStrategy(IPaymentStrategy strategy)
    {
        _strategy = strategy;
    }

    // Esegue il pagamento con la strategia corrente
    public void Pay(decimal amount)
    {
        if (_strategy == null)
        {
            Console.WriteLine("Nessuna strategia di pagamento selezionata.");
            return;
        }
        _strategy.Pay(amount);
    }
}

public class ProgramStrategy
{
    public static void Main()
    {
        var context = new PaymentContext();

        Console.WriteLine("Scegli metodo di pagamento: 1=CreditCard, 2=PayPal, 3=Bitcoin");
        string choice = Console.ReadLine();

        // Selezione strategia in base all'input utente
        switch (choice)
        {
            case "1": context.SetStrategy(new CreditCardPayment()); break;
            case "2": context.SetStrategy(new PayPalPayment()); break;
            case "3": context.SetStrategy(new BitcoinPayment()); break;
            default:
                Console.WriteLine("Scelta non valida.");
                return;
        }

        // Simula il pagamento di 100€
        context.Pay(100m);
    }
}
#endregion
