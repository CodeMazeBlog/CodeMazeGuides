using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Globalization;

namespace BlazorWasmLocalization.Shared
{
	public partial class CultureSelector
	{
		[Inject]
		public NavigationManager NavManager { get; set; } = default!;

		[Inject]
		public IJSRuntime JSRuntime { get; set; } = default!;

		CultureInfo[] cultures = new[]
		{
			new CultureInfo("en-US"),
			new CultureInfo("de-DE")
		};

		CultureInfo Culture
		{
			get => CultureInfo.CurrentCulture;
			set
			{
				if (CultureInfo.CurrentCulture != value)
				{
					var js = (IJSInProcessRuntime)JSRuntime;
					js.InvokeVoid("blazorCulture.set", value.Name);

					NavManager.NavigateTo(NavManager.Uri, forceLoad: true);
				}
			}
		}
	}
}
