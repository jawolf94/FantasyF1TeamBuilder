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
		var success = decimal.TryParse(stringValue, out var result);
		if(success) 
		{
			return result;
		}

		throw new FormatException($"Could not format {context} as a decimal. Unexpected format.");
	}

	/// <summary>
	/// Parses a string to an int.
	/// </summary>
	/// <param name="stringValue">The string to parse.</param>
	/// <param name="context">The context in which this is parsed. Used for error reporting.</param>
	/// <returns>An int value parsed from the string.</returns>
	/// <exception cref="FormatException">Thrown if the string cannot be parsed to an in.</exception>
	public static int AsInt(string stringValue, string context = "string")
	{
		var success = int.TryParse(stringValue, out var result);
		if (success)
		{
			return result;
		}

		throw new FormatException($"Could not format {context} as a int. Unexpected format.");
	}
}
