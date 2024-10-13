using System.Net.Mime;
using System.Text;
using BHC24.Api.TempStorage;
using Serilog.Events;
using Standard.AI.OpenAI.Clients.OpenAIs;
using Standard.AI.OpenAI.Models.Configurations;
using Standard.AI.OpenAI.Models.Services.Foundations.ChatCompletions;
using Standard.AI.OpenAI.Models.Services.Foundations.Completions;

namespace BHC24.Api.Services;

public class ChatgptService
{
    
    private OpenAIClient chatgptClient;
    private readonly CommitListStorage _commitListStorage;
    
    public ChatgptService(CommitListStorage commitListStorage)
    {
        _commitListStorage = commitListStorage;
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
                },
                MaxTokens = 500 
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
    
    public async Task<string> AnalyzeCommit(string GithubRepositoryUrl)
    {
        var commits = _commitListStorage.Commits;

        var commitMsg = "";
        int counter = 1;
        foreach (var commit in commits)
        {
            commitMsg +=
                "Commit: " + counter + "/" + commits.Count() + "\n" + 
                "CommitMessage =" + commit.CommitMessage + "\n" +
                "CommitAuthor =   "  + commit.CommitAuthorName + "\n" +
                "commitUrl =" + commit.Url  + "\n";
            counter++;
        }

        commitMsg +=
            "\n Przeanalizuj te commity i napisz o nich podsumowanie co w nich zostało zmienione i kto to zrobił";
        
        var chatMSG = await GenerateChatResponse(commitMsg);
        
        
        Console.WriteLine(commitMsg);
        Console.WriteLine(chatMSG.ToString());
        
        return chatMSG.ToString();
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