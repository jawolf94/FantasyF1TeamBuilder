using Fantasy.Team;

namespace Fantasy.Services;

/// <summary>
/// Gets fantasy data for constructors
/// </summary>
public interface IFantasyConstructorService
{
	/// <summary>
	/// Gets an <see cref="Constructor"/> entity for each constructor.
	/// </summary>
	Task<List<Constructor>> GetConstructorData();
}
