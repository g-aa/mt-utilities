using System.Text;

namespace Mt.Utilities.Extensions;

/// <summary>
/// Расширения стандартного функционала класса string.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Алфавит транслитерации: ISO 9:1995, ГОСТ 7.79-2000 (Система Б).
    /// </summary>
    private static readonly IReadOnlyDictionary<char, string> _alphabet = new Dictionary<char, string>()
    {
        { 'а', "a" },
        { 'б', "b" },
        { 'в', "v" },
        { 'г', "g" },
        { 'д', "d" },
        { 'е', "e" },
        { 'ё', "yo" },
        { 'ж', "zh" },
        { 'з', "z" },
        { 'и', "i" },
        { 'й', "j" },
        { 'к', "k" },
        { 'л', "l" },
        { 'м', "m" },
        { 'н', "n" },
        { 'о', "o" },
        { 'п', "p" },
        { 'р', "r" },
        { 'с', "s" },
        { 'т', "t" },
        { 'у', "u" },
        { 'ф', "f" },
        { 'х', "x" },
        { 'ц', "cz" },
        { 'ч', "ch" },
        { 'ш', "sh" },
        { 'щ', "shh" },
        { 'ъ', string.Empty },
        { 'ы', "y" },
        { 'ь', string.Empty },
        { 'э', "e" },
        { 'ю', "yu" },
        { 'я', "ya" },
    };

    /// <summary>
    /// Транслитерация с русского языка на английский язык.
    /// </summary>
    /// <param name="str">Входная строка на русском языке.</param>
    /// <returns>Результирующая строка на английском языке.</returns>
    /// <remarks>ISO 9:1995, ГОСТ 7.79-2000 (Система Б)</remarks>
    public static string Ru2Eng(this string str)
    {
        Check.NotNull(str, nameof(str));

        var result = new StringBuilder();
        Array.ForEach(str.ToCharArray(), (char ch) =>
        {
            var index = char.ToLower(ch);
            if (!_alphabet.ContainsKey(index))
            {
                result.Append(ch);
            }
            else
            {
                result.Append(char.IsUpper(ch) ? _alphabet[index].ToUpper() : _alphabet[index]);
            }
        });

        return result.ToString();
    }
}