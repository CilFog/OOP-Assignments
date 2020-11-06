# Notes for Assignment 5

1. **Create a method, ReadInteger which reads a line from the command line and returns the input parsed as integer. Use the static method int.Parse. Your ReadInteger metod will only return on a successful parse. If the input is not an integer, an appropriate error message will written in the terminal, and the method will read another line. You need to use try/catch** 

    1. **Call your newly created method**

    ```csharp
        static void Main(string[] args)
        {
            while (true)
            {
                ReadInt();
            }
        }

        static void ReadInt()
        { 
            int integer;

            Console.WriteLine("Write an integer");
            string input = Console.ReadLine();

            try
            {
                integer = int.Parse(input);
            }
            catch
            {
                Console.WriteLine("Wrong type of input");
            }
        }
    ```

    1. **type in “foo” – confirm the error message**
        ```console
        Write an integer
        foo
        Wrong type of input
        Write an integer
        3
        Write an integer
        ```
    1. **type in “10000000000000000” – confirm**
        I changed int to long instead, and thus is worked again.

1. **Write a class to represent a bank account. An account has a balance. Add deposit and withdrawal methods. The balance of the account must always be non-negative. Write a class InsufficientFundsException, which extends Exception, and throw this exception (a) in the constructor if th**   

    1. **Write the bankaccount class**
    ```csharp
    public class BankAccount
    {
        public BankAccount(double balance)
        {
            if(balance < 0)
            {
                throw new InsufficientFundsException(balance);
            }
            Balance = balance;
        }

        private double Balance { get; set; }

        public void Withdraw(double amount)
        {
            if ((Balance - amount) < 0)
            {
                throw new InsufficientFundsException(Balance - amount);
            }
            else
            {
                Balance -= amount;
            }
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }
    }
    ```
    1. **Write the InsufficientFundsException**
        ```csharp
        public class InsufficientFundsException : Exception
        {
            public InsufficientFundsException(double balance)
            {
                if(balance < 0)
                {
                    Console.WriteLine("Cannot have a negative balance");
                }
            }
        }
        ```
1. **Write a class to represent a gearbox with five gears and a gear for reverse. Add a method changeGear(int gear) to change the current gear. The method must throw IllegalArgumentException if the gear is not one of -1, 1, 2, 3, 4, and 5. Here reverse is represented as -1. Write a class IllegalGearChangeException, which extends Exception, and throw this exception: (a) when switching from any gear other than the first gear into reverse and (b) when skipping one or more gears, e.g. it is illegal to switch directly from the first gear to the third gear**