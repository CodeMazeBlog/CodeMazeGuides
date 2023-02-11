using Microsoft.AspNetCore.Components;

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
        //public string? FileExtension { get; set; }
    }
}
