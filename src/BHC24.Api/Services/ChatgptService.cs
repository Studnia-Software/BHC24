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