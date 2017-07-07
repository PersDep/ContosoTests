using System;

using OpenQA.Selenium;

namespace ContosoFramework
{
    public class EditStudentPage
    {
        public static void GoTo()
        {
            Page.GoTo("/Student");

            Driver.Instance.FindElement(By.LinkText("Edit")).Click();
        }

        public static EditStudentCommand EditStudent(string name)
        {
            return new EditStudentCommand(name);
        }

        public class EditStudentCommand
        {
            private readonly string _name;
            private string _FirstName;
            private DateTime _startDate;

            public EditStudentCommand(string name)
            {
                _name = name;
            }

            public EditStudentCommand WithFirstName(string FirstName)
            {
                _FirstName = FirstName;
                return this;
            }

            public EditStudentCommand WithStartDate(DateTime startDate)
            {
                _startDate = startDate;
                return this;
            }

            public void Create()
            {
                string format = @"dd\/MM\/yyyy";

                Driver.Instance.FindElement(By.Id("LastName")).Clear();
                Driver.Instance.FindElement(By.Id("LastName")).SendKeys(_name);
                Driver.Instance.FindElement(By.Id("FirstMidName")).Clear();
                Driver.Instance.FindElement(By.Id("FirstMidName")).SendKeys(_FirstName);
                Driver.Instance.FindElement(By.Id("EnrollmentDate")).Clear();
                Driver.Instance.FindElement(By.Id("EnrollmentDate")).SendKeys(_startDate.ToString(format));

                Driver.Instance.FindElement(By.XPath("//input[@value='Save']")).Click();
            }
        }
    }
}
