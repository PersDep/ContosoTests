using OpenQA.Selenium;

namespace ContosoFramework
{
    public class SearchStudentsPage
    {
        public static void GoTo(string query)
        {
            Page.GoTo("/Student");

            Driver.Instance.FindElement(By.Name("SearchString")).SendKeys(query);
            Driver.Instance.FindElement(By.XPath("//input[@value='Search']")).Click();
        }
    }
}
