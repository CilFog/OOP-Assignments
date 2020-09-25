# Lecture 3

## Assigntment 1 - IComparer and IComparable for Car
```csharp
class Car
{
    public string Make { get; set; }
    public string Model { get; set; }
    public double Price { get; set; }
}
```

Consider the code below:
```csharp
List<Car> cars = new List<Car>()
{
    new Car(){Make="Skoda", Model = "Fabia", Price = 50000},
    new Car(){Make="Skoda", Model = "Octavia", Price = 60000}
    ... and many more ...
};
```

**Do the following**
1. **Implement the IComparable interface on Car, to sort the list of cars by Price**
    ```csharp
    public class Car : IComparable
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }

        public int CompareTo(object obj)
        {
            return Price.CompareTo(((Car)obj).Price);
        }
    }
    ```

    I've also made the following class
    ```csharp
    public class CompareCarByPrice : IComparer<Car>
    {

        int IComparer<Car>.Compare(Car x, Car y)
        {
            return x.Price.CompareTo(y.Price);
        }
    }
    ```

    I'm then able to sort it by doing the following
    ```csharp
    List<double> sortedByPrice = new List<double>();

    List<Car> cars = new List<Car>()
    {
        new Car() { Make = "Skoda", Model = "Fabia", Price = 50000 },
        new Car() { Make = "Skoda", Model = "Octavia", Price = 50000 },
        new Car() { Make = "Renault", Model = "Clio", Price = 20000 }
    };

    cars.Sort(new CompareCarByPrice());

    foreach(Car car in cars)
    {
        Console.WriteLine(car.Price);
    }
    ```
    Which gives me the following output
    ```code
    50000
    50000
    20000
    ```
    <br>

2. **Implement the interface IComparer<Car> to sort cars by Make, then by Model and lastly by Price**
    I've made a new class for sorting all three fields
    ```csharp
    public class SortCar : IComparer<Car>
    {
        int IComparer<Car>.Compare(Car x, Car y)
        {
            int result = x.Make.CompareTo(y.Make);

            if (result == 0)
            {
                result = x.Model.CompareTo(y.Model);
            }

            if (result == 0)
            {
                result = x.Price.CompareTo(y.Price);
            }

            return result;
        }
    }
    ```

    I then called is as:
    ```csharp
    cars.Sort(new SortCar());

    foreach(Car car in cars)
    {
        Console.WriteLine($"Make: {car.Make}, Model: {car.Model}, Price: {car.Price}");
    }
    ```
    Where I got the following output
    ```code
    Make: Renault, Model: Clio, Price: 20000
    Make: Skoda, Model: Fabia, Price: 50000
    Make: Skoda, Model: Octavia, Price: 50000
    ```
<br>

3. **Implement the interface IComparer<Car> to sort cars by Model, and then by Price in reverse order.**
    I made a new class called SortCarByModelAndPriceInReverse

    ```csharp
    public class SortCarByModelAndPriceInReverse : IComparer<Car>
    {
        int IComparer<Car>.Compare(Car x, Car y)
        {
            int result = -(x.Model.CompareTo(y.Model));

            if(result == 0)
            {
                result = -(x.Price.CompareTo(y.Price));
            }

            return result;
        }
    }
    ```
    I called the function same way as before, and got the following output (And YES I tested it, so no worries ma friends)
    ```code
    Make: Skoda, Model: Octavia, Price: 50000
    Make: Skoda, Model: Clio, Price: 50000
    Make: Renault, Model: Clio, Price: 20000
    ```
<br>

## Assignment 2 - The interface ITaxable
For the purpose of this exercise, you are given a couple of very simple classes called Bus and House. Class Bus specializes the class Vehicle. Class House specializes the class FixedProperty.
```csharp
public class Vehicle
{
    protected int registrationNumber;
    protected double maxVelocity;
    protected decimal value;

    public Vehicle(int registrationNumber, double maxVelocity,
                    decimal value)
    {
        this.registrationNumber = registrationNumber;
        this.maxVelocity = maxVelocity;
        this.value = value;
    }

    public int RegistrationNumber
    {
        get
        {
            return registrationNumber;
        }
    }
}
```

```csharp
public class Bus : Vehicle
{
    protected int numberOfSeats;

    public Bus(int numberOfSeats, int regNumber, decimal value) : base(regNumber, 80, value)
    {
        this.numberOfSeats = numberOfSeats;
    }

    public int NumberOfSeats
    {
        get
        {
            return numberOfSeats;
        }
    }
}
```
```csharp
public class FixedProperty
{

    protected string location;
    protected bool inCity;
    protected decimal estimatedValue;

    public FixedProperty(string location, bool inCity, decimal value)
    {
        this.location = location;
        this.inCity = inCity;
        this.estimatedValue = value;
    }

    public FixedProperty(string location) : this(location, true, 1000000)
    {
    }

    public string Location
    {
        get
        {
            return location;
        }
    }
}
```
```csharp
public class House : FixedProperty
{
    protected double area;

    public House(string location, bool inCity, double area,
                    decimal value) :
        base(location, inCity, value)
    {
        this.area = area;
    }

    public double Area
    {
        get
        {
            return area;
        }
    }
}
```
<br>

1. **Program an interface ITaxable with a parameterless operation TaxValue. The operation should return a decimal number.**
    ```csharp
    public interface ITaxable
    {
        decimal TaxValue();
    }
    ```
<br>

2. **Program variations of class House and class Bus, which implement the interface ITaxable. Feel free to invent the concrete taxation of houses and busses. Notice that both class House and Bus have a superclass, namely FixedProperty and Vehicle, respectively. Therefore, it is essential that taxation is introduced via an interface.**
```diff
+   public class House : FixedProperty, ITaxable
    {
        //Other code
+       public decimal TaxValue()
        {
+          return 2m;
        }
    }
```diff
+   public class Bus : Vehicle, ITaxable
    {
        //Other code
+       public decimal TaxValue()
        {
+           1m;
        }
    }
```
<br>

3. **Demonstrate that taxable house objects and taxable bus objects can be used together as objects of type ITaxable.**
    1. For the purpose of showing this, I've made a list in Main, that i'm able to push both instances of the class to, which I'm only able to do, because of ITaxable. I've added the missing constructor for both Bus and House

    ```csharp
    Bus bus1 = new Bus();
    Bus bus2 = new Bus();
    House house1 = new House();
    List<ITaxable> tax = new List<ITaxable>();
    
    tax.Add(bus1);
    tax.Add(bus2);
    tax.Add(house1);

    foreach(ITaxable taxes in tax)
    {
        Console.WriteLine(taxes.TaxValue());
    }
    ```

    