using FrameworkCSharp.Enum;
using FrameworkCSharp.Utilities.API.Entiries;
using Newtonsoft.Json;
using RestSharp;
using System;

namespace FrameworkCSharp.Utilities.API.Requests
{
    public class ApiRequests : ApiUtilities
    {

        protected string serverAccessToken = VK_GetServerToken(CustomerData.appId, CustomerData.SecureKey);

        private static string VK_GetServerToken(string client_id, string client_secret)
        {
            string response = GetRequest("oauth.vk.com", "https://oauth.vk.com/access_token?client_id=" + client_id + "&client_secret=" + client_secret + "&v=5.85&grant_type=client_credentials");
            dynamic stringResponse = JsonConvert.DeserializeObject(response);
            return stringResponse.access_token;
        }

        public CommentResponse CreateCommentForPost(string token, string postId, string message)
        {
            var request = CreateRequest(token, Method.GET, ApiMethods.createCommentForPost);
            request.Item1.AddParameter("post_id", postId);
            request.Item1.AddParameter("message", message);
            return ResponseConverter<CommentResponse>(request.Item2, request.Item1);
        }

        public WallPostResponse WallPost(string token, string message)
        {
            var request = CreateRequest(token, Method.POST, ApiMethods.wallPost);
            request.Item1.AddParameter("message", message);
            return ResponseConverter<WallPostResponse>(request.Item2, request.Item1);
        }

        public string DeletePost(string token, string postId)
        {
            var request = CreateRequest(token, Method.GET, ApiMethods.deletePost);
            request.Item1.AddParameter("post_id", postId);
            return GetResponce(request.Item2, request.Item1);
        }

        public FriendListResponse getFriendList(String token)
        {
            var request = CreateRequest(token, Method.GET, ApiMethods.friendsGetLists);
            request.Item1.AddParameter("user_id", "17771962");
            return ResponseConverter<FriendListResponse>(request.Item2, request.Item1);
        }

        public string GetUserNameById(String token, int userId)
        {
            var request = CreateRequest(token, Method.GET, ApiMethods.usersGet);
            request.Item1.AddParameter("user_ids", userId);
            request.Item1.AddParameter("fields", "bdate");
            return ResponseConverter(request.Item2, request.Item1, "first_name");
        }

        public string AddFriends(String token, int userId)
        {
            var request = CreateRequest(token, Method.GET, ApiMethods.addFriends);
            request.Item1.AddParameter("user_ids", userId);
            return GetResponce(request.Item2, request.Item1);
        }

        public DeleteFriendsResponse DeleteFriend(String token, int user_id)
        {
            var request = CreateRequest(token, Method.GET, ApiMethods.addFriends);
            request.Item1.AddParameter("user_id", user_id);
            return ResponseConverter<DeleteFriendsResponse>(request.Item2, request.Item1);
        }
    }
}
