using OpenQA.Selenium;

namespace ContosoFramework
{
    public class DeleteDepartmentsPage
    {
        public static void GoTo()
        {
            DepartmentsPage.GoTo();
        }

        public static void DeleteDepartmentsCommand()
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
        public static bool DoDepartmentsExist()
        {
            var bodyTag = Driver.Instance.FindElement(By.TagName("body"));

            return bodyTag.Text.Contains("Delete");
        }
    }
}
