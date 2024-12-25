namespace Library.Application.Helpers;

public static class ValidationHelper
{
    public static void ValidateStrings(params (string Value, string propertyName)[] properties)
    {
        foreach (var (value, propertyName) in properties)
        {
            if(string.IsNullOrEmpty(value)) throw new ArgumentNullException($"{propertyName} cannot be empty");
        }
    }

    public static void ValidateStrings(params object[] objects)
    {
        foreach (var obj in objects)
        {
            if(obj == null) throw new ArgumentNullException($"{obj} cannot be null");
        }
    }
}