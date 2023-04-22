using System.Collections.Generic;

namespace LINQ
{
    public static class LinqExercise
    {
        //Given a list of people that contain a name and date of birth property, return the names of all objects where the age is between 18 and 30, sorted in alphabetical order.
        public static IEnumerable<string> Ex1(this IEnumerable<Person> people)
        {
            return Enumerable.Empty<string>();
        }

        //Given a list of people, write a method to group the people by the year of their DateTime property and return a dictionary with the year as the key and the list of objects as the value.
        public static Dictionary<int, List<Person>> Ex2(this List<Person> people)
        {
            return new Dictionary<int, List<Person>>();
        }

        //Given a list of integers, write a method to find the second smallest number in the list.
        public static int Ex3(this IEnumerable<int> numbers)
        {
            return 0;
        }

    }

    public record Person(string Name, DateTime DateOfBirth);

}