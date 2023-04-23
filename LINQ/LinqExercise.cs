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

        //Given a list of people, write a method that returns a dictionary that maps between year of birth and a list of people that were born in this year
        public static Dictionary<int, List<Person>> Ex2(this List<Person> people)
        {
            return new Dictionary<int, List<Person>>();
        }

        //Given a list of integers, write a method to find the second smallest number in the list.
        public static int Ex3(this IEnumerable<int> numbers)
        {
            return 0;
        }

        //Given a list of integers, write a LINQ query to find all pairs of integers in the list whose sum is equal to a specified target value.The resulting pairs should be sorted in ascending order based on the first integer in the pair, and then in ascending order based on the second integer in the pair.
        public static IEnumerable<(int,int)> Ex4(this IEnumerable<int> numbers, int target)
        {
            return Enumerable.Empty<(int, int)>();
        }

    }

    public record Person(string Name, DateTime DateOfBirth);

}