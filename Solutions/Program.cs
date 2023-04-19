using System.Text;
#region ExtensionMethods


public static class ExtensionMethodsSolutions
{
    public static string ReverseOnlyChars(this string str)
    {
        if(string.IsNullOrEmpty(str))
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

#endregion


#region Inheritance

public static class Answers
{
    public static List<char> Ex1_GetAnswer => new() { 'a', 'c', 'c', 'd', };
    public static List<char> Ex2_GetAnswer => new() { 'a', 'd', 'd', 'd', };
    public static List<char> Ex3_GetAnswer => new() { 'a', 'c', 'c', 'd', };
}
#endregion