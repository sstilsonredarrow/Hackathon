﻿using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace XCountryTimer.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            try
            {
                UIApplication.Main(args, null, "AppDelegate");
            }
            catch (System.Exception ex)
            {
                string s = ex.InnerException.InnerException.Message;
            }
            // you can specify it here.

        }
    }
}
