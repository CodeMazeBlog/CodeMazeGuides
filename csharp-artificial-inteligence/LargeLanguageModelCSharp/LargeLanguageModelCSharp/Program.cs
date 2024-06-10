using LLama.Common;
using LLama;

// Model GGUF: https://huggingface.co/TheBloke/phi-2-GGUF

string modelPath = @"C:\Users\Alvaro\Downloads\phi-2.Q4_K_M.gguf";

var parameters = new ModelParams(modelPath)
{
    ContextSize = 1024, // The longest length of chat as memory.
    GpuLayerCount = 5 // How many layers to offload to GPU. Please adjust it according to your GPU memory.
};

using var model = LLamaWeights.LoadFromFile(parameters);
using var context = model.CreateContext(parameters);
var executor = new InteractiveExecutor(context);

// Add chat histories as prompt to tell AI how to act.
var chatHistory = new ChatHistory();
chatHistory.AddMessage(AuthorRole.System, "Transcript of a dialog, where the User interacts with an Assistant named Bob. Bob is helpful, kind, honest, good at writing, and never fails to answer the User's requests immediately and with precision.");
chatHistory.AddMessage(AuthorRole.User, "Hello, Bob.");
chatHistory.AddMessage(AuthorRole.Assistant, "Hello. How may I help you today?");

ChatSession session = new(executor, chatHistory);

InferenceParams inferenceParams = new InferenceParams()
{
    MaxTokens = 256, // No more than 256 tokens should appear in answer. Remove it if antiprompt is enough for control.
    AntiPrompts = new List<string> { "User:" }, // Stop generation once antiprompts appear.
};

Console.ForegroundColor = ConsoleColor.Yellow;
Console.Write("The chat session has started.\nUser: ");
Console.ForegroundColor = ConsoleColor.Green;
string userInput = Console.ReadLine() ?? "";

while (userInput != "exit")
{
    await foreach ( // Generate the response streamingly.
        var text
        in session.ChatAsync(
            new ChatHistory.Message(AuthorRole.User, userInput),
            inferenceParams))
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(text);
    }
    Console.ForegroundColor = ConsoleColor.Green;
    userInput = Console.ReadLine() ?? "";
}