using Fantasy.Team;

namespace Fantasy.Services;

/// <summary>
/// Gets fantasy data for driver components
/// </summary>
public interface IFantasyDriverService
{
	/// <summary>
	/// Gets an <see cref="Driver"/> entity for each driver
	/// </summary>
	public Task<List<Driver>> GetDriverData();
}
