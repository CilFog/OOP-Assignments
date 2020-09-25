# Notes for lecture 1

## Basic assignments

1. **Typer. Find, og forklar, fejlene i nedenstående: (du kan evt. få VS til at fortælle dig hvad fejlen er!). Det er vigtigt du forstår hvorfor nedenstående giver fejl.**
    1. **char a = "a";** <br>
        "a" means you are asigning a char as a string. Instead it should look like
        ```csharp
        char a = 'a';
        ```
    2. **bool b = 0;** <br>
        A bool must be assigned true or false
        ```csharp
        bool b = false;
        ```
    3. **int c = 8.0;** <br>
        The int is assigned a double
        ```csharp
        int c = 8.0;
        ```
    4. **decimal d = 6.7;** <br>
        A decimal must be assigned with d after
        ```csharp
        decimal d = 6.7d;
        ```
    5. **string e = "Har du set "Holger"?";** <br>
        To assign a string with a string inside, you must use other quote signs
        ```csharp
        string e = "Har du set `Holger`?"
        ```
<br>

2. **Skriv to metoder. En der konverterer fra radian til grader, og en, der konverterer den anden vej. Vi vælger her, at output fra disse metoder altid ligger imellem 0 og 359.99+ grader og mellem 0 and 2 × π radian. Vi observerer nemlig, at på en cirkel, er 2 π radian er det samme som 0, og 360 grader er det samme som 0 grader.**
    1. **radians = degrees * (pi/180)**
        ```csharp
        static double ConvertRadiansToDegrees(double radians)
        {
            if (radians < 2 && radians > 0)
            {
                return radians * (180 / Math.PI);
            }

            else if (radians == 2)
            {
                return 0;
            }
            else if (radians == 0)
            {
                return 360;
            }
            else return 0;
        }
        ```
    2. **degrees = radians * (180/pi)**
        ```csharp
        static double ConvertDegreesToRadians(double degrees)
        {
            if (degrees == 0)
            {
                degrees = 360;
            }
            return degrees * (Math.PI / 180);
        }
        ```
<br>

3. **Skriv en metode, der tager et heltal som argument, og printer følgende: (her kaldtmed 5)** 
    <br>
    \* <br>
    *\* <br>
    *\*\* <br>
    *\*\*\* <br>
    *\*\*\*\* <br> 

    ```csharp
    static string[] IndentAsterixOnEachLine(int amountOfAsterix)
    {
        char asterixSign = '*';

        string[] array = new string[amountOfAsterix];
        
        for(int asterix = 1; asterix <= amountOfAsterix; asterix++)
        {
            array[asterix - 1] = new String(asterixSign, asterix); 
        }

        return array;
    }
    ```
<br>

4. **Lav metoden der skriver det ud i omvendt rækkefølge, f.eks. fra 5 og ned til 1 stjerne.**

    ```csharp
    static string[] UnindentAsterixOnEachLine(int amountOfAsterix)
    {
        char asterixSign = '*';

        string[] array = new string[amountOfAsterix];

        for (int asterix = 1; asterix <= amountOfAsterix; asterix++)
        {
            array[asterix - 1] = new String(asterixSign, (8 - asterix));
        }

        return array;
    }
    ``` 
<br>

5. **Math er en klasse, der indeholder en masse metoder og konstanter til matematiske beregninger. Det er en speciel klasse, der ikke skal instantieres, lidt ligesom System.Console, som indeholder metoder til at styre terminalen. Her under ser du én måde at lave strenge om til tal:** <br>
    ```csharp
    string input = Console.ReadLine();
    int tal = int.Parse(input);
    ```

    1. **Spørg brugeren om et tal, og beregn, via. en af System.Math’s metoder, kvadratroden af dette tal (hint: sqrt)**
        ```csharp
        static int GetUsersInputNumber()
        {
            int number = int.Parse(Console.ReadLine());

            return number;
        }
        ```
    2. **Prøv at skrive noget andet end et tal, når programmet forventer et tal i. Dette er C#s fejlmekanisme, det dækkes senere i kurset.**
        Return fail, as it cannot be converted to int
<br>

