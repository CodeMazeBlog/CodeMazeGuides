using Firebase.Interfaces;
using Firebase.Models;
using Firebase.Pages.Firestore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests;


public class FirestoreIndexPageTests
{
    private readonly List<Shoe> _shoes = new();
    private readonly Mock<IFirestoreService> _firestoreService;

    public FirestoreIndexPageTests()
    {
        _firestoreService = new Mock<IFirestoreService>();
    }

    [Fact]
    public async Task GivenShoesInStore_WhenRequestingFirestoreIndexPage_ThenPopulatesListOfShoes()
    {
        // Arrange
        _shoes.Add(new Shoe
        {
            Id = "1234",
            Name = "Pegasus 39",
            Brand = "Nike",
            Price = 129.99m,
            ImageUri = new Uri("https://example.com")
        });

        _firestoreService.Setup(s => s.GetAll())
            .ReturnsAsync(_shoes);

        var page = new IndexModel(_firestoreService.Object);

        // Act
        await page.OnGetAsync();

        // Assert
        Assert.NotNull(page.Shoes);
        Assert.Equal(_shoes, page.Shoes);
    }
}
