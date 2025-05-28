using System;

// Interfaccia IShape con metodo Draw
public interface IShape
{
    void Draw();
}

// Classe concreta Circle
public class Circle : IShape
{
    public void Draw()
    {
        Console.WriteLine("Disegno un Cerchio.");
    }
}

// Classe concreta Square
public class Square : IShape
{
    public void Draw()
    {
        Console.WriteLine("Disegno un Quadrato.");
    }
}

// Classe astratta ShapeCreator con metodo CreateShape
public abstract class ShapeCreator
{
    public abstract IShape CreateShape();
}

// ConcreteShapeCreator per Circle
public class CircleCreator : ShapeCreator
{
    public override IShape CreateShape()
    {
        return new Circle();
    }
}

// ConcreteShapeCreator per Square
public class SquareCreator : ShapeCreator
{
    public override IShape CreateShape()
    {
        return new Square();
    }
}

// Client
public class Client
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Quale forma vuoi disegnare? (circle/square)");
        string tipoForma = Console.ReadLine().ToLower();

        ShapeCreator creator;

        switch (tipoForma)
        {
            case "circle":
                creator = new CircleCreator();
                break;

            case "square":
                creator = new SquareCreator();
                break;

            default:
                Console.WriteLine("Tipo forma non riconosciuto.");
                return;
        }

        IShape shape = creator.CreateShape();
        shape.Draw();
    }
}
