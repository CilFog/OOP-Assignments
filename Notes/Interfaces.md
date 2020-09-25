# **Notes for lecture 3 about interfaces**

### Defining an interface
1. Interfaces are names in PascalCase, and always stars with an 'I', when naming
2. They are defined with the type "Interfaces"
3. Contains no implementation and no data
4. An interface is a simple template with undefined 
5. It's possible to inherits as many interfaces as possible
6. There doesn't need to be public and private in front of everything
    <br>

    ```csharp
    interface IFileCompression
    {
        void Compress(string targetFileNamvVve, string[] fileList);
        void Uncompress(
        string compressedFileName, string expandDirectoryName);
    }
    ```

<br>
<br>

## Polymorphism
1. Preparation for example. IListable shows the members that a class needs to support the class ConsonleListControle.

    ```csharp
    class ConsoleListControl
    {
        public static void List(string[] headers, IListable[] items)
        {
            int[] columnWidths = DisplayHeaders(headers);

            for (int count = 0; count < items.Length; count++)
            {
                string[] values = items[count].ColumnValues;
                DisplayItemRow(columnWidths, values);
            }
        }   
        /// <summary>Displays the column headers</summary>
        /// <returns>Returns an array of column widths</returns>

        private static int[] DisplayHeaders(string[] headers)
        {
             // ...
        }

        private static void DisplayItemRow(int[] columnWidths, string[] values)
        {
            // ...
        }
    }
    ```

    ```csharp
    interface IListable
    {
        string ColumnValues[]
        {
            get;
        }
    }

    ```
    <br>

    ```csharp
    public abstract class PdaItem 
    {
        public PdaItem(string name) 
        {
            Name = name;
        }

        public virtual string Name { get; set; }
    }
    ```

2. Both the interface and the abstract class can be inherited by the class at the same time, but the base class MUST be declared first

    ```csharp
    public class Contact : PdaItem, IListable
    {
        public Contact(string firstName, string lastName) : base(null)
        {
            FirstName = firstName;
            LastName = lastName
        } 

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string ColumnValues[]
        {
            get
            {
                return FirstName, LastName;
            }
        }

        public string Headers [] {
            get 
            {
                return new string[]{
                    "First Name", "Last Name     "}
            }
        }
    }
    ```

3. Classes are implicitly convertable to their inherited interfaces
    ```csharp
    public static void Main()
    {
        Contact[] contacts = new Contact[]
        {
            new Contact(
                "Dick", "Traci",
            new Contact(
                "Andrew", "Littman",
            new Contact(
                "Mary", "Hartfelt",
        };

    //Showing 3)
    ConsolListControl.List(Contact.Headers, contact);
    ```

4. Shows the following output
    ```code
    First Name    Last Name 
    Dick          Traci 
    Andrew        Littman 
    ```



5. Can be used on other examples as well
    ```csharp
    class Publication : IListable
    {
        public Publication(string title, string author, int year)
        {
            Title = title;
            Author = author;
            Year = year;
        }

        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }

        public string[] ColumnValues
        {
            get
            {
                return new string[]
                {
                    Title,
                    Author,
                    Year.ToString()
                };
            }
        }

        public static string[] Headers
        {
            get
            {
                return new string[] {
                "Title ",
                "Author ",
                "Year" };
            }
        }
    }
    ```

6. Classes are implicitly convertable to their inherited interfaces
    ```csharp
    public static void Main()
    {
        Publication[] publications = new Publication[3] {
            new Publication(
                "The End of Poverty: Economic Possibilities for Our Time",
                "Jeffrey Sachs", 2006),
            new Publication("Orthodoxy",
                "G.K. Chesterton", 1908),
            new Publication(
                "The Hitchhiker's Guide to the Galaxy",
                "Douglas Adams", 1979)
        };
        
        ConsoleListControl.List(Publication.Headers, publications);
    }
    ```

