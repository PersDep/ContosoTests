using System;

using OpenQA.Selenium;

namespace ContosoFramework
{
    public class NewDepartmentPage
    {
        public static void GoTo()
        {
            Page.GoTo("/Department");

            Driver.Instance.FindElement(By.LinkText("Create New")).Click();
        }

        private static CreateDepartmentCommand CreateDepartment(string name)
        {
            return new CreateDepartmentCommand(name);
        }

        private class CreateDepartmentCommand
        {
            private readonly string _name;
            private decimal _budget;
            private DateTime _startDate;
            private string _administrator;

            public CreateDepartmentCommand(string name)
            {
                _name = name;
            }

            public CreateDepartmentCommand WithBudget(decimal budget)
            {
                _budget = budget;
                return this;
            }

            public CreateDepartmentCommand WithStartDate(DateTime startDate)
            {
                _startDate = startDate;
                return this;
            }

            public CreateDepartmentCommand WithAdministrator(string administrator)
            {
                _administrator = administrator;
                return this;
            }

            public void Create()
            {
                string format = @"dd\/MM\/yyyy";

                Driver.Instance.FindElement(By.Id("Name")).SendKeys(_name);
                Driver.Instance.FindElement(By.Id("Budget")).SendKeys(_budget.ToString());
                Driver.Instance.FindElement(By.Id("StartDate")).SendKeys(_startDate.ToString(format));
                Driver.Instance.FindElement(By.Id("InstructorID")).SendKeys(_administrator);

                Driver.Instance.FindElement(By.XPath("//input[@value='Create']")).Click();
            }
        }

        public static void CreateDepartment(string name, decimal budget, DateTime date, string admin)
        {
            GoTo();
            CreateDepartment(name)
                .WithBudget(budget)
                .WithStartDate(date)
                .WithAdministrator(admin)
                .Create();
        }
    }
}
