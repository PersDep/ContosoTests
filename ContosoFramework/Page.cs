using System;

using OpenQA.Selenium;

namespace ContosoFramework
{
    public class Page
    {
        public static void GoTo(string name)
        {
            Driver.Instance.Navigate().GoToUrl("http://" + Driver.BaseAddress + name);
        }

        public static string Name
        {
            get
            {
                var title = Driver.Instance.FindElement(By.TagName("h2"));
                if (title != null)
                    return title.Text;
                return String.Empty;
            }
        }

        public static bool DoesElementExistWithData(string data)
        {
            var bodyTag = Driver.Instance.FindElement(By.TagName("body"));

            return bodyTag.Text.Contains(data);
        }
    }
}
