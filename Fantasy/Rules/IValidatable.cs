namespace Fantasy.Rules;

/// <summary>
/// Interface for an object with validation logic.
/// </summary>
public interface IValidatable
{
	/// <summary>
	/// Returns true if the object is valid.
	/// </summary>
	bool IsValid { get; }
}
