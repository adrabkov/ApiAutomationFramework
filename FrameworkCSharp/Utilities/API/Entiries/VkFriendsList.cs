using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkCSharp.Utilities.API.Entiries
{
    public class Item
    {
        public string name { get; set; }
        public int id { get; set; }
    }

    public class FriendListResponse
    {
        public int count { get; set; }
        public List<Item> items { get; set; }
    }

    public class RootList
    {
        public FriendListResponse FriendListResponse { get; set; }
    }
}
