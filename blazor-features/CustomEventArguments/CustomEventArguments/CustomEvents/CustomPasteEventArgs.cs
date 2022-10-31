using System;
using Microsoft.AspNetCore.Components;

namespace CustomEventArguments.CustomEvents
{
    [EventHandler("oncustomcut", typeof(CustomCutEventArgs), enableStopPropagation: true, enablePreventDefault: true)]
    [EventHandler("oncustomcopy", typeof(CustomCopyEventArgs), enableStopPropagation: true, enablePreventDefault: true)]
    [EventHandler("oncustompaste", typeof(CustomPasteEventArgs), enableStopPropagation: true, enablePreventDefault: true)]

    public static class EventHandlers
    {
        // This static class doesn't need to contain any members. It's just a place where we can put
        // [EventHandler] attributes to configure event types on the Razor compiler. This affects the
        // compiler output as well as code completions in the editor.
    }


    public class CustomCutEventArgs : EventArgs
    {
        // Data for these properties will be supplied by custom JavaScript logic
        public DateTime EventTimestamp { get; set; }
        public string CutData { get; set; }
        public string YourLocation { get; set; }
    }

    public class CustomCopyEventArgs : EventArgs
    {
        // Data for these properties will be supplied by custom JavaScript logic
        public DateTime EventTimestamp { get; set; }
        public string CopiedData { get; set; }
        public string YourLocation { get; set; }
    }

    public class CustomPasteEventArgs : EventArgs
    {
        // Data for these properties will be supplied by custom JavaScript logic
        public DateTime EventTimestamp { get; set; }
        public string PastedData { get; set; }       
    }
}