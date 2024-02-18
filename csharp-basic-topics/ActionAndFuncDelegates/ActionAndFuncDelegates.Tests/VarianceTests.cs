using FluentAssertions;

namespace ActionAndFuncDelegates.Tests;

public class VarianceTests
{
    [Fact]
    public void Actions_inputs_are_contravariant()
    {
        bool animalActionCalled = false;
        bool bearActionCalled = false;
        Action<Animal> animalAction = (Animal animal) =>
        {
            animalActionCalled = true;
        };
        Action<Bear> bearAction = (Bear bear) =>
        {
            bearActionCalled = true;
        };
        bearAction = animalAction;
        bearAction(new Bear());
        Assert.True(animalActionCalled);
        Assert.False(bearActionCalled);
    }

    [Fact]
    public void Func_outputs_are_covariant()
    {
        Func<Animal> animalFunc = () => new Animal();
        Func<Bear> bearFunc = () => new Bear();
        animalFunc = bearFunc;
        Animal animal = animalFunc();
        animal.Should().BeOfType<Bear>();
    }
}