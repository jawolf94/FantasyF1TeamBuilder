namespace Common;

/// <summary>
/// Provides common extension methods for parsing strings.
/// </summary>
public static class ParseString
{
	/// <summary>
	/// Parses a string to a decimal.
	/// </summary>
	/// <param name="stringValue">The string to parse.</param>
	/// <param name="context">The context in which this is parsed. Used for error reporting.</param>
	/// <returns>A decimal value parsed from the string.</returns>
	/// <exception cref="FormatException">Thrown if the string cannot be parsed to a decimal.</exception>
	public static decimal AsDecimal(string stringValue, string context = "string") 
	{
		var isSuccessful = decimal.TryParse(stringValue, out var result);
		return isSuccessful ? result : throw FormatExceptionWithContext("decimal", context);
	}

	/// <summary>
	/// Parses a string to an int.
	/// </summary>
	/// <param name="stringValue">The string to parse.</param>
	/// <param name="context">The context in which this is parsed. Used for error reporting.</param>
	/// <returns>An int value parsed from the string.</returns>
	/// <exception cref="FormatException">Thrown if the string cannot be parsed to an int.</exception>
	public static int AsInt(string stringValue, string context = "string")
	{
		var isSuccessful = int.TryParse(stringValue, out var result);
		return isSuccessful ? result : throw FormatExceptionWithContext("int", context);
	}

	/// <summary>
	/// Parses a string to a bool.
	/// </summary>
	/// <param name="stringValue">The string to parse.</param>
	/// <param name="context">The context in which this is parsed. Used for error reporting.</param>
	/// <returns>An bool value parsed from the string.</returns>
	/// <exception cref="FormatException">Thrown if the string cannot be parsed to a bool.</exception>
	public static bool AsBool(string stringValue, string context= "string") 
	{
		var isSuccessful = bool.TryParse(stringValue, out var result);
		return isSuccessful ? result : throw FormatExceptionWithContext("bool", context);
	}

	private static FormatException FormatExceptionWithContext(string parseType, string parseContext) => 
		new FormatException($"Could not format {parseContext} as {parseType}. Unexpected format.");
}
