# Blazor Sections

Sample project for the "Blazor Sections: SectionOutlet and SectionContent" article.

Standard Blazor WebAssembly Standalone App template (`net10.0`). The app has no server-rendering
component, so it runs entirely in the browser under `InteractiveWebAssembly`-equivalent
client-side rendering — there is only one render mode in play, which is why `SectionOutlet` and
`SectionContent` resolve without the layout/page render-mode mismatch the article's "Interactive
Render Modes" section describes for Blazor Web Apps.
