using System;

class Program
{
    static void Main()
    {
        int balance = 0;
        int choice;

        // First deposit (must be >= 100)
        while (balance < 100)
        {
            int firstDeposit;

            while (true)
            {
                Console.Write("Please deposit at least 100 Bath to proceed with other transactions: ");

                if (int.TryParse(Console.ReadLine(), out firstDeposit) && firstDeposit >= 0)
                {
                    break;
                }
                Console.WriteLine("Invalid input! Please enter a positive number.\n");
            }

            if (firstDeposit >= 100)
            {
                balance += firstDeposit;
                Console.WriteLine("Success! Account balance is : " + balance + " Bath\n");
            }
            else
            {
                Console.WriteLine("You must deposit at least 100 Bath\n");
            }
        }

        do
        {
            Console.WriteLine("Account \n========");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Check Balance");
            Console.WriteLine("4. Exit");
            Console.Write("Select Number : ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid menu selection.\n");
                continue;
            }

            switch (choice)
            {
                case 1: // Deposit
                    int deposit;
                    while (true)
                    {
                        Console.Write("Enter money to deposit : ");
                        if (int.TryParse(Console.ReadLine(), out deposit) && deposit > 0)
                        {
                            break;
                        }
                        Console.WriteLine("Invalid input! Please enter a number greater than 0");
                    }

                    balance += deposit;
                    Console.WriteLine("Success! Account balance is : " + balance + " Bath");
                    break;

                case 2: // Withdraw
                    int withdraw;
                    while (true)
                    {
                        Console.Write("Enter money to withdraw : ");
                        if (int.TryParse(Console.ReadLine(), out withdraw) && withdraw > 0)
                        {
                            break;
                        }
                        Console.WriteLine("Invalid input! Please enter a number greater than 0");
                    }

                    if (withdraw > balance)
                    {
                        Console.WriteLine("Can not withdraw because money is not enough");
                    }
                    else if (balance - withdraw < 100)
                    {
                        Console.WriteLine("Can not withdraw because balance must be at least 100 Bath");
                    }
                    else
                    {
                        balance -= withdraw;
                        Console.WriteLine("Success! Account balance is : " + balance + " Bath");
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