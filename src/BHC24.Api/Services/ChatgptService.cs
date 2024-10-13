using System.Net.Mime;
using System.Text;
using Serilog.Events;
using Standard.AI.OpenAI.Clients.OpenAIs;
using Standard.AI.OpenAI.Models.Configurations;
using Standard.AI.OpenAI.Models.Services.Foundations.ChatCompletions;
using Standard.AI.OpenAI.Models.Services.Foundations.Completions;

namespace BHC24.Api.Services;

public class ChatgptService
{
    
    private OpenAIClient chatgptClient;
    
    public ChatgptService()
    {
        init();
    }

    public async Task<string> GenerateChatResponse(string userMessage)
    {
        // Construct chat-based completion request
        var chatCompletion = new ChatCompletion
        {
            Request = new ChatCompletionRequest
            {
                Model = "gpt-4", 
                
                Messages = new ChatCompletionMessage[] 
                {
                    new ChatCompletionMessage
                    {
                        Role = "system",
                        Content = userMessage
                    }
                }
            }
        };
        
        // Send request to OpenAI's chat completion endpoint
        ChatCompletion resultCompletion = await chatgptClient.ChatCompletions.SendChatCompletionAsync(chatCompletion);

        // Capture all messages in the response
        var fullResponse = new StringBuilder();

        foreach (var choice in resultCompletion.Response.Choices)
        {
            fullResponse.AppendLine(choice.Message.Content);
        }

        // Return the full chat response
        return fullResponse.ToString();
    }

    private void init()
    {
        var chatgptConfiguration = new OpenAIConfigurations
        {
            ApiKey = "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",
            OrganizationId ="org-HEMkhE2id2uaM2lOTfLaWNKt"
        };
        
        chatgptClient = new OpenAIClient(chatgptConfiguration);

    }
}