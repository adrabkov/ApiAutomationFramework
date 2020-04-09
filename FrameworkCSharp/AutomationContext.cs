using FrameworkCSharp.Pages;
using FrameworkCSharp.Steps;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkCSharp
{
    public class AutomationContext:BaseTest
    {
        public CommonSteps Common { get { return _common ?? (_common = new CommonSteps(Navigate<SignInPage>(), driver)); } }

        private CommonSteps _common;

        public AutomationContext(object context = null)
        {
        }
    }
}
