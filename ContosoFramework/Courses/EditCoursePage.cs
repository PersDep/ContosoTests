using OpenQA.Selenium;

namespace ContosoFramework
{
    public class EditCoursePage
    {
        public static void GoTo()
        {
            Page.GoTo("/Course");

            Driver.Instance.FindElement(By.LinkText("Edit")).Click();
        }

        public static EditCourseCommand EditCourse(decimal n)
        {
            return new EditCourseCommand(n);
        }

        public class EditCourseCommand
        {
            private readonly decimal _n;
            private string _title;
            private decimal _cred;
            private string _dep;

            public EditCourseCommand(decimal n)
            {
                _n = n;
            }

            public EditCourseCommand WithTitle(string title)
            {
                _title = title;
                return this;
            }

            public EditCourseCommand WithCredits(decimal cred)
            {
                _cred = cred;
                return this;
            }

            public EditCourseCommand WithDepartment(string dep)
            {
                _dep = dep;
                return this;
            }

            public void Create()
            {
                Driver.Instance.FindElement(By.Id("Title")).Clear();
                Driver.Instance.FindElement(By.Id("Title")).SendKeys(_title);
                Driver.Instance.FindElement(By.Id("Credits")).Clear();
                Driver.Instance.FindElement(By.Id("Credits")).SendKeys(_cred.ToString());
                Driver.Instance.FindElement(By.Id("DepartmentID")).SendKeys(_dep);

                Driver.Instance.FindElement(By.XPath("//input[@value='Save']")).Click();
            }
        }
    }
}
