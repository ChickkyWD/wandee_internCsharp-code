using System;
class Program
{
    static void Main()
    {
        int balance = 100;
        int choice;

        do
        {
            Console.WriteLine("Account \n========");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Check Balance");
            Console.WriteLine("4. Exit");
            Console.Write("Select Number : ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: // Deposit
                    Console.Write("Enter money to deposit : ");
                    int deposit = int.Parse(Console.ReadLine());
                    balance += deposit;
                    Console.WriteLine("Success! Account balance is : " + balance + " Bath");
                    break;

                case 2: // Withdraw
                    Console.Write("Enter money to withdraw : ");
                    int withdraw = int.Parse(Console.ReadLine());

                    if (balance - withdraw >= 100)
                    {
                        balance -= withdraw;
                        Console.WriteLine("Success! Account balance is : " + balance + " Bath");
                    }
                    else
                    {
                        Console.WriteLine("Can not withdraw because money will less than 100 Bath");
                    }
                    break;

                case 3: // Check Balance
                    Console.WriteLine("Account balance is : " + balance + " Bath");
                    break;

                case 4:
                    Console.WriteLine("Exit the program.");
                    break;

                default:
                    Console.WriteLine("Invalid menu selection.");
                    break;
            }

            Console.WriteLine("Press any key...\n");
            Console.ReadKey();

        } while (choice != 4);
    }
}