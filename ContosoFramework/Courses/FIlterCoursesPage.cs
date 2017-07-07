using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ContosoFramework
{
    public class FIlterCoursesPage
    {
        public static void GoTo(string selectedDep)
        {
            Page.GoTo("/Course");

            SelectElement dropdown = new SelectElement(Driver.Instance.FindElement(By.Id("SelectedDepartment")));
            dropdown.SelectByText(selectedDep);
            Driver.Instance.FindElement(By.XPath("//input[@value='Filter']")).Click();
        }


    }
}
