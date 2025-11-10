using OpenAI;
using OpenAI.Chat;
using System;
using System.ClientModel;
using System.Collections.Generic;

namespace MyChatDB.api
{

    public class OpenAIChatService
    {

        async public void sendMessage(string text)
        {
            string BaseUrl = "http://127.0.0.1:1234/v1";
            string ModelName = "qwen/qwen3-coder-30b";
            ChatClient client = new ChatClient(
            model: ModelName,
            credential: new ApiKeyCredential("abc_xyz"),
            options: new OpenAIClientOptions() { Endpoint = new Uri(BaseUrl) });


            var messages = new List<ChatMessage> { };
            messages.Add(new UserChatMessage(text));
            Console.WriteLine(messages[0].Content[0].Text);
            ChatCompletion completion = await client.CompleteChatAsync(messages);
            var response = completion.Content[0].Text;
            messages.Add(new AssistantChatMessage(response));

            Console.WriteLine(response);

        }

    }
}
