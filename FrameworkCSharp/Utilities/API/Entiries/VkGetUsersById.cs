using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkCSharp.Utilities.API.Entiries
{
    public class City
    {
        public int id { get; set; }
        public string title { get; set; }
    }

    public class UsersResponse
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public bool is_closed { get; set; }
        public bool can_access_closed { get; set; }
        public City city { get; set; }
        public string photo_50 { get; set; }
        public int verified { get; set; }
    }

    public class UsersObject
    {
        public List<UsersResponse> UsersResponse { get; set; }
    }
}
