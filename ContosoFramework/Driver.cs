﻿using System;
using System.Threading;

using OpenQA.Selenium;
using OpenQA.Selenium.IE;

namespace ContosoFramework
{
    public class Driver
    {
        public static IWebDriver Instance { get; set; }

        public static string BaseAddress
        {
            get
            {
                var url = "ALMWEB01/CU-DAT";

                #if DEBUG
                    url = "localhost:41787";
                #endif

                return url;
            }
        }

        public static void Initialize()
        {
            Instance = new InternetExplorerDriver();
            TurnOnWait();
        }

        public static void Close()
        {
            Instance.Close();
        }

        public static void Wait(TimeSpan timeSpan)
        {
            Thread.Sleep((int)(timeSpan.TotalSeconds * 1000));
        }

        public static void NoWait(Action action)
        {
            TurnOffWait();
            action();
            TurnOnWait();
        }

        private static void TurnOnWait()
        {
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
        }

        private static void TurnOffWait()
        {
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(0));
        }
    }
}