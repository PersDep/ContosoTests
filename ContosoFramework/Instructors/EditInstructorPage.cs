using System;

using OpenQA.Selenium;

namespace ContosoFramework
{
    public class EditInstructorPage
    {
        public static void GoTo()
        {
            Page.GoTo("/Instructor");

            Driver.Instance.FindElement(By.LinkText("Edit")).Click();
        }

        public static EditInstructorCommand EditInstructor(string name)
        {
            return new EditInstructorCommand(name);
        }

        public class EditInstructorCommand
        {
            private readonly string LastName;
            private string FirstName;
            private DateTime _startDate;
            private string _location;

            public EditInstructorCommand(string name)
            {
                LastName = name;
            }

            public EditInstructorCommand WithName(string name)
            {
                FirstName = name;
                return this;
            }

            public EditInstructorCommand WithStartDate(DateTime startDate)
            {
                _startDate = startDate;
                return this;
            }

            public EditInstructorCommand WithLocation(string location)
            {
                _location = location;
                return this;
            }

            public void Create()
            {
                string format = @"dd\/MM\/yyyy";

                Driver.Instance.FindElement(By.Id("LastName")).Clear();
                Driver.Instance.FindElement(By.Id("LastName")).SendKeys(LastName);
                Driver.Instance.FindElement(By.Id("FirstMidName")).Clear();
                Driver.Instance.FindElement(By.Id("FirstMidName")).SendKeys(FirstName);
                Driver.Instance.FindElement(By.Id("HireDate")).Clear();
                Driver.Instance.FindElement(By.Id("HireDate")).SendKeys(_startDate.ToString(format));
                Driver.Instance.FindElement(By.Id("OfficeAssignment_Location")).Clear();
                Driver.Instance.FindElement(By.Id("OfficeAssignment_Location")).SendKeys(_location);

                Driver.Instance.FindElement(By.XPath("//input[@value='Save']")).Click();
            }
        }
    }
}
