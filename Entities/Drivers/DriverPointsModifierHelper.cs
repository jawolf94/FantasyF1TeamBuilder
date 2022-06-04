﻿
namespace Entities.Drivers
{
	/// <summary>
	/// Provides helper functions for <see cref="DriverPointsModifier"/>.
	/// </summary>
	public static class DriverPointsModifierHelper
	{
		/// <summary>
		/// Maximum cost of a driver to be an eligible turbo driver.
		/// </summary>
		public const decimal MaxTurboDriverCost = 19.9m;

		/// <summary>
		/// Maps a <see cref="DriverPointsModifier"/> to the it's mulitplier.
		/// </summary>
		public static int GetAppliedModifier(DriverPointsModifier pointsModifier)
		{
			return pointsModifier switch
			{
				DriverPointsModifier.None => 1,
				DriverPointsModifier.Turbo => 2,
				DriverPointsModifier.Mega => 3,
				_ => throw new NotSupportedException($"Driver points modifier {pointsModifier} is not supported.")
			};
		}
	}
}
