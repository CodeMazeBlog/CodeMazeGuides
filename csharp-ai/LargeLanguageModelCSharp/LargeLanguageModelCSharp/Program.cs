using LLama.Common;
using LLama;

// Model GGUF: https://huggingface.co/TheBloke/phi-2-GGUF

var modelPath = @"C:\Users\Alvaro\Downloads\phi-2.Q4_K_M.gguf";

var parameters = new ModelParams(modelPath)
{
    ContextSize = 4096, // The longest length of chat as memory.
    GpuLayerCount = 5 // How many layers to offload to GPU. Please adjust it according to your GPU memory.
};

using var model = LLamaWeights.LoadFromFile(parameters);
using var context = model.CreateContext(parameters);
var executor = new InteractiveExecutor(context);

// Add chat histories as prompt to tell AI how to act.
var chatHistory = new ChatHistory();
chatHistory.AddMessage(AuthorRole.System, "Transcript of a dialog, where the User interacts with an Assistant named Bob. Bob's role is to be helpful, provide concise answers, and maintain a kind tone in all interactions. You may be asked to draft emails or messages, so please ensure that your responses are clear, professional, and considerate. Stick strictly to the information provided and do not add any additional commentary or details beyond the task at hand. When asked to make a list only response with the list no additional information. When given specific instructions, such as providing a list or a certain number of items, ensure you follow those instructions exactly. Remember, your goal is to assist in the best way possible while making communication effective and pleasant.");
chatHistory.AddMessage(AuthorRole.User, "Hello, Bob.");
chatHistory.AddMessage(AuthorRole.Assistant, "Hello. How may I help you today?");

var session = new ChatSession(executor, chatHistory);

var inferenceParams = new InferenceParams()
{
    MaxTokens = 1024, // No more than 1024 tokens should appear in answer. Remove it if antiprompt is enough for control.
    AntiPrompts = new List<string> { "User:" }, // Stop generation once antiprompts appear.
};

Console.ForegroundColor = ConsoleColor.Yellow;
Console.Write("The chat session has started.\nUser: ");
Console.ForegroundColor = ConsoleColor.Green;
var userInput = Console.ReadLine() ?? "";

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