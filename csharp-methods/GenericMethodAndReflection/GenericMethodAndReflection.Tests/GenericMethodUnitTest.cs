using System;
using Xunit;

namespace GenericMethodAndReflection.Tests;

public class GenericMethodUnitTest
{
    [Fact]
    public void GivenGenericMethod_WhenDirectlyInvoked_ThenNeedsExplicitGenericType()
    {
        var builder = new CaptionBuilder();

        var caption1 = builder.ClassCaption<GoodsStore>();
        var caption2 = builder.ClassCaption<Stuff>();

        Assert.Equal("Goods Store", caption1);
        Assert.Equal("Employee", caption2);        
    }

    Type ResolveType(string shortCode)
    {
        return shortCode switch
        {
            "GDS" => typeof(GoodsStore),
            "EMP" => typeof(Stuff),
            _ => throw new NotImplementedException(),
        };
    }

    [Fact]
    public void GivenGenericMethod_WhenUsingReflection_ThenCanBeInvokedWithoutGenericType()
    {
        var type = ResolveType("GDS");

        // Below line does not compile
        // var directResult = new CaptionBuilder().ClassCaption<type>();

        var reflectedResult = new NonGenericCaptionBuilder().ClassCaption(type);

        Assert.Equal("Goods Store", reflectedResult);
    }

    [Fact]
    public void GivenGenericStaticMethod_WhenUsingReflection_ThenCanBeInvokedWithoutGenericType()
    {
        var type = ResolveType("GDS");

        var reflectedResult = NonGenericCaptionBuilder.StaticCaption(type);

        Assert.Equal("GOODSSTORE", reflectedResult);
    }

    [Fact]
    public void GivenGenericMethodWithMultipleGenericTypes_WhenUsingReflection_ThenCanBeInvokedWithoutGenericType()
    {
        var type1 = ResolveType("GDS");
        var type2 = ResolveType("EMP");

        var reflectedResult = new NonGenericCaptionBuilder().ParentChildCaption(type1, type2);

        Assert.Equal("Employee of Goods Store", reflectedResult);
    }

    [Fact]
    public void GivenGenericMethodWithParameters_WhenUsingReflection_ThenCanBeInvokedWithoutGenericType()
    {
        var store = new GoodsStore("Apex", "Street 12");

        var directResult = new CaptionBuilder().ObjectCaption(store);

        var reflectedResult = new NonGenericCaptionBuilder().ObjectCaption(store);

        Assert.Equal("Apex", directResult);
        Assert.Equal(directResult, reflectedResult);
    }


    [Fact]
    public void GivenGenericMethodWithOverloads_WhenUsingReflection_ThenCanInvokeSpecificOverload()
    {
        var store = new GoodsStore("Apex", "Street 12");
        var stuff = new Stuff("John", "Manager");

        var directResult = new CaptionBuilder().ComboCaption(stuff, store, true);

        var reflectedResult = new NonGenericCaptionBuilder().ComboCaption(stuff, store, true);

        Assert.Equal("JOHN (APEX)", directResult);
        Assert.Equal(directResult, reflectedResult);
    }

    [Fact]
    public void GivenGenericMethodWithConstraint_WhenInvokedWithWrongType_ThenFailsForConstraintViolation()
    {
        var type = typeof(GoodsStore);

        Assert.ThrowsAny<ArgumentException>(() => new NonGenericCaptionBuilder().RestrictedCaption(type));
    }

    [Fact]
    public void GivenGenericMethodWithConstraint_WhenInvokedWithWrongTypeHandling_ThenFailsWithAFriendlyException()
    {
        var type = typeof(GoodsStore);

        Assert.ThrowsAny<NotSupportedException>(() => new NonGenericCaptionBuilder().ImprovedRestrictedCaption(type));
    }
}