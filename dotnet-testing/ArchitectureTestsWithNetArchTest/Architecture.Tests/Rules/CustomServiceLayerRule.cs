namespace Architecture.Tests.Rules;

public class CustomServiceLayerRule : ICustomRule
{
    public bool MeetsRule(TypeDefinition type)
        => type.IsInterface && type.IsPublic && type.Name.StartsWith('I');
}
