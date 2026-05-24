namespace Hw7
{
    internal class Program
    {
        abstract class Figure
        {
            public string Name { get; set; }

            public Figure(string name)
            {
                Name = name;
            }

            public abstract void GetArea();
            public abstract void GetPerimeter();
        }
        class Triangle : Figure
        {
            public int Side1 { get; set; }
            public int Side2 { get; set; }
            public int Side3 { get; set; }
            public Triangle() : base("Triangle")
            {
                Side1 = 3;
                Side2 = 4;
                Side3 = 5;
            }
            public Triangle(int s1, int s2, int s3) : base("Triangle"){ 
                Side1 = s1;
                Side2 = s2;
                Side3 = s3;
            }
            public override void GetArea()
            {
                Console.WriteLine("Triangle area");
            }

            public override void GetPerimeter()
            {
                Console.WriteLine("Triangle: Perimeter");
            }
        }
        class Square : Figure
        {
            public double Side { get; set; }
            public override void GetArea()
            {
                Console.WriteLine("Square: Area");
            }
            public override void GetPerimeter()
            {
                Console.WriteLine("Square: Perimeter");
            }
            public Square() : base("Square")
            {
                Side = 5;
            }

            public Square(double side) : base("Square")
            {
                Side = side;
            }
        }
        class Circle : Figure
        {
            public double Radius { get; set; }
            public override void GetArea()
            {
                Console.WriteLine("Circle: Area");
            }
            public override void GetPerimeter()
            {
                Console.WriteLine("Circle: Perimeter");
            }
            public Circle() : base("Circle")
            {
                Radius = 5;
            }
            public Circle(double radius) : base("Circle")
            {
                Radius = radius;
            }
        }
        class Rectangle : Figure
        {
            public double Width { get; set; }
            public double Height { get; set; }
            public override void GetArea()
            {
                Console.WriteLine("Rectangle: Area");
            }
            public override void GetPerimeter()
            {
                Console.WriteLine("Rectangle: Perimeter");
            }
            public Rectangle() : base("Rectangle")
            {
                Width = 4;
                Height = 6;
            }
            public Rectangle(double width, double height) : base("Rectangle")
            {
                Width = width;
                Height = height;
            }
        }
        class Rhombus : Figure
        {
            public double Diagonal1 { get; set; }
            public double Diagonal2 { get; set; }
            public double Side { get; set; }
            public override void GetArea()
            {
                Console.WriteLine("Rhombus: Area");
            }
            public override void GetPerimeter()
            {
                Console.WriteLine("Rhombus: Perimeter");
            }
            public Rhombus() : base("Rhombus")
            {
                Diagonal1 = 6;
                Diagonal2 = 8;
                Side = 5;
            }
            public Rhombus(double d1, double d2, double side) : base("Rhombus")
            {
                Diagonal1 = d1;
                Diagonal2 = d2;
                Side = side;
            }
        }
        class Parallelogram : Figure
        {
            public double Base { get; set; }
            public double Side { get; set; }
            public double Height { get; set; }
            public override void GetArea()
            {
                Console.WriteLine("Parallelogram: Area");
            }
            public override void GetPerimeter()
            {
                Console.WriteLine("Parallelogram: Perimeter");
            }
            public Parallelogram() : base("Parallelogram")
            {
                Base = 5;
                Side = 4;
                Height = 3;
            }
            public Parallelogram(double baseLength, double side, double height) : base("Parallelogram")
            {
                Base = baseLength;
                Side = side;
                Height = height;
            }
        }
        class Trapezoid : Figure
        {
            public double Base1 { get; set; }
            public double Base2 { get; set; }
            public double Side1 { get; set; }
            public double Side2 { get; set; }
            public double Height { get; set; }
            public override void GetArea()
            {
                Console.WriteLine("Trapezoid: Area");
            }
            public override void GetPerimeter()
            {
                Console.WriteLine("Trapezoid: Perimeter");
            }
            public Trapezoid() : base("Trapezoid")
            {
                Base1 = 8;
                Base2 = 5;
                Side1 = 4;
                Side2 = 4;
                Height = 3;
            }
            public Trapezoid(double b1, double b2, double s1, double s2, double h) : base("Trapezoid")
            {
                Base1 = b1;
                Base2 = b2;
                Side1 = s1;
                Side2 = s2;
                Height = h;
            }
        }
        class Ellipse : Figure
        {
            public double Idk { get; set; }
            public override void GetArea()
            {
                Console.WriteLine("Ellipse: Area");
            }
            public override void GetPerimeter()
            {
                Console.WriteLine("Ellipse: Perimeter");
            }
            public Ellipse() : base("Ellipse") { 
                Idk = 0;
            }
            public Ellipse(double idk):base("Ellipse")
            {
                Idk = idk;
            }
        }
        class CompositeFigure : Figure {
            public Figure[] figures;
            public CompositeFigure(params Figure[] figures) : base("Composite Figure")
            {
                this.figures = figures;
            }
            public override void GetArea()
            {
                Console.WriteLine("CompositeFigure: area");
                foreach (var figure in figures) {
                    figure.GetArea();
                }
            }
            public override void GetPerimeter()
            {
                Console.WriteLine("CompositeFigure: Permtr");
                foreach (var figure in figures)
                {
                    figure.GetPerimeter();
                }
            }
        }

        static void Main(string[] args)
        {
            Figure[] figures = new Figure[5];
            figures[1] = new Circle();
            figures[2] = new Rectangle();
            figures[3] = new Ellipse();
            figures[4] = new Square();
            figures[0] = new Rhombus();
            CompositeFigure cf = new CompositeFigure(figures);
            cf.GetArea();
            cf.GetPerimeter();
            CompositeFigure cf1 = new CompositeFigure(figures[0], figures[1]);
            cf1.GetPerimeter();
        }
    }
}
