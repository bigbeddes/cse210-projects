using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
        
        Square square = new Square("Purple", 5);
        shapes.Add(square);

        Rectangle rectangle = new Rectangle("White", 10, 13);
        shapes.Add(rectangle);

        Circle circle = new Circle("Black", 40);
        shapes.Add(circle);

        foreach (Shape i in shapes)
        {
            string color = i.GetColor();
            double area = i.GetArea();
            Console.WriteLine($"The {color} shape has an area of {area}.");
        }
    }
}