6. **Skriv et program der gør følgende:**
    1. **Spørger om antallet af medlemmer i din gruppe.**
        ```csharp
        static int GetUsersGroupmembers()
        {
            Console.WriteLine("Enter how many groupmembers do you have:");

            int amountOfGroupmembers = int.Parse(Console.ReadLine());

            return amountOfGroupmembers;
        }
        ```
        <br>
    2. **Beder om navn på hvert medlem af din gruppe. Efter hvert navn, trykkes enter.**
        ```csharp
        static string[] GetGroupmemberNames(int AmountOfGroupmembers)
        {
            string[] groupmembers = new string[AmountOfGroupmembers];

            int groupmemberName = 0;

            Console.WriteLine("Enter your groupmembers names");

            while (groupmemberName < AmountOfGroupmembers)
            {
                groupmembers[groupmemberName] = Console.ReadLine();

                groupmemberName++;

            }

            return groupmembers;
        }
        ```
        <br>
    3. **Når alle medlemmers navne er blevet indtastet, skal alle navnene skrives ud til skærmen.**
        ```csharp
        static void PrintGroupmemberNames(string[] groupmembers)
        {
            Console.WriteLine("This is your members");
            foreach(string member in groupmembers)
            {
                Console.WriteLine(member);
            }
        }
        ```
        <br>
    4. **Lav nu samme program, bare uden punkt-a, indtastningen af antal medlemmer. Når der ikke er flere gruppemedlemmer, trykkes der bare enter.**
        ```csharp
        static string[] EnterGroupmemberNames()
        {
            Console.WriteLine("Enter the names of your groupmembers");

            string names = Console.ReadLine();

            string[] groupmembers = names.Split(' ');

            return groupmembers;

        }
        ```
        <br>

7. **Lav et array der indeholder 7 lottotal. Skriv disse ud til skærmen.**
    ```csharp
    static int MakeRandomLottoNumbers()
    {
        Random rnd = new Random();
        return rnd.Next(1, 100);
    }

    static int[] LottoCard()
    {
        int lottoNumbers = 7;
        int[] lottoCard = new int[lottoNumbers];

        for (int lottoNumber = 0; lottoNumber < lottoNumbers; lottoNumber++)
        {
            lottoCard[lottoNumber] = MakeRandomLottoNumbers();
        }

        return lottoCard;  
    }
    ```
<br>

## Class assignements

1. **Herunder har jeg skrevet en simpel klasse Person**
    ```csharp
    class Person
    {
        string Fornavn;
        string Efternavn;
        int Alder;
    }
    ```
    <br>

    1. **Omskriv de to private instansvariable til offentlige properties med validering. Find selv på valideringskriterie.**
        ```csharp
        public class Person 
        {
            public int Age;

            public static int UpdateId = 0;
            
            public string Firstname
            {
                get => _Firstname;
                set => _Firstname = value ?? throw new ArgumentNullException("Person cannot be null");
            
            }
        }
        ```
    <br>

    2. **Tilføj to properties, Far og Mor på denne klasse. Hvilken type vælger du til Far og Mor? – tænk på, din mor og din far har samme egenskaber som dig, og har også forældre. Tilføj validering til disse properties.**
        ```csharp
        public Person PersonsMother
        {
            get => _PersonsMother;
            set => _PersonsMother = value ?? throw new ArgumentNullException("Mother cannot be null");
        }

        public Person PersonFather
        {
            get => _PersonsFather;
            set => _PersonsFather = value ?? throw new ArgumentNullException("Father cannot be null");
        }

        private Person _PersonsFather;
        private Person _PersonsMother;
        ```
        <br>

    3. **I din Main, lav en person, med dit navn, dine forældre, og deres forældre.**
        ```csharp
        static void Main(string[] args)
        {
                Person morfar = new Person("Jørgen", "Fog", 87);
                Person mormor = new Person("Mette", "Fog", 85);

                Person bedstefar = new Person("Sjos", "Andersen", 90);
                Person farmor = new Person("Carla", "Andersen", 80);

                Person far = new Person("Otto", "Andersen", 66, bedstefar, farmor);
                Person mor = new Person("Lisbet", "Fog", 59, morfar, mormor);

                Person person = new Person("Cecilie", "Fog", 21, far, mor);
        }
        ```
        <br>

    4. **Lav en ny klasse PersonPrinter og tilføj en metode til at printe en person. F.eks. ”fornavn efternavn, alder”**
        ```csharp
        public class PersonPrinter
        {
            public string PrintInformation(Person person)
            {
                return $"Firstname: {person.Firstname}, Lastname: {person.Lastname}, Age: {person.Age}";
            }
        }
        ```
        <br>
        
    5. **Tilføj en metode, der printer alle navnene i stamtræet ud. (hint: speciel situation når vi ikke har angivet forældre (null))**
        ```csharp
        public void PrintFamilyTree(Person person)
        {
            if(person == null)
            {
                return; 
            }

            Console.WriteLine(PrintInformation(person));
            PrintFamilyTree(person.PersonFather);
            PrintFamilyTree(person.PersonsMother);

        }
        ```
