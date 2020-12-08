using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FrameworkCSharp.Enum
{
    public enum MenuItems : int
    {
        [Description("My profile")]
        My_profile = 0,
        [Description("News")]
        News = 1,
        [Description("Messages")]
        Messages = 2,
        [Description("Friends")]
        Friends = 3,
        [Description("Communities")]
        Communities = 4,
        [Description("Photos")]
        Photos = 5,
        [Description("Music")]
        Music = 6,
        [Description("Videos")]
        Videos = 7,
        [Description("Games")]
        Games = 8
    }
}
