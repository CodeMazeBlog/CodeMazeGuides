# Blazor WebAssembly Localization

Sample project for the "Blazor Localization in WebAssembly Applications" article.

Standard Blazor WebAssembly Standalone App template (`net10.0`) with localization added:

- `Microsoft.Extensions.Localization` registered through `builder.Services.AddLocalization()` in
  `Program.cs` — a standalone WebAssembly app still needs that package explicitly, the SDK does not
  bring it in.
- `Shared/ResourceFiles/Resource.resx` (neutral/English) and `Resource.de.resx` (German), both with a
  public access modifier, injected into `Pages/Home.razor` as `IStringLocalizer<Resource>`.
- `Shared/CultureSelector.razor` lets the user pick a culture. Its `Culture` setter writes the culture
  name to `localStorage` through the `blazorCulture` object in `wwwroot/index.html` and then navigates
  with `forceLoad: true` — the reload is deliberate, because the culture has to be established while
  the host is being built, before the first component renders.
- `Extensions/WebAssemblyHostExtension.cs` reads that value back and sets
  `CultureInfo.DefaultThreadCurrentCulture` / `DefaultThreadCurrentUICulture` before `RunAsync()`.
- `<BlazorWebAssemblyLoadAllGlobalizationData>true</BlazorWebAssemblyLoadAllGlobalizationData>` in the
  project file ships the full ICU data. Without it Blazor loads only the ICU file matching the app's
  own culture, and switching to a culture outside that shard fails at runtime.

Migrated here from the standalone `CodeMazeBlog/blazor-wasm-localization` repository and retargeted
from `net5.0` to `net10.0`.
