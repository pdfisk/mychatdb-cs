using MyChatDB.iron_python.engine;
using OpenAI;
using OpenAI.Chat;
using System;
using System.ClientModel;
using System.Runtime.InteropServices;

namespace src.chatgpt
{
    public class LMStudioClient 
    {
        string model = "qwen/qwen3-coder-30b";
        string serverUrl = "http://127.0.0.1:1234/v1";
        string apiKey = "not_needed_for_lmstudio";
        OpenAIClient client;
        ChatClient chatClient;

        public LMStudioClient()
        {
            client = new OpenAIClient(new ApiKeyCredential(apiKey), new OpenAIClientOptions
            {
                Endpoint = new Uri(serverUrl)
            });
            chatClient = client.GetChatClient(model);
        }

        async public void sendMessage(string message, IResultHandler handler=null)
        {
            var chatMessage = new UserChatMessage(message);
            var response = await chatClient.CompleteChatAsync(chatMessage);
            var result = response.Value.Content[0].Text;
            if (handler != null)
            {
                ResultObject resultObject = new ResultObject
                (result,result,result
                );
                handler.HandleResult(resultObject);
            }
            else
                Console.WriteLine(response.Value.Content[0].Text);
        }

    }
}
