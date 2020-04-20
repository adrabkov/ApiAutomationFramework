using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FrameworkCSharp.Enum
{
    public enum MenuItems : byte
    {
        [Description("My profile")]
        My_profile = 1,
        [Description("News")]
        News = 2,
        [Description("Messages")]
        Messages = 3,
        [Description("Friends")]
        Friends = 4,
        [Description("Communities")]
        Communities = 5,
        [Description("Photos")]
        Photos = 6,
        [Description("Music")]
        Music = 7,
        [Description("Videos")]
        Videos = 8,
        [Description("Games")]
        Games = 9
    }
}
