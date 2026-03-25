using System;
class Box
{
    public double width;
    public double height;
    public double length;

    // Constructor 1
    public Box(double width, double height, double length)
    {
        this.width = width;
        this.height = height;
        this.length = length;
    }

    // Constructor 2 (ลูกบาศก์)
    public Box(double side)
    {
        this.width = side;
        this.height = side;
        this.length = side;
    }

    // Constructor 3 (Copy)
    public Box(Box oldBox)
    {
        this.width = oldBox.width;
        this.height = oldBox.height;
        this.length = oldBox.length;
    }
    public double faceArea()
    {
        return width * height;
    }
    public double topArea()
    {
        return width * length;
    }
    public double sideArea()
    {
        return height * length;
    }
    public double area()
    {
        return 2 * faceArea() + 2 * topArea() + 2 * sideArea();
    }
}
class Program
{
    static void Main()
    {
        Console.WriteLine("=== โปรแกรมคำนวณพื้นที่ผิวกล่อง ===\n");
        Console.WriteLine("เลือกประเภทกล่อง:");
        Console.WriteLine("1. กล่องสี่เหลี่ยมทั่วไป (กำหนดความ กว้าง ยาว สูง)");
        Console.WriteLine("2. กล่องสี่เหลี่ยมลูกบาศก์ (ด้านเท่ากัน)");
        Console.Write("เลือก (1-2): ");
        int choice = int.Parse(Console.ReadLine());

        Box box;

        if (choice == 1)
        {
            Console.Write("กรอก Width: ");
            double w = double.Parse(Console.ReadLine());

            Console.Write("กรอก Height: ");
            double h = double.Parse(Console.ReadLine());

            Console.Write("กรอก Length: ");
            double l = double.Parse(Console.ReadLine());

            box = new Box(w, h, l);
        }
        else
        {
            Console.Write("กรอกด้าน (Side): ");
            double s = double.Parse(Console.ReadLine());

            box = new Box(s);
        }

        Console.WriteLine("\n--- ผลลัพธ์ ---");
        Console.WriteLine("Face Area = " + box.faceArea());
        Console.WriteLine("Top Area = " + box.topArea());
        Console.WriteLine("Side Area = " + box.sideArea());
        Console.WriteLine("Surface Area = " + box.area());

        Box copyBox = new Box(box);
        Console.WriteLine("\nCopy Box Surface Area = " + copyBox.area());
    }
}