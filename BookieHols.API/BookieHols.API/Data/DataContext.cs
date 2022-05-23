using Microsoft.EntityFrameworkCore;
using BookieHols.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

/// <summary>
/// The Data Context class
/// </summary>
public class DataContext : IdentityDbContext<
	User,
	AppRole,
	int,
	IdentityUserClaim<int>,
	AppUserRole,
	IdentityUserLogin<int>,
	IdentityRoleClaim<int>,
	IdentityUserToken<int>>
{
	public DataContext(DbContextOptions<DataContext> options )
		: base(options)
	{

	}

	///// <summary>
	///// The User table
	///// </summary>
	//public DbSet<User> Users { get; set; } = null!;

	protected override void OnModelCreating(ModelBuilder builder) 
	{
		base.OnModelCreating(builder);

		builder.Entity<User>()
			 .HasMany(ur => ur.UserRoles)
			 .WithOne(u => u.User)
			 .HasForeignKey(ur => ur.UserId)
			 .IsRequired();

		builder.Entity<AppRole>()
			.HasMany(ur => ur.UserRoles)
			.WithOne(u => u.Role)
			.HasForeignKey(ur => ur.RoleId)
			.IsRequired();
	}
}