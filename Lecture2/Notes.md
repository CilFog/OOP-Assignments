# Opgaver for lektion 2 

1. **Explain, in your own words, the access modifiers: private, protected, and public. When would you use each? Which would you use by default?**

    * private should be used to hide all information you don't wish a user has access to. The same goes for derived classes.
    * protected makes it possible for derived classes to access otherwise private fields
    * public makes all changes to fields available in the whole program

<br>

2. **Write a class to represent an employee. An employee has a name, job title and a salary. Write a subclass to represent a manager. A manager has a yearly bonus bonus.**

    1. **Add appropriate constructors for the classes. Discuss in the group what appropriate means**

        * First I created the class
            
            ```csharp
            public class Employee
            {
                public Employee(string name, string jobTitle, double salary)
                {
                    Name = name;
                    JobTitle = jobTitle;
                    Salary = salary;
                }

                public string Name { get; set; }
                public string JobTitle { get; set; }
                public double Salary { get; set; }
            }
            ```
            <br>

        * I afterwards made the derived class manager
            ```csharp
            public class Manager : Employee
            {
                public Manager(string name, string jobTitle, double salary, double bonus) : base(name, jobTitle, salary)
                {
                    Bonus = bonus;
                }

                public double Bonus { get; set; }
            }
            ```
            <br>

    2. **Employee has a method CalculateYearlySalary; implement this**

        * Done. I've used virtual to make sure that the derived classes can change their salary
            ```csharp
            public virtual double CalculateYearlySalary()
            {
                return 12 * Salary;
            }
            ```
            <br>

    3. **For manager, CalculateYearlySalary includes bonus**
        * I use override to change the existing function, so that I'm able to add the bonus
            ```csharp
            public override double CalculateYearlySalary()
            {
                return 12 * Salary + 12 * Bonus;
            }
            ```
            <br>

    4. **Employe-and managers has seneniority levels 1-10, each level results in 10% extra salary. Level 3 is 30%, level 7 is 70% extra. Bonus is not affected by seniority levels**
        * I've added a field called Seneniority level to the Employee class, and updated both methods for both classes

            **Employee**
        
            ```diff
            public virtual double CalculateYearlySalary()
            {
                
            -   return 12 * Salary;
            +   return 12 * Salary + (12 * (Salary * SeneniorityLevel));
            }
            ```

            **Manager**
            ```diff
            public override double CalculateYearlySalary()
            {
            -    return 12 * Salary + 12 * Bonus;
            +    return (12 * Salary) + (12 * Bonus) + (12 * Salary * SeneniorityLevel);
            }
            ```
        <br>


3. **Write a class to represent a parking meter. The parking meter should have a method to insert coins and pay for x minutes. The parking rate depends on whether it is weekday or weekend. Write an abstract class to capture the computation of the parking rate. Use the abstract class in the parking meter to calculate rate. Write two classes, which extend the abstract class, one for the rate in weekdays and one for the rate in weekends**

    1. First I've written my abstract class, ParkingRate
        ```csharp
        public abstract class ParkingRate
        {
            public abstract double getRate(double rate);
        }
        ```
        <br>

    2. I afterwards wrote to classes, Weekday and Weekend
        ```csharp
        public static  class Weekend 
        {
            public static double Rate = 0.2;
        }
        ```
        <br>

    3.  I then wrote my class for the Parkingmeter
        ```csharp
        public class ParkingMeter : ParkingRate
        {
            public ParkingMeter(double coins, double rate) 
            {
                MinutesToPark = InsertCoinsForParking(coins, rate);
            }
            public double InsertCoinsForParking(double coins, double rate)
            {
                return coins * getRate(rate);
            }


            public double MinutesToPark { get; }

            public override double getRate(double rate)
            {
                return rate;
            }
        }
        ```
        <br>


