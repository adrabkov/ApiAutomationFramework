using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace FrameworkCSharp.Enum
{
    public enum SettingMenuItems : int
    {
        [Description("General")]
        General = 1,
        [Description("Security")]
        Security = 2,
        [Description("Privacy ")]
        Privacy = 3,
        [Description("Notifications ")]
        Notifications = 4,
        [Description("Blockede")]
        Blocked = 5,
        [Description("App settings")]
        App_settings = 6,
        [Description("Payments and subscriptions")]
        Payments_and_subscriptions = 7
    }
}
