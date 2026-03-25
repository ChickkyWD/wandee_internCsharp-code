using System;
class Program
{
    static void Main()
    {
        // จำนวนแบงค์และเหรียญเริ่มต้น
        int b1000, b500, b100, b50, c10, c5, c1;

        Console.WriteLine("กรุณากรอกจำนวนแบงค์ และเหรียญเริ่มต้นของท่าน\n");

        Console.Write("แบงค์ 1000: ");
        b1000 = int.Parse(Console.ReadLine());

        Console.Write("แบงค์ 500: ");
        b500 = int.Parse(Console.ReadLine());

        Console.Write("แบงค์ 100: ");
        b100 = int.Parse(Console.ReadLine());

        Console.Write("แบงค์ 50: ");
        b50 = int.Parse(Console.ReadLine());

        Console.Write("เหรียญ 10: ");
        c10 = int.Parse(Console.ReadLine());

        Console.Write("เหรียญ 5: ");
        c5 = int.Parse(Console.ReadLine());

        Console.Write("เหรียญ 1: ");
        c1 = int.Parse(Console.ReadLine());

        while (true)
        {
            Console.Write("\nต้องการทอน: ");
            int money = int.Parse(Console.ReadLine());

            int total = b1000 * 1000 + b500 * 500 + b100 * 100 + b50 * 50 + c10 * 10 + c5 * 5 + c1;
            if (money > total)
            {
                Console.WriteLine("ไม่สามารถทอนได้ เนื่องจากเงินไม่พอ");
                continue;
            }

            int use1000 = Math.Min(money / 1000, b1000);
            money -= use1000 * 1000;

            int use500 = Math.Min(money / 500, b500);
            money -= use500 * 500;

            int use100 = Math.Min(money / 100, b100);
            money -= use100 * 100;

            int use50 = Math.Min(money / 50, b50);
            money -= use50 * 50;

            int use10 = Math.Min(money / 10, c10);
            money -= use10 * 10;

            int use5 = Math.Min(money / 5, c5);
            money -= use5 * 5;

            int use1 = Math.Min(money / 1, c1);
            money -= use1 * 1;

            if (money > 0)
            {
                Console.WriteLine("ไม่สามารถทอนได้ เนื่องจากไม่มีเศษ");
                continue;
            }

            if (use1000 > 0)
            {
                b1000 -= use1000;
                Console.WriteLine($"ใช้แบงค์ 1000: {use1000} เหลือ {b1000}");
            }

            if (use500 > 0)
            {
                b500 -= use500;
                Console.WriteLine($"ใช้แบงค์ 500: {use500} เหลือ {b500}");
            }

            if (use100 > 0)
            {
                b100 -= use100;
                Console.WriteLine($"ใช้แบงค์ 100: {use100} เหลือ {b100}");
            }

            if (use50 > 0)
            {
                b50 -= use50;
                Console.WriteLine($"ใช้แบงค์ 50: {use50} เหลือ {b50}");
            }

            if (use10 > 0)
            {
                c10 -= use10;
                Console.WriteLine($"ใช้เหรียญ 10: {use10} เหลือ {c10}");
            }

            if (use5 > 0)
            {
                c5 -= use5;
                Console.WriteLine($"ใช้เหรียญ 5: {use5} เหลือ {c5}");
            }

            if (use1 > 0)
            {
                c1 -= use1;
                Console.WriteLine($"ใช้เหรียญ 1: {use1} เหลือ {c1}");
            }
        }
    }
}