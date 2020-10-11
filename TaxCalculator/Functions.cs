using System;
using TaxCalculator2;

namespace TaxCalculator
{

    interface IBirthDate
    {
        DateTime BirthDate { get; }
        int GetCount(bool valid);
    }

    interface INamable
    {
        string Name { get; }
    }

    class Person : IBirthDate, INamable
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public int GetCount(bool valid)
        {
            return 1;
        }
    }

    class Animal : IBirthDate
    {
        public string Type;
        public DateTime BirthDate { get; set; }
    }

    class Plant : IBirthDate
    {
        public string Origin;

        public DateTime BirthDate { get; set; }
    }

    class Functions
    {
        public static void Do()
        {

            var p1 = new Person() { Name = "Ahmed", BirthDate = new DateTime(1990,10,5) };
            var p2 = new Person() { Name = "Muhammad", BirthDate = new DateTime(1995, 1, 13)};
            var animal = new Animal {Type = "Cow", BirthDate = new DateTime(2015, 2,2) };
            var plant = new Plant { BirthDate = new DateTime(2019, 4, 4) };
            Console.WriteLine($"{p1.Name} {p1.GetAge()}");
            Console.WriteLine($"{p2.Name} {p2.GetAge()}");
            Console.WriteLine($"{animal.Type} {animal.GetAge()}");
            Console.WriteLine($"Plant: {plant.GetAge()}");
        }

    }
}
