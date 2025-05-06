using System;

// 1. Component: definisce l'interfaccia dell'oggetto
public interface IComponent
{
    void Operation();
}

// 2. ConcreteComponent: oggetto base senza decorazioni
public class ConcreteComponent : IComponent
{
    public void Operation()
    {
        Console.WriteLine("ConcreteComponent: operazione di base");
    }
}

// 3. Decorator: classe astratta che implementa IComponent 
//    e incapsula un IComponent interno
public abstract class Decorator : IComponent
{
    // Riferimento al componente "decorato"
    protected IComponent _component;

    // Costruttore: richiede un componente da decorare
    protected Decorator(IComponent component)
    {
        _component = component;
    }

    // Delegazione dell'operazione al componente interno
    public virtual void Operation()
    {
        _component.Operation();
    }
}

// 4. ConcreteDecoratorA: aggiunge comportamento prima e dopo la chiamata
public class ConcreteDecoratorA : Decorator
{
    public ConcreteDecoratorA(IComponent component) 
        : base(component) { }

    public override void Operation()
    {
        Console.WriteLine("ConcreteDecoratorA: pre‑operazione");
        base.Operation();  // chiama Operation() sul componente interno
        Console.WriteLine("ConcreteDecoratorA: post‑operazione");
    }
}

// 5. ConcreteDecoratorB: aggiunge un altro comportamento distinto
public class ConcreteDecoratorB : Decorator
{
    public ConcreteDecoratorB(IComponent component) 
        : base(component) { }

    public override void Operation()
    {
        Console.WriteLine("ConcreteDecoratorB: aggiunta funzionalità prima");
        base.Operation();
    }
}

// Esempio di utilizzo (Client)
class Program
{
    static void Main()
    {
        // Oggetto di base
        IComponent component = new ConcreteComponent();
        Console.WriteLine("Client: chiamata diretta al ConcreteComponent:");
        component.Operation();

        // Decoro con A
        IComponent decoratorA = new ConcreteDecoratorA(component);
        Console.WriteLine("\nClient: ConcreteComponent decorato con A:");
        decoratorA.Operation();

        // Decoro con A poi B (catena di decorator)
        IComponent decoratorB = new ConcreteDecoratorB(decoratorA);
        Console.WriteLine("\nClient: ConcreteComponent decorato con A e poi B:");
        decoratorB.Operation();
    }
}
