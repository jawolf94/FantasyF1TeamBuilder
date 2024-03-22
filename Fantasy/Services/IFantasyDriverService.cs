using Fantasy.Team;

namespace Fantasy.Services;

/// <summary>
/// Gets fantasy data for driver components
/// </summary>
public interface IFantasyDriverService
{
	/// <summary>
	/// Gets all <see cref="Driver"/> driver components
	/// </summary>
	Task<List<Driver>> GetDriverData();
}
