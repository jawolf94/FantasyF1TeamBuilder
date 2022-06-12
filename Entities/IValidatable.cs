namespace Entities
{
	/// <summary>
	/// Interface for entities with Validation rules.
	/// </summary>
	public interface IValidatable
	{
		/// <summary>
		/// True if the entity is valid.
		/// </summary>
		bool IsValid { get; }
	}
}