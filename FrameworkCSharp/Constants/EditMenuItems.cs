using System.ComponentModel;

namespace FrameworkCSharp.Enum
{
    public enum EditMenuItems : int
    {
        [Description("Contact info")]
        Contact_info = 2,
        [Description("Interests")]
        Interests = 3,
        [Description("Education")]
        Education = 4,
        [Description("Work")]
        Work = 5,
        [Description("Military service")]
        Military_service = 6,
        [Description("Personal views")]
        Personal_views = 7
    }
}
