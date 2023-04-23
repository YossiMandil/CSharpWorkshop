using System.Collections;
using System.Text;

#region ExtensionMethods


public static class ExtensionMethodsSolutions
{
    public static string ReverseOnlyChars(this string str)
    {
        if (string.IsNullOrEmpty(str))
            return str;

        var strLen = str.Length;
        char[] result = new char[strLen];

        int start = 0;
        int end = strLen - 1;

        while (start <= end)
        {
            if (!char.IsLetter(str[start]))
            {
                result[start] = str[start];
                start++;
            }
            else if (!char.IsLetter(str[end]))
            {
                result[end] = str[end];
                end--;
            }
            else
            {
                result[start] = str[end];
                result[end] = str[start];
                start++;
                end--;
            }
        }

        return new string(result);
    }
}

public static class ListExtensions
{
    public static bool ContainsSum(this List<int> list, int targetSum)
    {
        HashSet<int> set = new HashSet<int>();

        foreach (int num in list)
        {
            int complement = targetSum - num;
            if (set.Contains(complement))
            {
                return true;
            }

            set.Add(num);
        }

        return false;
    }
}

#endregion


#region Inheritance

public static class Answers
{
    public static List<char> Ex1_GetAnswer => new() { 'a', 'c', 'c', 'd', };
    public static List<char> Ex2_GetAnswer => new() { 'a', 'd', 'd', 'd', };
    public static List<char> Ex3_GetAnswer => new() { 'a', 'c', 'c', 'd', };
}
#endregion

#region CustomList
public class MyList<T> : IEnumerable<T>
{
    private T[] _items;
    private int _count;

    public int Count => _count;

    public MyList()
    {
        _items = new T[4]; // Start with an initial capacity of 4
        _count = 0;
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= _count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return _items[index];
        }
        set
        {
            if (index < 0 || index >= _count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            _items[index] = value;
        }
    }

    public void Add(T item)
    {
        if (_count == _items.Length)
        {
            // If the array is full, double its capacity
            T[] newItems = new T[_items.Length * 2];
            Array.Copy(_items, newItems, _items.Length);
            _items = newItems;
        }

        _items[_count] = item;
        _count++;
    }

    public bool Remove(T item)
    {
        int index = Array.IndexOf(_items, item);
        if (index == -1)
        {
            // Item not found in the list
            return false;
        }

        // Shift all the items to the left to fill the gap left by the removed item
        for (int i = index; i < _count - 1; i++)
        {
            _items[i] = _items[i + 1];
        }

        _count--;
        _items[_count] = default!; // Set the last item to default value to avoid memory leaks

        if (_count <= _items.Length / 4)
        {
            // If the array is less than 25% full, halve its capacity
            T[] newItems = new T[_items.Length / 2];
            Array.Copy(_items, newItems, _count);
            _items = newItems;
        }

        return true;
    }

    public IEnumerable<T> Distinct()
    {
        var seen = new HashSet<T>();

        for (int i = 0; i < _count; i++)
        {
            var currentElement = _items[i];

            if (seen.Add(currentElement))
            {
                yield return currentElement;
            }
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new MyEnumerator<T>(_items, _count);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<T> GetEnumerator(Func<T, bool> predicate)
    {
        return new MyEnumerator<T>(_items, _count, predicate);
    }
}

public class MyEnumerator<T> : IEnumerator<T>
{
    private int _index = -1;
    private readonly int _count;
    private readonly T[] _items;
    private readonly Func<T, bool>? _predicate;

    public MyEnumerator(T[] items, int currentCount, Func<T, bool>? predicate = null)
    {
        _items = items;
        _count = currentCount;
        _predicate = predicate;
    }

    public T Current
    {
        get
        {
            if (_index >= _count)
                throw new InvalidOperationException();

            return _items[_index];
        }
    }

    object? IEnumerator.Current => Current;

    public void Dispose()
    {

    }

    public bool MoveNext()
    {
        _index++;

        if (_predicate is null)
            return _index < _count;

        while (_index < _count && !_predicate(_items[_index]))
        {
            _index++;
        }

        return _index < _count;
    }

    public void Reset()
    {
        _index = -1;
    }
}

#endregion


#region LINQ

public static class LinqExercise
{
    //Given a list of custom objects that contain a name and date of birth property, return the names of all objects where the age is between 18 and 30, sorted in alphabetical order.
    public static IEnumerable<string> Ex1(this IEnumerable<Person> people)
    {
        return people
            .Where(p => p.DateOfBirth >= DateTime.Today.AddYears(-30) && p.DateOfBirth < DateTime.Today.AddYears(-18))
            .OrderBy(p => p.Name)
            .Select(p => p.Name);
    }

    //Given a list of people, write a method to group the people by the year of their DateTime property and return a dictionary with the year as the key and the list of objects as the value.
    public static Dictionary<int, List<Person>> Ex2(this List<Person> people)
    {
        return people
             .GroupBy(p => p.DateOfBirth.Year)
             .ToDictionary(g => g.Key, g => g.ToList());
    }

    //Given a list of integers, write a method to find the second smallest number in the list.
    public static int Ex3(this IEnumerable<int> numbers)
    {
        return numbers.OrderBy(x => x).Skip(1).First();
    }
}
public record Person(string Name, DateTime DateOfBirth);

#endregion

#region Processors
public interface IProcessor<TInput, Toutput>
{
    Toutput Process(TInput input);
    string Name { get; }
}

public class DataProcessor<TInput, TOutput>
{
    private readonly IProcessor<TInput, TOutput> _processor;

    public DataProcessor(IProcessor<TInput, TOutput> processor)
    {
        _processor = processor;
    }

    public IEnumerable<TOutput> ProccessData(IEnumerable<TInput> dataToProcess) => dataToProcess.Select(x => _processor.Process(x));
}



#endregion