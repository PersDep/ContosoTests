using System;

using OpenQA.Selenium;

namespace ContosoFramework
{
    public class NewInstructorPage
    {
        private static void GoTo()
        {
            Page.GoTo("/Instructor");

            Driver.Instance.FindElement(By.LinkText("Create New")).Click();
        }

        private static CreateInstructorCommand CreateInstructor(string name)
        {
            return new CreateInstructorCommand(name);
        }

        private class CreateInstructorCommand
        {
            private readonly string LastName;
            private string FirstName;
            private DateTime _startDate;
            private string _location;

            public CreateInstructorCommand(string name)
            {
                LastName = name;
            }

            public CreateInstructorCommand WithName(string name)
            {
                FirstName = name;
                return this;
            }

            public CreateInstructorCommand WithStartDate(DateTime startDate)
            {
                _startDate = startDate;
                return this;
            }

            public CreateInstructorCommand WithLocation(string location)
            {
                _location = location;
                return this;
            }

            public void Create()
            {
                string format = @"dd\/MM\/yyyy";

                Driver.Instance.FindElement(By.Id("LastName")).SendKeys(LastName);
                Driver.Instance.FindElement(By.Id("FirstMidName")).SendKeys(FirstName);
                Driver.Instance.FindElement(By.Id("HireDate")).SendKeys(_startDate.ToString(format));
                Driver.Instance.FindElement(By.Id("OfficeAssignment_Location")).SendKeys(_location);

                Driver.Instance.FindElement(By.XPath("//input[@value='Create']")).Click();
            }
        }

            public static void CreateInstructor(string LastName, string FirstName, DateTime date, string location)
            {
                GoTo();
                CreateInstructor(LastName)
                    .WithName(FirstName)
                    .WithStartDate(date)
                    .WithLocation(location)
                    .Create();
            }
    }
}
