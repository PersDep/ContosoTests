using OpenQA.Selenium;

namespace ContosoFramework
{
    public class DeleteElementsPage
    {
        public static void GoTo(string name)
        {
            Page.GoTo(name);
        }

        public static void DeleteElementsCommand()
        {
            while (true)
            {
                try
                {
                    Driver.Instance.FindElement(By.LinkText("Delete")).Click();
                    Driver.Instance.FindElement(By.XPath("//input[@value='Delete']")).Click();
                }
                catch
                {
                    break;
                }
            }
        }
        
        public static bool DoElementsExist()
        {
            var bodyTag = Driver.Instance.FindElement(By.TagName("body"));

            return bodyTag.Text.Contains("Delete");
        }
    }
}
