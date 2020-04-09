using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkCSharp.Utilities.API.Entiries
{
    public class DeleteFriendsResponse
    {
        public int success { get; set; }
        public int out_request_deleted { get; set; }
    }

    public class DeleteFriendsObject
    {
        public DeleteFriendsResponse deleteFriendsResponse { get; set; }
    }
}
