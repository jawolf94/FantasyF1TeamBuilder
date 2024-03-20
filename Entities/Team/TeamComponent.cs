﻿using Fantasy.Rules;

namespace Fantasy.Team;

/// <summary>
/// An entity which represents a playable component on a fantasy team.
/// </summary>
public abstract class TeamComponent : IValidatable
{
	/// <summary>
	/// Initializes a new instance of <see cref="TeamComponent"/>
	/// </summary>
	protected TeamComponent(string name, decimal cost)
	{
		Name = name;
		Cost = cost;
	}

	/// <summary>
	/// Name of the entity.
	/// </summary>
	public string Name { get; }

	/// <summary>
	/// Cost of the entity (in millions of dollars)
	/// </summary>
	public decimal Cost { get; }

	/// <summary>
	/// True if the entity is valid.
	/// </summary>
	public bool IsValid => IsEntityValid();

	/// <summary>
	/// Fantasy points awarded including point modifiers.
	/// </summary>
	public double TotalPoints => ApplyPointsModifiers(BasePoints);

	/// <summary>
	/// Fantasy points awareded before modifiers
	/// </summary>
	public double BasePoints { get; set; }

	/// <summary>
	/// Returns true if the data represented by this entity is valid according to game rules.
	/// </summary>
	protected abstract bool IsEntityValid();

	/// <summary>
	/// Modifies the points scored accoring to the game rules.
	/// </summary>
	protected abstract double ApplyPointsModifiers(double points);
}