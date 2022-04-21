namespace RecordNamespace
{
    // A record is just a read-only and thread-safe class-like datatype with many features built-in.
    class RecordExample
    {
        public static void Main()
        {
            RecordOne recordOne = new("Horatio", "Adeoye");
            RecordOne recordTwo = new("Harper", "Adeoye");
            RecordOne recordThree = new("Horatio", "Adeoye");
            RecordTwo recordFive = new("Micheal", "Adeoye");


            ClassOne classOne = new("Horatio", "Adeoye");
            ClassOne classTwo = new("Harper", "Adeoye");
            ClassOne classThree = new("Horatio", "Adeoye");

            // Unlike classes, records automatically overrides the ToString method to print the values inside the record..
            Console.WriteLine(recordOne);
            Console.WriteLine(classOne);
            Console.WriteLine(recordFive);

            // Unlike classes, records are equal if the values inside the record are the same.
            Console.WriteLine($"Are the two record objects equal: { Equals(recordOne, recordThree) }");
            Console.WriteLine($"Are the two record objects reference equal: { ReferenceEquals(recordOne, recordThree) }");
            Console.WriteLine($"Are the two record objects == equal: { recordOne == recordThree }");
            Console.WriteLine($"Are the two record objects != equal: { recordOne != recordTwo }");

            Console.WriteLine($"Are the two class objects equal: { Equals(classOne, classThree) }");
            Console.WriteLine($"Are the two class objects reference equal: { ReferenceEquals(classOne, classThree) }");
            Console.WriteLine($"Are the two class objects == equal: { classOne == classThree }");
            Console.WriteLine($"Are the two class objects != equal: { classOne != classTwo }");

            // Deconstruction of the record into it constituent properties.
            var (fn, ln) = recordOne;
            Console.WriteLine($"The value of fn is {fn} and the value of ln is {ln}");

            RecordOne recordFour = recordOne with { FirstName = "Saori" };
            Console.WriteLine(recordOne);
            Console.WriteLine(recordFour);
        }
    }

    public record RecordOne(string FirstName, string LastName);

    public record RecordTwo(string FirstName, string LastName)
    {
        public String FullName { get => $"{FirstName} {LastName}"; }
    }

    public class ClassOne
    {
        public string FirstName { get; init; } // the init method means it can only be set in the constructor.
        public string LastName { get; init; }

        // You can use ctor as a code snippet.
        public ClassOne(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
