using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorWebAssemblyCustomEvents.CustomEvents
{
    [EventHandler("onfilechange", typeof(FileChangeEventArgs), enableStopPropagation: true, enablePreventDefault: true)]
    public static class EventHandlers
    {
        // purposefully empty
    }

    public class FileChangeEventArgs : EventArgs
    {
        public DateTime? EventTimestamp { get; set; }
        //public byte[]? FileData { get; set; }
        public string? FileExtension { get; set; }
        public string? Value { get; set; }
    }
}
