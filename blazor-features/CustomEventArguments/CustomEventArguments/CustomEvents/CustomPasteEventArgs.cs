using System;
using Microsoft.AspNetCore.Components;

namespace CustomEventArguments.CustomEvents
{
    [EventHandler("oncustomcut", typeof(CustomCutEventArgs), enableStopPropagation: true,
        enablePreventDefault: true)]
    [EventHandler("oncustomcopy", typeof(CustomCopyEventArgs), enableStopPropagation: true, 
        enablePreventDefault: true)]
    [EventHandler("oncustompaste", typeof(CustomPasteEventArgs), enableStopPropagation: true, 
        enablePreventDefault: true)]

    public static class EventHandlers
    {       
    }

    public class CustomCutEventArgs : EventArgs
    {
        // Data for these properties will be supplied by custom JavaScript logic
        public DateTime EventTimestamp { get; set; }
        public string? CutData { get; set; }
        public string? YourLocation { get; set; }
    }

    public class CustomCopyEventArgs : EventArgs
    {
        // Data for these properties will be supplied by custom JavaScript logic
        public DateTime EventTimestamp { get; set; }
        public string? CopiedData { get; set; }
        public string? YourLocation { get; set; }
    }

    public class CustomPasteEventArgs : EventArgs
    {
        // Data for these properties will be supplied by custom JavaScript logic
        public DateTime EventTimestamp { get; set; }
        public string? PastedData { get; set; }       
    }
}