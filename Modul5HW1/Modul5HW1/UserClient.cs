using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Modul5HW1.Models;
using Newtonsoft.Json;

namespace Modul5HW1
{
    public class UserClient
    {
        private const string _controllerPath = "https://reqres.in";
        private HttpClient _httpClient;
        public UserClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<ListItemsResponse<User>> GetListUsersAsync()
        {
            return await HttpGetRequestAsync<ListItemsResponse<User>>("api/users");
        }

        public async Task<SingleItemResponse<User>> GetUserAsync(int id)
        {
            return await HttpGetRequestAsync<SingleItemResponse<User>>($"api/users/{id}");
        }

        public async Task<ListItemsResponse<Resource>> GetResourceListAsync()
        {
            return await HttpGetRequestAsync<ListItemsResponse<Resource>>($"api/unknown");
        }

        public async Task<SingleItemResponse<Resource>> GetResourceAsync(int id)
        {
            return await HttpGetRequestAsync<SingleItemResponse<Resource>>($"api/unknown/{id}");
        }

        public async Task<CreateResponse> PostCreateAsync(object obj)
        {
            var content = JsonConvert.SerializeObject(obj);
            return await HttpPostRequestAsync<CreateResponse>($"api/users", content);
        }

        public async Task<UpdateResponse> PutUpdateAsync(object obj, int id)
        {
            var content = JsonConvert.SerializeObject(obj);
            return await HttpPutRequestAsync<UpdateResponse>($"api/users/{id}", content);
        }

        public async Task<UpdateResponse> PatchUpdateAsync(object obj, int id)
        {
            var content = JsonConvert.SerializeObject(obj);
            return await HttpPatchRequestAsync<UpdateResponse>($"api/user/{id}", content);
        }

        public async Task<RegisterResponse> PostRegisterAsync(object obj)
        {
            var content = JsonConvert.SerializeObject(obj);
            return await HttpPostRequestAsync<RegisterResponse>($"api/register", content);
        }

        public async Task<LoginResponse> PostLoginAsync(object obj)
        {
            var content = JsonConvert.SerializeObject(obj);
            return await HttpPostRequestAsync<LoginResponse>($"api/login", content);
        }

        public async Task<TResponse> HttpGetRequestAsync<TResponse>(string route)
        {
            return await HttpRequestAsync<TResponse>(CreateGetMessage(route));
        }

        public async Task<TResponse> HttpPostRequestAsync<TResponse>(string route, string content)
        {
            return await HttpRequestAsync<TResponse>(CreatePostMessage(route, content));
        }

        public async Task<TResponse> HttpPutRequestAsync<TResponse>(string route, string content)
        {
            return await HttpRequestAsync<TResponse>(CreatePutMessage(route, content));
        }

        public async Task<TResponse> HttpPatchRequestAsync<TResponse>(string route, string content)
        {
            return await HttpRequestAsync<TResponse>(CreatePatchMessage(route, content));
        }

        public async Task<TResponse> HttpDeleteRequestAsync<TResponse>(string route)
        {
            return await HttpRequestAsync<TResponse>(CreateDeleteMessage(route));
        }

        public async Task<TResponse> HttpRequestAsync<TResponse>(HttpRequestMessage message)
        {
            var response = await _httpClient.SendAsync(message);
            var data = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TResponse>(data);
            return result;
        }

        private HttpRequestMessage CreatePostMessage(string route, string content)
        {
            var message = CreateMessage(route, HttpMethod.Post, new StringContent(content));
            return message;
        }

        private HttpRequestMessage CreatePutMessage(string route, string content)
        {
            var message = CreateMessage(route, HttpMethod.Put, new StringContent(content));
            return message;
        }

        private HttpRequestMessage CreatePatchMessage(string route, string content)
        {
            var message = CreateMessage(route, HttpMethod.Patch, new StringContent(content));
            return message;
        }

        private HttpRequestMessage CreateDeleteMessage(string route)
        {
            var message = CreateMessage(route, HttpMethod.Delete);
            return message;
        }

        private HttpRequestMessage CreateGetMessage(string route)
        {
            var message = CreateMessage(route, HttpMethod.Get);
            return message;
        }

        private HttpRequestMessage CreateMessage(string route, HttpMethod methodType, StringContent content = null)
        {
            var message = new HttpRequestMessage();
            message.Method = methodType;
            message.RequestUri = new Uri($"{_controllerPath}/{route}");
            message.Content = content;
            return message;
        }
    }
}