<br>

2. **Tilføj en ekstra constructor til klassen Person fra opgave 1, så man kan vælge at angive forældre når man konstruerer en instans af Person.**
    ```csharp
    public Person(string firstname, string lastname, int age, Person personFather, Person personsMother)
    {
        Firstname = firstname;
        Lastname = lastname;
        Age = age;
        PersonFather = personFather;
        PersonsMother = personsMother;
    }

    public Person(string firstname, string lastname, int age)
    {
        Firstname = firstname;
        Lastname = lastname;
        Age = age;
    }
    ```
<br>

3. **Tilføj en offentlig property PersonID til klassen Person fra opgave 1. PersonID er et ID der unikt identificerer personer. Brug din viden omkring statiske medlemmer til at implementere PersonID for Person-klassen, så alle instanser af Person har et unikt ID.**

    ```diff
    public class Person
    {
        public Person(string firstname, string lastname, int age, Person personFather, Person personsMother)
        {
            Firstname = firstname;
            Lastname = lastname;
            Age = age;
            PersonFather = personFather;
            PersonsMother = personsMother;
    +       Id = UpdateId;
    +       UpdateId++;
        }
        
        public Person(string firstname, string lastname, int age)
        {
            Firstname = firstname;
            Lastname = lastname;
            Age = age;
    +       Id = UpdateId;
    +       UpdateId++;
        }

    +   public int Id { get; set; }
    +   public static int UpdateId = 0;
    }
    ```
<br>

4. **Lav et program der, for et bibliotek (folder/mappe) på din computer (f.eks. c:\\)**
    I've made a class valled DirectoryPrinter
    1. **Udskriver alle filers navne og deres størrelser**
        ```csharp
        public static void PrintFilesInDirectory(DirectoryInfo source)
        {
            foreach (FileInfo file in source.GetFiles()) 
            {
                Console.WriteLine($"File: {file.Name}");
                Console.WriteLine($"Size: {file.Length} bytes");
            }
        }
        ```
        <br>
        
    2. **b. Udskriver navnene på alle mapper og antal filer og mapper, de indeholder**
        ```csharp
        public static void PrintDirectoryInDirectories(DirectoryInfo source)
        {
            foreach (DirectoryInfo directory in source.GetDirectories())
            {
                Console.WriteLine($"Subdirectory: {directory.Name}");
                Console.WriteLine($"Number of files: {directory.GetFileSystemInfos().Length}");
            }
        }
        ```
<br>

5. **I C# sammenligner vi værdier med ==. For de simple typer sammenligner vi værdier:** <br>
    1 == 1 giver true <br>
    1 == 2 giver false <br>
    rue == true giver true <br>
    true == false giver false <br>
    **Skriv en klasse til dette formål**

    I've made the class CompareRefenreceType for this task
    ```csharp
        public static class ReferenceCompariter
        {
            public static bool CompareReferencetype(Person a, Person b)
            {
                if(a == b)
                {
                    return true;
                }

                return false;
            }
        }
    ```
<br>

6. **Definer en vektortype, om det er 2D eller 3D, er op til dig.**
    1. **Implementér metoder for addition og subtraktion**
        ```csharp
        public class _dVector
        {
            public _dVector(double x, double y)
            {
                this.x = x;
                this.y = y;
            }

            public double[] Add(double[] b)
            {
                double[] a = new double[] { x, y };


                if (a.Length != b.Length)
                {
                    throw new ArgumentException("Both vectors must be of same dimention");
                }

                for (int element = 0; element < a.Length; element++)
                {
                    a[element] += b[element];
                }

                return a;
            }

            public double[] Substract(double[] b)
            {
                double[] a = new double[] { x, y };

                if (a.Length != b.Length)
                {
                    throw new ArgumentException("Both vectors must be of same dimention");
                }

                for (int element = 0; element < a.Length; element++)
                {
                    a[element] -= b[element];
                }

                return a;
            }
        }
        ```
    <br>

    2. **Implementér skalering og evt. andre som f.eks. krydsprodukt**
        ```csharp
        public double[] Multiplication(double scalar)
        {
            double[] a = new double[] { x, y };

            for (int element = 0; element < a.Length; element++)
            {
                a[element] *= scalar;
            }

            return a;
        }

        public double CrossProduct(double[] b)
        {
            double[] a = new double[] { x, y };

            if (a.Length != b.Length)
            {
                throw new ArgumentException("Both vectors must be of same dimention");
            }

            double sum = 0.0;

            for (int element = 0; element < a.Length; element++)
            {
                sum += (a[element] * b[element]);
            }

            return sum;
        }
        ```


