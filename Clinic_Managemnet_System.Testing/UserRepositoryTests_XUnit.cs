
using Xunit;
using System;
using System.Threading.Tasks;
using System.Linq;
using ClinicManagementSystem.Data;

using Microsoft.EntityFrameworkCore;
using ClinicManagementSystem.Domain.Repositories;
using ClinicManagementSystem.Domain.Models;

public class UserRepositoryTests_XUnit
{
    private readonly DbContextOptions<ClinicContext> _options;
    public UserRepositoryTests_XUnit()
    {
        _options = new DbContextOptionsBuilder<ClinicContext>()
            .UseInMemoryDatabase(databaseName: "ClinicDB_Test")
            .Options;
    }

    private async Task<ClinicContext> GetInMemoryContextAsync()
    {
        var options = new DbContextOptionsBuilder<ClinicContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        var context = new ClinicContext(options);
        await context.Database.EnsureCreatedAsync();
        return context;
    }

    [Fact]
    public async Task CreateAsync_Should_Add_New_User()
    {
        // Arrange
        using var context = new ClinicContext(_options);
        var repository = new UserRepository(context);
        var user = new User
        {
            Name = "TestUser",
            Email = "test@example.com", 
            PhoneNumber = 9876543210,
            Password = "StrongPassword123!" 
        };

        // Act
        await repository.CreateAsync(user);
        await context.SaveChangesAsync();

        // Assert
        var createdUser = await context.Users.FirstOrDefaultAsync(u => u.Email == "test@example.com");
        Assert.NotNull(createdUser);
        Assert.Equal("TestUser", createdUser.Name);
    }

    [Fact]
    public async Task GetByEmailAsync_Should_Return_User()
    { 
        var context = await GetInMemoryContextAsync();
        var repo = new UserRepository(context);

        var user = new User
        {
            UserID = Guid.NewGuid(),
            Name = "Jane",
            Email = "jane@example.com",
            Password = "Password@123" 
        };
        await repo.CreateAsync(user);

        // Act
        var found = await repo.GetByEmailAsync("jane@example.com");

        // Assert
        Assert.NotNull(found);
        Assert.Equal("June", found.Name);
    }

    [Fact]
    public async Task DeleteAsync_Should_Remove_User()
    {
        var context = await GetInMemoryContextAsync();
        var repo = new UserRepository(context);

        var user = new User
        {
            UserID = Guid.NewGuid(),
            Name = "Alex",
            Email = "alex@example.com",
            Password = "Delete@123" 
        };
        await repo.CreateAsync(user);

        // Act
        var deleted = await repo.DeleteAsync(user.UserID);

        // Assert
        Assert.True(deleted);
        Assert.Empty(context.Users);
    }
}
