using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkCSharp.Utilities.API.Entiries
{
    public class CommentResponse
    {
        [JsonProperty("comment_id")]
        public int comment_id { get; set; }

        [JsonProperty("parents_stack")]
        public List<object> parents_stack { get; set; }
    }

    public class RootComment
    {
        public CommentResponse commentResponse { get; set; }
    }
}
