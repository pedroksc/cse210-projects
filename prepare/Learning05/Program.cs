using System;



List<Shape> shapes = new List<Shape>();

shapes.Add(new Square("Red", 4));
shapes.Add(new Rectangle("Blue", 6, 3));
shapes.Add(new Circle("Green", 5));
shapes.Add(new Square("Yellow", 2.5));

Console.WriteLine("Paper Shape Area Report");
Console.WriteLine("=======================");

foreach (Shape shape in shapes)
{
    string color = shape.GetColor();
    double area = shape.GetArea();
    Console.WriteLine($"Color: {color,-7} Area: {area:F2}");
}