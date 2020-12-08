using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FrameworkCSharp.Enum
{
    public enum TopProfileItems : int
    {
        [Description("My profile")]
        My_profile = 0,
        [Description("Edit")]
        Edit = 1,
        [Description("Settings")]
        Settings = 2,
        [Description("Help")]
        Help = 3,
        [Description("Log out")]
        Log_out = 4
    }
}
