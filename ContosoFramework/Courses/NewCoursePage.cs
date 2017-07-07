using System;

using OpenQA.Selenium;

namespace ContosoFramework
{
    public class NewCoursePage
    {
        public static void GoTo()
        {
            Page.GoTo("/Course");

            Driver.Instance.FindElement(By.LinkText("Create New")).Click();
        }

        private static CreateCourseCommand CreateCourse(decimal n)
        {
            return new CreateCourseCommand(n);
        }

        private class CreateCourseCommand
        {
            private readonly decimal _n;
            private string _title;
            private decimal _cred;
            private string _dep;

            public CreateCourseCommand(decimal n)
            {
                _n = n;
            }

            public CreateCourseCommand WithTitle(string title)
            {
                _title = title;
                return this;
            }

            public CreateCourseCommand WithCredits(decimal cred)
            {
                _cred = cred;
                return this;
            }

            public CreateCourseCommand WithDepartment(string dep)
            {
                _dep = dep;
                return this;
            }

            public void Create()
            {
                Driver.Instance.FindElement(By.Id("CourseID")).SendKeys(_n.ToString());
                Driver.Instance.FindElement(By.Id("Title")).SendKeys(_title);
                Driver.Instance.FindElement(By.Id("Credits")).SendKeys(_cred.ToString());
                Driver.Instance.FindElement(By.Id("DepartmentID")).SendKeys(_dep);

                Driver.Instance.FindElement(By.XPath("//input[@value='Create']")).Click();
            }
        }

        public static void CreateCourse(decimal n, string title, decimal cred, string dep)
        {
            GoTo();
            CreateCourse(n)
                .WithTitle(title)
                .WithCredits(cred)
                .WithDepartment(dep)
                .Create();
        }
    }
}
