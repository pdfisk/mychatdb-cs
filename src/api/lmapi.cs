using MyChatDB.iron_python.engine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace api
{
    public class LmApi
    {
        static LmApi _instance;

        private readonly HttpClient _httpClient;
        public string BaseUrl { get; set; } = "http://127.0.0.1:1234/v1";
        public string ApiKey { get; set; }

        public static LmApi Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LmApi();
                }
                return _instance;
            }
        }

        public LmApi(HttpClient httpClient = null)
        {
            _httpClient = httpClient ?? new HttpClient();
            _httpClient.Timeout = TimeSpan.FromMinutes(5);
        }

        private void SetAuthHeader()
        {
            if (!string.IsNullOrEmpty(ApiKey))
            {
                if (_httpClient.DefaultRequestHeaders.Contains("Authorization"))
                    _httpClient.DefaultRequestHeaders.Remove("Authorization");

                _httpClient.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", ApiKey));
            }
        }

        public async Task<string> ChatAsync(string prompt, string model = "qwen/qwen3-coder-30b", double temperature = 0.7)
        {
            SetAuthHeader();
            var endpoint = string.Format("{0}/chat/completions", BaseUrl.TrimEnd('/'));

            var payload = new
            {
                model = model,
                messages = new[] { new { role = "user", content = prompt } },
                temperature = temperature
            };

            var json = JsonConvert.SerializeObject(payload);
            using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
            using (var response = await _httpClient.PostAsync(endpoint, content))
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                    throw new Exception(string.Format("Error {0}: {1}", response.StatusCode, responseJson));

                var obj = JObject.Parse(responseJson);
                var choices = obj["choices"] as JArray;
                if (choices != null && choices.Count > 0)
                {
                    var message = choices[0]["message"];
                    if (message != null && message["content"] != null)
                        return message["content"].ToString();
                }
                return responseJson;
            }
        }

        public async Task StreamChatAsync(string model, string prompt, Action<string> onToken, double temperature = 0.7)
        {
            SetAuthHeader();
            var endpoint = string.Format("{0}/chat/completions", BaseUrl.TrimEnd('/'));

            var payload = new
            {
                model = model,
                messages = new[] { new { role = "user", content = prompt } },
                stream = true,
                temperature = temperature
            };

            var json = JsonConvert.SerializeObject(payload);
            var request = new HttpRequestMessage(HttpMethod.Post, endpoint)
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            using (var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();

                using (var stream = await response.Content.ReadAsStreamAsync())
                using (var reader = new StreamReader(stream))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = await reader.ReadLineAsync();
                        if (string.IsNullOrWhiteSpace(line)) continue;

                        if (line.StartsWith("data: "))
                            line = line.Substring(6);

                        if (line == "[DONE]") break;

                        try
                        {
                            var data = JObject.Parse(line);
                            var delta = data["choices"]?[0]?["delta"];
                            if (delta != null && delta["content"] != null)
                            {
                                var token = delta["content"].ToString();
                                if (!string.IsNullOrEmpty(token))
                                    onToken(token);
                            }
                        }
                        catch
                        {
                            onToken(line + "\n");
                        }
                    }
                }
            }
        }

        public async Task<float[]> GetEmbeddingsAsync(string model, string input)
        {
            SetAuthHeader();
            var endpoint = string.Format("{0}/embeddings", BaseUrl.TrimEnd('/'));
            var payload = new { model = model, input = input };

            var json = JsonConvert.SerializeObject(payload);
            using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
            using (var response = await _httpClient.PostAsync(endpoint, content))
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                    throw new Exception(string.Format("Error {0}: {1}", response.StatusCode, responseJson));

                var obj = JObject.Parse(responseJson);
                var embeddingArray = obj["data"]?[0]?["embedding"] as JArray;
                if (embeddingArray != null)
                {
                    var list = new List<float>();
                    foreach (var v in embeddingArray)
                        list.Add(v.Value<float>());
                    return list.ToArray();
                }
                return null;
            }
        }

        public async Task<T> RequestStructuredJsonAsync<T>(string model, string prompt, object jsonSchema, double temperature = 0.2)
        {
            SetAuthHeader();
            var endpoint = string.Format("{0}/responses", BaseUrl.TrimEnd('/'));

            var payload = new
            {
                model = model,
                input = prompt,
                temperature = temperature,
                response_format = new
                {
                    type = "json_schema",
                    json_schema = new
                    {
                        name = typeof(T).Name.ToLowerInvariant(),
                        schema = jsonSchema
                    }
                }
            };

            var json = JsonConvert.SerializeObject(payload);
            using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
            using (var response = await _httpClient.PostAsync(endpoint, content))
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                    throw new Exception(string.Format("Error {0}: {1}", response.StatusCode, responseJson));

                var obj = JObject.Parse(responseJson);
                var parsed = obj["output_parsed"];
                if (parsed != null)
                    return JsonConvert.DeserializeObject<T>(parsed.ToString());

                return default(T);
            }
        }

        public async Task<string> CallFunctionAsync(string model, string prompt, Dictionary<string, object> functionSpec)
        {
            SetAuthHeader();
            var endpoint = string.Format("{0}/chat/completions", BaseUrl.TrimEnd('/'));

            var payload = new
            {
                model = model,
                messages = new[] { new { role = "user", content = prompt } },
                functions = new[] { functionSpec }
            };

            var json = JsonConvert.SerializeObject(payload);
            using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
            using (var response = await _httpClient.PostAsync(endpoint, content))
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                    throw new Exception(string.Format("Error {0}: {1}", response.StatusCode, responseJson));

                return responseJson;
            }
        }

        public static object GenerateJsonSchemaFromType(Type type)
        {
            var properties = new Dictionary<string, object>();
            foreach (var prop in type.GetProperties())
            {
                string propType = "string";
                if (prop.PropertyType == typeof(int) || prop.PropertyType == typeof(long)) propType = "integer";
                else if (prop.PropertyType == typeof(float) || prop.PropertyType == typeof(double) || prop.PropertyType == typeof(decimal)) propType = "number";
                else if (prop.PropertyType == typeof(bool)) propType = "boolean";

                properties[prop.Name] = new { type = propType };
            }

            return new
            {
                type = "object",
                properties = properties,
                required = new List<string>(properties.Keys)
            };
        }


        public async void GetModels(IResultHandler resultHandler = null)
        {
            var endpoint = string.Format("{0}/models", BaseUrl.TrimEnd('/'));
            var request = new HttpRequestMessage(HttpMethod.Get, endpoint)
            {
            };
            using (var response = await _httpClient.GetAsync(endpoint))
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                    throw new Exception(string.Format("Error {0}: {1}", response.StatusCode, responseJson));
                if (resultHandler != null)
                {
                    resultHandler.HandleResult(new ResultObject(responseJson, responseJson, ""));
                }
            }

        }

    }

}
