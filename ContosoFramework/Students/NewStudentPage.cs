using System;

using OpenQA.Selenium;

namespace ContosoFramework
{
    public class NewStudentPage
    {
        public static void GoTo()
        {
            Page.GoTo("/Student");

            Driver.Instance.FindElement(By.LinkText("Create New")).Click();
        }

        private static CreateStudentCommand CreateStudent(string name)
        {
            return new CreateStudentCommand(name);
        }

        private class CreateStudentCommand
        {
            private readonly string _name;
            private string _FirstName;
            private DateTime _startDate;

            public CreateStudentCommand(string name)
            {
                _name = name;
            }

            public CreateStudentCommand WithFirstName(string FirstName)
            {
                _FirstName = FirstName;
                return this;
            }

            public CreateStudentCommand WithStartDate(DateTime startDate)
            {
                _startDate = startDate;
                return this;
            }

            public void Create()
            {
                string format = @"dd\/MM\/yyyy";

                Driver.Instance.FindElement(By.Id("LastName")).SendKeys(_name);
                Driver.Instance.FindElement(By.Id("FirstMidName")).SendKeys(_FirstName);
                Driver.Instance.FindElement(By.Id("EnrollmentDate")).SendKeys(_startDate.ToString(format));

                Driver.Instance.FindElement(By.XPath("//input[@value='Create']")).Click();
            }
        }

        public static void CreateStudent(string name, string FirstName, DateTime date)
        {
            GoTo();
            CreateStudent(name)
                .WithFirstName(FirstName)
                .WithStartDate(date)
                .Create();
        }

        public static bool DoesElementExistWithData(string data)
        {
            var bodyTag = Driver.Instance.FindElement(By.TagName("body"));

            while (true)
            {
                if (bodyTag.Text.Contains(data))
                    return true;
                else
                {
                    try
                    {
                        Driver.Instance.FindElement(By.XPath("/html/body/div[2]/div/ul/li[3]")).Click();
                        bodyTag = Driver.Instance.FindElement(By.TagName("body"));
                    }
                    catch
                    {
                        break;
                    }
                }
            }

            return false;
        }
    }
}
