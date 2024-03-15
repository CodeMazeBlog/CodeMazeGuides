using BlazorWebAssemblyCustomEvents.CustomEvents;

namespace BlazorWebAssemblyCustomEvents.Components
{
    public partial class DoubleClickButton
    {
        string message;

        void HandleDoubleClick(DoubleClickEventArgs eventArgs)
        {
            if (eventArgs is not null && eventArgs.IsDoubleClick)
            {
                message = $"detected double click!";
            }
            else
            {
                message = "";
            }
        }
    }
}
