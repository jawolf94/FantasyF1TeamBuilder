﻿using Results.Data;

namespace Results.Services;

/// <summary>
/// Gets results for constructors
/// </summary>
public interface IConstructorResultService
{
	/// <summary>
	/// Returns result data for all constructors.
	/// </summary>
	Task<List<ConstructorRaceResults>> GetResults();
}
