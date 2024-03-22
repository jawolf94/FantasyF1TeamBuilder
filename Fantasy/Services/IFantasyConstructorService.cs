using Fantasy.Team;

namespace Fantasy.Services;

/// <summary>
/// Gets fantasy data for constructors
/// </summary>
public interface IFantasyConstructorService
{
	/// <summary>
	/// Gets all <see cref="Constructor"/> components
	/// </summary>
	Task<List<Constructor>> GetConstructorData();
}
