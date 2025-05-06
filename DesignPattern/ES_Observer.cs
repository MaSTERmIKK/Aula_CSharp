using System;
using System.Collections.Generic;

// 1. Observer: interfaccia che definisce il metodo di notifica
public interface IObserver
{
    void Update(int newState);
}

// 2. Subject: interfaccia che permette di aggiungere/rimuovere observer e notificare
public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}

// 3. ConcreteSubject: implementa ISubject e mantiene lo stato osservato
public class ConcreteSubject : ISubject
{
    private readonly List<IObserver> _observers = new List<IObserver>();
    private int _state;

    // Proprietà dello stato; quando cambia, notifica gli observer
    public int State
    {
        get => _state;
        set
        {
            _state = value;
            Notify();
        }
    }

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.Update(_state);
        }
    }
}

// 4. ConcreteObserver: implementa la logica di reazione alla notifica
public class ConcreteObserver : IObserver
{
    private readonly string _name;
    private int _observerState;

    public ConcreteObserver(string name)
    {
        _name = name;
    }

    // Viene chiamato dal Subject con il nuovo stato
    public void Update(int newState)
    {
        _observerState = newState;
        Console.WriteLine($"{_name} ha ricevuto aggiornamento, stato = {_observerState}");
    }
}

// 5. Client: crea il subject e alcuni observer, e modella cambi di stato
class Program
{
    static void Main()
    {
        var subject = new ConcreteSubject();

        var observerA = new ConcreteObserver("Observer A");
        var observerB = new ConcreteObserver("Observer B");

        // Registrazione degli observer
        subject.Attach(observerA);
        subject.Attach(observerB);

        // Cambia lo stato: innesca Notify() e chiama Update() su tutti gli observer
        subject.State = 5;
        subject.State = 10;

        // Rimuove un observer
        subject.Detach(observerA);

        // Ancora un cambiamento di stato: solo Observer B verrà notificato
        subject.State = 15;
    }
}
