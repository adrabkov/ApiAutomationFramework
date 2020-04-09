using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkCSharp.Utilities.API.Entiries
{
    public class WallPostResponse
    {
        public int post_id { get; set; }
    }

    public class RootObject
    {
        public WallPostResponse wallPostResponse { get; set; }
    }
}
