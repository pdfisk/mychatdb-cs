using MyChatDB.iron_python.engine;
using Newtonsoft.Json;
using OpenAI;
using OpenAI.Chat;
using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Net.Http;

namespace src.chatgpt
{
    public class LMStudioClient
    {
        string model = "qwen/qwen3-coder-30b";
        string baseUrl = "http://127.0.0.1:1234/v1";
        string apiKey = "not_needed_for_lmstudio";
        ChatClient chatClient;

        public LMStudioClient()
        {
            chatClient = new ChatClient(model, new ApiKeyCredential(apiKey), new OpenAIClientOptions
            {
                Endpoint = new Uri(baseUrl)
            });
        }

        void PrintLn(IResultHandler handler, params object[] args)
        {
            if (handler == null) return;
            var time_now = DateTime.Now;
            var minutes = time_now.Minute.ToString("D2");
            var seconds = time_now.Second.ToString("D2");
            var text = string.Format("[{0}:{1}] ", minutes, seconds);
            for (var i = 0; i < args.Length; i++)
            {
                text += args[i].ToString();
                if (i < args.Length - 1)
                    text += " ";
            }
            handler.PrintLn(text);
        }

        async public void sendMessage(string message, IResultHandler handler = null)
        {

            PrintLn(handler, "sending...");
            var chatMessage = new UserChatMessage(message);
            string result = "unknown";
            var chatMessages = new List<ChatMessage>
            {
                new UserChatMessage(message)
            };
            try
            {
                var response = await chatClient.CompleteChatAsync(chatMessages);
                result = response.Value.Content[0].Text;
            }
            catch (Exception ex)
            {
                result = $"Error: {ex.Message}";
                PrintLn(handler, "ERROR", result);
                return;
            }
            if (handler != null)
            {
                //ResultObject resultObject = new ResultObject(result, result, result);
                //handler.HandleResult(resultObject);
                PrintLn(handler, result);
            }
            else
            {
                Console.WriteLine(result);
            }
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
