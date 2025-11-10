using MyChatDB.iron_python.engine;
using Newtonsoft.Json;
using OpenAI;
using OpenAI.Chat;
using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Net.Http;
using static IronPython.Modules._ast;

namespace src.chatgpt
{
    public class LMStudioClient
    {
        string model = "qwen/qwen3-coder-30b";
        string baseUrl = "http://127.0.0.1:1234/v1";
        string apiKey = "not_needed_for_lmstudio";
        OpenAIClient client;
        ChatClient chatClient;

        public LMStudioClient()
        {
            client = new OpenAIClient(new ApiKeyCredential(apiKey), new OpenAIClientOptions
            {
                Endpoint = new Uri(baseUrl)
            });
            chatClient = client.GetChatClient(model);
        }

        async public void sendMessage(string message, IResultHandler handler = null)
        {
            var chatMessage = new UserChatMessage(message);
            var response = await chatClient.CompleteChatAsync(chatMessage);
            var result = response.Value.Content[0].Text;
            if (handler != null)
            {
                ResultObject resultObject = new ResultObject
                (result, result, result
                );
                handler.HandleResult(resultObject);
            }
            else
                Console.WriteLine(response.Value.Content[0].Text);
        }

        async public void getModels(IResultHandler handler = null)
        {
            var url = baseUrl + "/models";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error fetching models: {response.StatusCode}");
            }

            var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            var result = JsonConvert.DeserializeObject(json);
            var text = JsonConvert.SerializeObject(result, Formatting.Indented);
            if (handler != null)
            {
                handler.HandleResult(new ResultObject(text, text, text));
            }
            else
            {
                Console.WriteLine(text);
            }
        }

    }
}
