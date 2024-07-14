public interface Shape
{
    void Draw();
}

public class Circle : Shape
{
    public void Draw()
    {
        Console.WriteLine("Drawing a Circle");
    }
}

public class Rectangle : Shape
{
    public void Draw()
    {
        Console.WriteLine("Drawing a Rectangle");
    }
}

public class Program
{
    public static void RenderShape(Shape shape)
    {
        shape.Draw();
    }

    public static void Main()
    {
        Shape[] shapes = { new Circle(), new Rectangle() };

        foreach (var shape in shapes)
        {
            RenderShape(shape);
        }
    }
}
