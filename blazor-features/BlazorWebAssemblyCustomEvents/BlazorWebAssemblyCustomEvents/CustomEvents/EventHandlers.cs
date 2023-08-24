using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorWebAssemblyCustomEvents.CustomEvents
{
    [EventHandler("ondoubleclick", typeof(DoubleClickEventArgs), enableStopPropagation: true, enablePreventDefault: true)]
    public static class EventHandlers
    {
        // purposefully empty
    }

    public class DoubleClickEventArgs : EventArgs
    {
        public DateTime EventTimestamp { get; set; }
        public bool IsDoubleClick { get; set; }
    }
}
