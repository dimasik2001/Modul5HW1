using System;
using System.Threading.Tasks;
using Modul5HW1.Models;
using Newtonsoft.Json;

namespace Modul5HW1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var userClient = new UserClient();
            var getUserList = await userClient.GetListUsersAsync();
            var getSingleUser = await userClient.GetUserAsync(3);
            var getSingleUserNotFound = await userClient.GetUserAsync(30);
            var getResourceList = await userClient.GetResourceListAsync();
            var getSingleResource = await userClient.GetResourceAsync(6);
            var getSingleResourceNotFound = await userClient.GetResourceAsync(50);
            var postCreate = await userClient.PostCreateAsync(new { name = "morpheus", job = "leader" });
            var putUpdate = await userClient.PutUpdateAsync(new { name = "mike", job = "worker" }, 2);
            var patchUpdate = await userClient.PatchUpdateAsync(new { name = "mike", job = "worker" }, 2);
            var postRegisterSuccessful = await userClient.PostRegisterAsync(new { email = "eve.holt@reqres.in", password = "pistol" });
            var postRegisterUnsuccessful = await userClient.PostRegisterAsync(new { email = "sydney@fife" });
            var posrLoginSuccessful = await userClient.PostLoginAsync(new { email = "eve.holt@reqres.in", password = "cityslicka" });
            var posrLoginUnsuccessful = await userClient.PostLoginAsync(new { email = "peter@klaven" });
            var delayGetList = await userClient.HttpGetRequestAsync<ListItems<User>>("api/users?delay=3");
        }
    }
}
