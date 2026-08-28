## FluentValidation Validators in C#: Built-in and Custom

Source code for [FluentValidation Validators in C#: Built-in and Custom](https://code-maze.com/deep-dive-validators-fluentvalidation/).

| Folder | What it is |
| - | - |
| `ClassLibrary1` | The validators themselves — `Order`, `Product`, `OrderValidator`, `ProductValidator`, and the `FullName()` custom validator written as an extension method on `IRuleBuilder<T, string>`. |
| `WebApplication1` | An ASP.NET Core API that references the class library, registers every validator with `AddValidatorsFromAssemblyContaining<OrderValidator>()`, and invokes `IValidator<Order>` explicitly in `OrdersController`. |
| `Tests` | Tests over the validators: the custom `FullName()` message, `CascadeMode.Stop` reporting one failure instead of two, `IsInEnum()` rejecting an undeclared member, `RuleForEach()` reporting the item index, and the exact strings `EmailAddress()` does and does not accept. |

Everything targets .NET 10 and FluentValidation 12.

```
dotnet build FluentValidationValidators.sln
dotnet test FluentValidationValidators.sln
```

### A note on `FluentValidation.AspNetCore`

The API project does **not** reference `FluentValidation.AspNetCore`, and this is
deliberate on two counts.

The package stops at **11.3.1** — there is no 12.x — so it cannot be paired with
FluentValidation 12.1.1. And the automatic-validation pipeline it provides is the
approach FluentValidation's own ASP.NET Core documentation says it "no longer
recommend[s] ... for new projects", while still supporting it for legacy code.

The current path is the one this sample uses: register the validators with
`AddValidatorsFromAssemblyContaining()` from
`FluentValidation.DependencyInjectionExtensions`, inject `IValidator<T>`, and call
`ValidateAsync()` where the validation belongs.
