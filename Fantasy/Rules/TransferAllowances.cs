namespace Fantasy.Rules;

public static class TransferAllowances
{
	/// <summary>
	/// Number of free transfers allowed per race week.
	/// </summary>
	public const int FreeTransferAllowance = 2;

	/// <summary>
	/// Number of points lost per transfer over the allowance.
	/// </summary>
	public const double PointsPerAdditionalTransfer = 10;

	/// <summary>
	/// Calculates the number of points lost given the number of transfers made.
	/// </summary>
	public static double CalculateCostOfTransfers(int numberOfTransfers) 
	{
		if (numberOfTransfers <= FreeTransferAllowance) 
		{
			return 0;
		}

		var numberOfExcessiveTransfers = numberOfTransfers - FreeTransferAllowance;
		return numberOfExcessiveTransfers * PointsPerAdditionalTransfer;
	}
}
