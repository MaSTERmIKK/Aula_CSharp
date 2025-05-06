public sealed class Singleton
{
    // Riferimento all’unica istanza (inizialmente null)
    private static Singleton _instance;
    
    // Oggetto di lock per garantire il thread‑safety
    private static readonly object _lock = new object();

    // Costruttore privato: impedisce 'new Singleton()' dall’esterno
    private Singleton()
    {
        // Codice di inizializzazione (es. caricamento configurazione)
    }

    // Punto di accesso globale all’istanza
    public static Singleton Instance
    {
        get
        {
            // Primo controllo "senza lock" per performance
            if (_instance == null)
            {
                lock (_lock) // Se due thread arrivano qui, uno atterra nel lock
                {
                    // Secondo controllo dentro il lock per evitare doppia creazione
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                    }
                }
            }
            return _instance;
        }
    }

    // Metodo d’esempio che utilizza l’istanza singleton
    public void DoSomething()
    {
        Console.WriteLine("Metodo DoSomething chiamato sull'istanza Singleton.");
    }
}
