using System;
using System.Collections.Generic;
using System.Linq;

class LINQ
{
    static void Main(string[] args)
    {
        // Example 1: Query even numbers from n1
        int[] n1 = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        var nQuery = from tmp in n1
                     where (tmp % 2 == 0)
                     select tmp;

        Console.WriteLine("Even numbers in n1:");
        foreach (var n in nQuery)
        {
            Console.Write(n + " ");
        }
        Console.WriteLine();

        // Example 2: Query numbers greater than 0 and less than 12 from n2
        int[] n2 = { 1, 3, -2, -4, -7, -3, -8, 12, 19, 6, 9, 10, 14 };
        var nQuery2 = from tmp in n2
                      where tmp > 0 && tmp < 12
                      select tmp;

        Console.WriteLine("Numbers greater than 0 and less than 12 in n2:");
        foreach (var n in nQuery2)
        {
            Console.Write(n + " ");
        }
        Console.WriteLine();

        // Example 3: Select animals with names longer than or equal to 5 characters
        List<string> animals = new List<string> { "Tan Dai", "bao", "phuc" };
        var selectedAnimals = animals.Where(s => s.Length >= 5).Select(x => x.ToUpper());

        Console.WriteLine("Selected animals:");
        foreach (var animal in selectedAnimals)
        {
            Console.WriteLine(animal);
        }

        // Example 4: Take top 5 largest numbers from the list
        List<int> numbers = new List<int> { 6, 0, 999, 11, 443, 6, 1, 24, 54 };
        var top5 = numbers.OrderByDescending(x => x).Take(5);

        Console.WriteLine("Top 5 largest numbers:");
        foreach (var number in top5)
        {
            Console.WriteLine(number);
        }

        // Example 5: Order pets by age
        Pet.OrderByEx1();

        // Example 6: Select pets starting with 'S'
        SelectManyEx3();
    }

    class Pet
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public static void OrderByEx1()
        {
            Pet[] pets = {
                new Pet { Name = "Barley", Age = 8 },
                new Pet { Name = "Boots", Age = 4 },
                new Pet { Name = "Whiskers", Age = 1 }
            };

            IEnumerable<Pet> query = pets.OrderBy(pet => pet.Age);

            Console.WriteLine("Pets ordered by age:");
            foreach (var pet in query)
            {
                Console.WriteLine($"{pet.Name}, Age: {pet.Age}");
            }
        }
    }

    class PetOwner
    {
        public string Name { get; set; }
        public List<string> Pets { get; set; }
    }

    public static void SelectManyEx3()
    {
        PetOwner[] petOwners = {
            new PetOwner { Name = "Higa", Pets = new List<string> { "Scruffy", "Sam" } },
            new PetOwner { Name = "Ashkenazi", Pets = new List<string> { "Walker", "Sugar" } },
            new PetOwner { Name = "Price", Pets = new List<string> { "Scratches", "Diesel" } },
            new PetOwner { Name = "Hines", Pets = new List<string> { "Dusty" } }
        };

        var query = petOwners
            .SelectMany(petOwner => petOwner.Pets, (petOwner, petName) => new { petOwner, petName })
            .Where(ownerAndPet => ownerAndPet.petName.StartsWith("S"))
            .Select(ownerAndPet => new {
                Owner = ownerAndPet.petOwner.Name,
                Pet = ownerAndPet.petName
            });

        Console.WriteLine("Pets starting with 'S':");
        foreach (var result in query)
        {
            Console.WriteLine($"Owner: {result.Owner}, Pet: {result.Pet}");
        }
    }
}