4. **Write a class to represent a bank account.**
    ```csharp
    
    public class BankAccount
    {
        private BankAccount(double balance) {}
    }

    ```
    <br>

    1. **A bank account has a balance, a borrowing rate, and a savings rate. The borrowing rate might be 10% but the savings rate might be only 1%.**
        ```csharp
        public class BankAccount
        {
            private BankAccount(double balance)
            {
                if(balance < 0)
                {
                    throw new ArgumentException("Balance must be greater than 0");
                }
                Balance = balance;
            }

            public double Balance { get; private set; }
            private double BorrowingRate = 0.1;
            private double SavingsRate = 0.01;
        }
        ```

    2. **Add methods to deposit and withdraw money.**
        ```csharp
        public bool DepositMoney(double depositMoney)
        {
            if (depositMoney <= 0)
            {
                throw new ArgumentException("You must deposit somthing greather than 0");
            }
            if ((depositMoney + Balance) > 250000)
            {
                throw new ArgumentException($"Your deposit is too great. Your current balance is {Balance} and will exceed 250.000, if you deposit {depositMoney}.");
            }

            Balance += depositMoney;

            return true;
        }

        public bool WithdrawMoney(double WithdrawelMoney)
        {
            if (WithdrawelMoney >= Balance)
            {
                throw new ArgumentException("You can't withdraw something you don't have");
            }

            if ((Balance - WithdrawelMoney) < (-100000))
            {
                throw new ArgumentException($"Your withdrawel is too great. Your current balance is {Balance} and will go below 100000, if you withdraw {WithdrawelMoney}");
            }
            Balance -= WithdrawelMoney;

            return true;
        }
        ```
    <br>

    3. **Add a method to accrue or charge interest depending on the current balance.**
        ```csharp
        public bool ChangeBorrowingRate(double changeRateWith)
        {
            if(((BorrowingRate - changeRateWith) < 0.06))
            {
                throw new ArgumentException("Borrowingrate must not be lower than 6%");
            }
            BorrowingRate += changeRateWith;

            return true;
        }

        public bool ChangeSavingsRate(double changeRateWith)
        {
            if(((SavingsRate + changeRateWith) > 0.02))
            {
                throw new ArgumentException("Savingsrate must not be greater than 2%");
            }
            SavingsRate += changeRateWith;

            return true;
        }
        ```

    <br>

    4. **Ensure, via proper encapsulation, that the following invariants are true:**
        1. **the balance must never be less than −100, 000,**
            ```csharp
            if ((Balance - WithdrawelMoney) < (-100000))
            {
                throw new ArgumentException($"Your withdrawel is too great. Your current balance is {Balance} and will go below 100000, if you withdraw {WithdrawelMoney}");
            }
            ```
         <br>

        2. **the balance must never be more than 250,000,**
            ```csharp
            if ((depositMoney + Balance) > 250000)
            {
                throw new ArgumentException($"Your deposit is too great. Your current balance is {Balance} and will exceed 250.000, if you deposit {depositMoney}.");
            }
            ```
        <br>

        3. **you cannot deposit or withdraw a negative amount of money**
            ```csharp
            if (WithdrawelMoney <= 0)
            {
                throw new ArgumentException("You can't withdraw something you don't have");
            }
            
            if (depositMoney <= 0)
            {
                throw new ArgumentException("You must deposit somthing greather than 0");
            }
            ```
         <br>

        4. **the borrowing rate must be at least 6%. The savings rate must be at most 2%**
            ```csharp
            if(((BorrowingRate - changeRateWith) < 0.06))
            {
                throw new ArgumentException("Borrowingrate must not be lower than 6%");
            }

            if(((SavingsRate + changeRateWith) > 0.02))
            {
                throw new ArgumentException("Savingsrate must not be greater than 2%");
            }
            ```
         <br>

5. **In this exercise we will design a list-filtering framework for filtering lists of person, List<Person>. The filtering is used like this:**
    1. **Create an abstract class PersonFilter, with an abstract method**
        ```csharp
        bool FilterPredicate(Person person)
        ```
        I firstly added the Person class from last lecture to my Lecture2 file. The class contains the following
        ```csharp
        public class Person{
            public Person(string firstname, string lastname, int age)
            {
                Firstname = firstname;
                Lastname = lastname;
                Age = age;

            }
        }
        ```
        
        I afterwards made the PersonFilter class
        ```csharp
        public abstract class PersonFilter
        {
            public PersonFilter()
            {
            }

            public abstract bool FilterPredicate(Person person);
        }
        ```
}

