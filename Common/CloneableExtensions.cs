namespace Common;

/// <summary>
/// Extension methods for the <seealso cref="ICloneable"/> interface.
/// </summary>
public static class CloneableExtensions
{
	public static T CloneAs<T>(this ICloneable cloneable) 
	{
		return (T) cloneable.Clone();
	}
}
