namespace ActionAndFuncDelegatesInCSharp;
public class ActionDelegates
{
    public class SimulatedUI
    {
        public string Text { get; set; } = string.Empty;
    }

    Action<SimulatedUI, string> updateUIText = (uiElement, msg) =>
    {
        uiElement.Text = $"Message: {msg}";
    };

    public void UpdateUIWithMessage(string message)
    {
        var uiElement = new SimulatedUI();
        updateUIText(uiElement, message);
    }
}

