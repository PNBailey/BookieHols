using System;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using Stocks.API.Models;

/// <summary>
/// The Data Context class
/// </summary>
public class DataContext : DbContext 
{
	public DataContext(DbContextOptions<DataContext> options)
		: base(options)
	{
		
	}

	/// <summary>
	/// The User table
	/// </summary>
	public DbSet<User> Users { get; set; } = null!;
}
