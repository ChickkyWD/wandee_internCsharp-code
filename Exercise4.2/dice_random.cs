using System;
class dice
{
    private Random rand = new Random();
    public int Throw()
    {
        return rand.Next(1, 7);
    }
}
class Program
{
    public static void Main()
    {
        int mark = 0, i = 1;
        dice dic1 = new dice();

        while (mark != 1)
        {
            mark = dic1.Throw();
            Console.WriteLine(" {0} Mark of Dice : {1} ", i, mark);
            System.Threading.Thread.Sleep(10);
            i = i + 1;
        }
        Console.WriteLine("Throw of dice = 1 is : " + (i - 1) + " time \n");

        int d1 = 0, d2 = 0;
        int count = 1;

        dice dice1 = new dice();
        dice dice2 = new dice();

        while (!(d1 == 1 && d2 == 1))
        {
            d1 = dice1.Throw();
            d2 = dice2.Throw();

            Console.WriteLine(" {0} Dice1 : {1} , Dice2 : {2} \n", count, d1, d2);
            System.Threading.Thread.Sleep(10);
            count = count + 1;
        }

        Console.WriteLine("Snake Eyes (1,1) occur in : " + (count - 1) + " times");
        Console.ReadLine();
    }
}