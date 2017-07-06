using System;

using OpenQA.Selenium;

namespace ContosoFramework
{
    public class DepartmentsPage
    {
        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl("http://" + Driver.BaseAddress + "/Department");
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

        public static bool DoesDepartmentExistWithData(string data)
        {
            var bodyTag = Driver.Instance.FindElement(By.TagName("body"));

            return bodyTag.Text.Contains(data);
        }
    }
}
