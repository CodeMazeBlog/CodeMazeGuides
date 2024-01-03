namespace ActionAndFuncDelegatesInCSharp;
public class ActionDelegates
{
    public class SimulatedUI
    {
        public string Text { get; set; } = string.Empty;
    }

    public Action<SimulatedUI, string> UpdateUIText = (uiElement, msg) =>
    {
        uiElement.Text = $"Message: {msg}";
    };

    public void UpdateUIWithMessage(string message)
    {
        var uiElement = new SimulatedUI();
        UpdateUIText(uiElement, message);
    }
}

