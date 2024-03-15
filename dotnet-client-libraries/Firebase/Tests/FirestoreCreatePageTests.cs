using Firebase.Interfaces;
using Firebase.Models;
using Firebase.Pages.Firestore;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests;
public class FirestoreCreatePageTests
{
    private readonly List<Shoe> _shoes = new();
    private readonly Mock<IFirestoreService> _firestoreService;
    private readonly Mock<IFirebaseStorageService> _storageService;
    private readonly Mock<IFormFile> _formFileMock;

    public FirestoreCreatePageTests()
    {
        _firestoreService = new Mock<IFirestoreService>();
        _storageService = new Mock<IFirebaseStorageService>();
        _formFileMock = new Mock<IFormFile>();
    }

    [Fact]
    public async Task GivenAValidShoeForm_WhenSubmittingForm_ThenUploadsFileToCloudStorage()
    {
        // Arrange
        var shoeDto = new Firebase.Dtos.ShoeDto
        {
            Name = "Pegasus 39",
            Brand = "Nike",
            Price = 129.99m,
            Image = _formFileMock.Object
        };

        var page = new CreateModel(_firestoreService.Object, _storageService.Object)
        {
            Shoe = shoeDto
        };

        // Act
        await page.OnPostAsync();

        // Assert
        _storageService.Verify(s => s.UploadFile(shoeDto.Name, shoeDto.Image), Times.Once);
    }

    [Fact]
    public async Task GivenAValidShoeForm_WhenSubmittingForm_ThenAddsShoeToStore()
    {
        // Arrange
        var shoeDto = new Firebase.Dtos.ShoeDto
        {
            Name = "Pegasus 39",
            Brand = "Nike",
            Price = 129.99m,
            Image = _formFileMock.Object
        };

        var page = new CreateModel(_firestoreService.Object, _storageService.Object)
        {
            Shoe = shoeDto
        };

        // Act
        await page.OnPostAsync();

        // Assert
        _firestoreService.Verify(f => f.Add(It.Is<Shoe>(s => s.Name == shoeDto.Name 
                && s.Brand == shoeDto.Brand 
                && s.Price == shoeDto.Price)), Times.Once);
    }
}