7. Shows the following output
    ```code
    Title                                   Author                                              Year
    The End of Poverty:                     Economic Possibilities for Our Time Jeffrey Sachs   2006
    Orthodoxy                               G.K. Chesterton                                     1908
    The Hitchhiker's Guide to the Galaxy    Douglas Adams                                       1979
    ````

8. Interfaces do not have contructors, they can not be initiated and are only implented through classes that inherit them
    * They do not contain static members
    * They don't have finalizers
    * If a class implements an interface, all members of the interface must be implemented as well
        * An abstract class may implement an abstract member
        * A normal class may throw a NotImplementedException Type
    * There are two ways to implemeneting an interface member in a type. **Explicitly** or **implicitly**


### Explcit Member implementation

1. Explicitly implemented methods are available only by calling them through the interface itself
2. Interface members should no be declared with public or virtual, as this is misleading
    ```csharp
    string[] values;
    Contact contact1, contact2;

    // ...

    // ERROR: Unable to call ColumnValues() directly
    // on a contact
    // values = contact1.ColumnValues;

    // First cast to IListable
    values = ((IListable)contact2).ColumnValues;
    // ...
    ```

    or altrenatively
    ```csharp
    public class Contact : PdaItem, IListable, IComparable
    {
        // ...
        public int CompareTo(object obj)
        {
            // ...
        }

        #region IListable Members
        string[] IListable.ColumnValues
        {
            get
            {
                return new string[]
                {
                    FirstName,
                    LastName,
                    Phone,
                    Address
                };
            }
        }
        #endregion
    ```
    <br>

### Implicit Member implementation
1. Implicit member implementation does not require cast, because the member is not hidden from direct invocation
    1. Notice from the example above, how we didn't need to add **IComparable.CompareTo**
        ```csharp
        result = contact1.CompareTo(contact2);
        ```
    2. Does not require the word override
    3. It's only required for the member to be public
    4. Virtual can be used, if overriding is desired
    <br>


### Explicit versus Implicit Interface Implementation

1. With implicit member implementation, you're able to acces the method through an instance of the type, insted of through the interface
2. Explicit is used to seperate mechanism concerns from model concerns
3. How to choose which to use
    * Is a member a core part of the class functionality?
        *Does it make sense for the class to be able to access this feature?
    * Is the interface member name appropriate as a class member?
        *Consider using explicit, if the name of the interface can cause confusion as for what it does in the class
    * Does a class member with the same signature already exist?
        *With explicit, it's possible to add a member with the same name, as a already existing type
    * Use your intuition
    *AVOID implementing interfacec members esplicitly without a good reason, however, if you're unsure, favor explicit implementation
    <br>
    <br>

## Converting between the Implementing Class and It's Interface

### Interface inheritance

1. Interface can inherit from eachother, but they don't need to implement eachothers functions
    ```csharp
    interface IReadableSettingProvider
    {
        string GetSetting(string name, string defaultValue)
    }
    ```
    ```csharp
    
    interface ISettingProvider : IReadableSettingProvider
    {
        void SetSetting(string name, string value);
    }
    ```
    ```csharp
    class FileSettingProvider : ISettingsProvider
    {
        #region ISettingProvider Members
        public void SetSetting(string name, string value)
        {
            //...
        }
        #endregion

        #region IReadableSettingsProvider Members
        public string GetSetting(string name, string defaultValue)
        {
            //..    
        }
    }
    ```

2. Despite ISetting having inherited IReadableSettingsProvider, if it was made explicitly, it would not be able to call the GetSetting with ISettingProvider.GetSetting();
    ```csharp
    // ERROR: GetSetting() not available on ISettingsProvider
    string ISettingsProvider.GetSetting(string name, string defaultValue)
    {
        // ...
    }
    ```

3. It's possible for a class to inherit multiple interfaces
    ```csharp
    class FileSettingProvider : ISettingsProvider, IReadableSettingsProvider
    {
        #region ISettingProvider Members
        public void SetSetting(string name, string value)
        {
            //...
        }
        #endregion

        #region IReadableSettingsProvider Members
        public string GetSetting(string name, string defaultValue)
        {
            //..    
        }
    }
    ```
<br>
<br>

## Multiple Interface Inheritance
1. Interfaces can also inherit from multiple interfaces
    1. It's unusable for a interface to have no members, but if both interfaces har predominant, this could be a reasonable choice
        ```csharp
        interface IReadableSettingsProvider
        {
            string GetSetting(string name, string defaultValue);
        }
        interface IWriteableSettingsProvider
        {
            void SetSetting(string name, string value);
        }
        interface ISettingsProvider : IReadableSettingsProvider, IWriteableSettingsProvider
        {

        }
        ```

        2. The difference between the code above and ealier shown examples are, at not the class will only have to inherit from one interface

<br>
<br>

## Extension Methods on Interface

1. Works with interfaces in addtion to classes
    See example on page 371

<br>
<br>

## Implementing Multiple Intertance via Interfaces
1. The lack of multiplicity with classes, an interface is a wonderful workaroung

    ```csharp
    interface IPerson
    {
        string FirstName { get; set; }
        string LastName { get; set; }
    }
    ```

    ```csharp
    public class Person : IPerson
    {
        // ...
    }
    ```
    
    ```csharp
    public class PdaItem
    {
        // ...
    }
    ```

    ```csharp
    public class Contact : PdaItem, IPerson
    {
        private Person Person
        {
            get { return _Person; }
            set { _Person = value; }
        }

        private Person _Person;
        
        public string FirstName
        {
            get { return _Person.FirstName; }
            set { _Person.FirstName = value; }
        }

        public string LastName
        {
            get { return _Person.LastName; }
            set { _Person.LastName = value; }
        }
        // ...
    }
    ```

<br>
<br>

## Versioning
1. Do not change interfaces that has already been shipped, as this will break the code
2. Create instead a new interface that inherits from the existing interface (Otherwise classes that already implement the interface, will stop compiling)

<br>
<br>


## Interfaces compared to classes
1. Interfaces can never be instatiated, unlike classes
    * Interfaces are only available through reference
2. It's not possible to use the 'new' word with interfaces
    * Interfaces can therefore not contain any constructors or finalizers
3. Static members are not allowed in interfaces
4. Interfaces are a lot like abstract classes
    * You should favor classes over interfaces
    * Consider defining an interface, if you need to support itøs functionality on types that already inherit from some other type
5. See page 376 for a more throughly answers and examples
