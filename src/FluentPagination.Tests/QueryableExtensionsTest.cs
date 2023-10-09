using Bogus;
using FluentAssertions;
using FluentPagination.Tests.Data;
using Microsoft.EntityFrameworkCore;
using Person = FluentPagination.Tests.Data.Person;

namespace FluentPagination.Tests;

public class QueryableExtensionsTest
{
    private readonly Context _context;
    
    public QueryableExtensionsTest()
    {
        _context = new Context();
        _context.Database.EnsureCreated();

        var people = new Faker<Person>()
            .RuleFor(x => x.FullName, f => f.Person.FullName)
            .RuleFor(x => x.BornedAt, f => f.Person.DateOfBirth)
            .Generate(30);
        
        _context.People.AddRange(people);
        _context.SaveChanges();
    }
    
    [Fact]
    public async Task FirstPage()
    {
        var people = await _context.People
            .FirstPage(pageSize: 10)
            .ToListAsync();

        people.Should()
            .NotBeNullOrEmpty()
            .And
            .HaveCount(10);

        people.Should()
            .HaveCount(10);
    }
}