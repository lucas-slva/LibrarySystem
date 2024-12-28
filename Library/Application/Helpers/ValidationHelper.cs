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
}